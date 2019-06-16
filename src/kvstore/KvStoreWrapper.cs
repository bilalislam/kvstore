using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace kvstore
{
    public class KvStoreClientWrapper
    {
        private readonly KvOptions _options;

        public KvStoreClientWrapper(KvOptions options)
        {
            _options = options;
        }

        public VaultClient GetClient()
        {
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(_options.TokenId);
            var vaultClientSettings = new VaultClientSettings(_options.Server, authMethod);
            return new VaultClient(vaultClientSettings);
        }
    }
}