using System;
using System.Net.Sockets;

namespace EncryptedChat.Server.ClientModel
{
    public class ServerClient : BaseClient
    {
        public ServerClient()
        {

        }

        public ServerClient(TcpClient client, Guid id, string login, Uri contactPhoto)
        {            
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            ContactPhoto = contactPhoto ?? throw new ArgumentNullException(nameof(contactPhoto));
            ID = id;
        }

        public TcpClient Client { get; }
    }
}