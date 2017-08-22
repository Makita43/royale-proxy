// *******************************************************
// Created at 22/08/2017
// *******************************************************

namespace Royale_Proxy
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using Sodium;

    public class ClientCrypto : Protocol
    {
        protected KeyPair clientKey = PublicKeyBox.GenerateKeyPair();

        public static void DecryptPacket(Socket socket, ClientState state, byte[] packet)
        {
            using (var reader = new Reader(packet))
            {
                ushort ID = reader.ReadUInt16();
                reader.Seek(3, SeekOrigin.Current);
                ushort Version = reader.ReadUInt16();

                byte[] cipherText = reader.ReadAllBytes, plainText;

                string Name = Packet_Names.GetName(ID);

                switch (ID)
                {
                    case 20100:
                    case 20103:
                    {
                        plainText = cipherText;

                        break;
                    }

                    case 20104:
                    {
                        byte[] nonce = GenericHash.Hash(state.Nonce.Concat(state.ClientKey.PublicKey).Concat(state.ServerKey).ToArray(), null, 24);

                        plainText = PublicKeyBox.Open(cipherText, nonce, state.ClientKey.PrivateKey, state.ServerKey);

                        state.ServerState.Nonce = plainText.Take(24).ToArray();
                        state.ServerState.SharedKey = plainText.Skip(24).Take(32).ToArray();

                        plainText = plainText.Skip(24).Skip(32).ToArray();

                        break;
                    }

                    default:
                    {
                        state.ServerState.Nonce = Utilities.Increment(Utilities.Increment(state.ServerState.Nonce));

                        plainText = SecretBox.Open(new byte[16].Concat(cipherText).ToArray(), state.ServerState.Nonce, state.ServerState.SharedKey);

                        break;
                    }
                }

                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}, SERVER, {ID}] {Resources.Definition.Decode(new Reader(plainText), ID)}");

                Logger.Write(BitConverter.ToString(plainText).Replace("-", string.Empty), $"{ID}_{Name}", LogType.PACKET);

                ServerCrypto.EncryptPacket(state.ServerState.Socket, state.ServerState, ID, Version, plainText);
            }
        }

        public static void EncryptPacket(Socket socket, ClientState state, int ID, int version, byte[] plainText)
        {
            byte[] cipherText;

            switch (ID)
            {
                case 10100:
                {
                    cipherText = plainText;

                    break;
                }

                case 10101:
                {
                    byte[] nonce = GenericHash.Hash(state.ClientKey.PublicKey.Concat(state.ServerKey).ToArray(), null, 24);

                    plainText = state.ServerState.SessionKey.Concat(state.Nonce).Concat(plainText).ToArray();

                    cipherText = PublicKeyBox.Create(plainText, nonce, state.ClientKey.PrivateKey, state.ServerKey);

                    cipherText = state.ClientKey.PublicKey.Concat(cipherText).ToArray();

                    break;
                }

                default:
                {
                    cipherText = SecretBox.Create(plainText, state.Nonce, state.ServerState.SharedKey).Skip(16).ToArray();

                    break;
                }
            }

            byte[] packet = BitConverter.GetBytes(ID).Reverse().Skip(2).Concat(BitConverter.GetBytes(cipherText.Length).Reverse().Skip(1)).Concat(BitConverter.GetBytes(version).Reverse().Skip(2)).Concat(cipherText).ToArray();

            socket.BeginSend(packet, 0, packet.Length, 0, SendCallback, state);
        }
    }
}