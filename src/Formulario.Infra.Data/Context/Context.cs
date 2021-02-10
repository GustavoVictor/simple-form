using Microsoft.Extensions.Configuration;
using Formulario.Infra.Data.DTO;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Formulario.Infra.Data
{
    public class Context 
    {
        private IConfiguration _config;

        private IMongoDatabase _mongoDatabase;

        private DatabaseConnectionDTO _databaseConnection;

        public Context(IConfiguration config)
        {
            _config = config;

            _databaseConnection = _config.GetSection("MongoDB").Get<DatabaseConnectionDTO>();

            SetDatabase();
        }

        public IMongoCollection<TEntity> Set<TEntity>()
        {
            return _mongoDatabase.GetCollection<TEntity>(nameof(TEntity));
        }

        private void SetDatabase()
        {
            MongoClientSettings settings = new MongoClientSettings();

            settings.Credential = AuthMongo(settings);

            string mongoHost = _databaseConnection.Host;

            MongoServerAddress address = new MongoServerAddress(mongoHost);

            settings.Server = address;

            MongoClient _client = new MongoClient(settings);   

            var _a = _client.ListDatabaseNames(); 

            _mongoDatabase = _client.GetDatabase(_databaseConnection.DatabaseName);
        }

        private MongoCredential AuthMongo(MongoClientSettings settings)
        {
            string username = _databaseConnection.UserName;
            string password = _databaseConnection.Password;
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            
            MongoInternalIdentity internalIdentity = new MongoInternalIdentity(_databaseConnection.DatabaseName, username);
            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            return new MongoCredential(mongoDbAuthMechanism, internalIdentity, passwordEvidence);
        }
    }
}