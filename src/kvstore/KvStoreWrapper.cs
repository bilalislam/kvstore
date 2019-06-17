using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.SystemBackend;

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
            var client = new VaultClient(vaultClientSettings);

            client.V1.System.WritePolicyAsync(new Policy
            {
                Name = "kvstore-policy",
                Rules = "path \"kv/*\" {  policy = \"write\" }"
            });

            return client;
        }
    }
}