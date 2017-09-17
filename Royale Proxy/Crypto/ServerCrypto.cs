using System;
using System.IO;
using System.Linq;
using Sodium;

namespace Royale_Proxy
{
    public class ServerCrypto : Protocol
    {
        public static void DecryptPacket(ServerState state, byte[] packet)
        {
            using (var reader = new Reader(packet))
            {
                var ID = reader.ReadUInt16();
                reader.Seek(3, SeekOrigin.Current);
                var Version = reader.ReadUInt16();

                byte[] cipherText = reader.ReadAllBytes, plainText;

                var Name = Packet_Names.GetName(ID);

                switch (ID)
                {
                    case 10100:
                    {
                        plainText = cipherText;

                        break;
                    }

                    case 10101:
                    {
                        state.ClientKey = cipherText.Take(32).ToArray();

                        var nonce = GenericHash.Hash(state.ClientKey.Concat(state.ServerKey.PublicKey).ToArray(), null,
                            24);

                        cipherText = cipherText.Skip(32).ToArray();

                        plainText = PublicKeyBox.Open(cipherText, nonce, state.ServerKey.PrivateKey, state.ClientKey);

                        state.SessionKey = plainText.Take(24).ToArray();
                        state.ClientState.Nonce = plainText.Skip(24).Take(24).ToArray();

                        plainText = plainText.Skip(24).Skip(24).ToArray();

                        break;
                    }

                    default:
                    {
                        state.ClientState.Nonce = Utilities.Increment(Utilities.Increment(state.ClientState.Nonce));

                        plainText = SecretBox.Open(new byte[16].Concat(cipherText).ToArray(), state.ClientState.Nonce,
                            state.SharedKey);

                        break;
                    }
                }

                ClientCrypto.EncryptPacket(state.ClientState, ID, Version, plainText);

                Console.WriteLine(
                    $"[{DateTime.Now.ToLongTimeString()}, CLIENT, {ID}] {Resources.Definition.Decode(new Reader(plainText), ID)}");

                Logger.Write(BitConverter.ToString(plainText).Replace("-", string.Empty), $"{ID}_{Name}",
                    LogType.PACKET);
            }
        }

        public static void EncryptPacket(ServerState state, int ID, int version, byte[] plainText)
        {
            byte[] cipherText;

            switch (ID)
            {
                case 20100:
                case 20103:
                {
                    cipherText = plainText;

                    break;
                }

                case 20104:
                {
                    var nonce = GenericHash.Hash(
                        state.ClientState.Nonce.Concat(state.ClientKey).Concat(state.ServerKey.PublicKey).ToArray(),
                        null, 24);

                    plainText = state.Nonce.Concat(state.SharedKey).Concat(plainText).ToArray();

                    cipherText = PublicKeyBox.Create(plainText, nonce, state.ServerKey.PrivateKey, state.ClientKey);

                    break;
                }

                default:
                {
                    cipherText = SecretBox.Create(plainText, state.Nonce, state.SharedKey).Skip(16).ToArray();

                    break;
                }
            }

            var packet = BitConverter.GetBytes(ID).Reverse().Skip(2)
                .Concat(BitConverter.GetBytes(cipherText.Length).Reverse().Skip(1))
                .Concat(BitConverter.GetBytes(version).Reverse().Skip(2)).Concat(cipherText).ToArray();

            state.Socket.BeginSend(packet, 0, packet.Length, 0, SendCallback, state);
        }
    }
}