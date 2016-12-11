using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

namespace Sample.EntityModels.Core
{
    [DataContract]
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract  class BaseEntityModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public  ObjectId Id { get; set; }
    }
}
