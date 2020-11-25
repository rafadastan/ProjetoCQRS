﻿using MongoDB.Driver;
using Projeto02.Infra.Data.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.MongoDB.Contexts
{
    public class MongoDbContext
    {
        //atributos
        private readonly MongoDBSettings mongoDBSettings;
        private IMongoDatabase mongoDatabase;

        public MongoDbContext(MongoDBSettings mongoDBSettings)
        {
            this.mongoDBSettings = mongoDBSettings;

            #region Configurar o MongoDB

            var settings = MongoClientSettings.FromUrl(new MongoUrl(mongoDBSettings.Host));

            if (mongoDBSettings.IsSSL)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase(mongoDBSettings.DatabaseName);

            #endregion
        }
    }
}
