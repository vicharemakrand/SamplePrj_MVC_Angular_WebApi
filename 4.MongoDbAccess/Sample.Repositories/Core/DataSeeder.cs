using Sample.EntityModels;
using Sample.EntityModels.Identity;
using Sample.Utility;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Sample.Repositories.Core
{
    public class DataSeeder
    {
        public static IMongoDatabase GetDataBase()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbName"]);
            InsertCLients(database);
           return database;
        }

        public static void InsertCLients(IMongoDatabase database)
        {
            database.DropCollection(AppMethods.CorrectCollectionName(typeof(ClientEntityModel).Name));
            database.GetCollection<ClientEntityModel>(AppMethods.CorrectCollectionName(typeof(ClientEntityModel).Name)).InsertMany(
                new List<ClientEntityModel>
                {
                     new ClientEntityModel()
                        {
                            ClientId = "sampleApp",
                            Secret = AppMethods.GetHash("abc@123"),
                            Name = "Sample Site Application",
                            ApplicationType = (int)ApplicationTypes.JavaScript,
                            Active = true,
                            RefreshTokenLifeTime = 7200,
                            AllowedOrigin = "*"
                        },
                     new ClientEntityModel()
                        {
                            ClientId = "consoleApp",
                            Secret = AppMethods.GetHash("123@abc"),
                            Name = "Console Application",
                            ApplicationType = (int)ApplicationTypes.NativeConfidential,
                            Active = true,
                            RefreshTokenLifeTime = 14400,
                            AllowedOrigin = "*"
                        }

                });
        }
    }
}
