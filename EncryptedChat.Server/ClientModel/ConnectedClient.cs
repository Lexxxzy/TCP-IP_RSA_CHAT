using System;

namespace EncryptedChat.Server.ClientModel
{
    [Serializable]
    public class ConnectedClient : BaseClient
    {
        public ConnectedClient(string source, string login,Uri contactPhoto)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            ContactPhoto = contactPhoto ?? throw new ArgumentNullException(nameof(contactPhoto));
    }

        public virtual string Source { get; }
    }
}