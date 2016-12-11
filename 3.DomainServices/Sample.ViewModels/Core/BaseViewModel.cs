using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Web.Mvc;

namespace Sample.ViewModels.Core
{
    [Serializable]
    public abstract class BaseViewModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

    }
}
