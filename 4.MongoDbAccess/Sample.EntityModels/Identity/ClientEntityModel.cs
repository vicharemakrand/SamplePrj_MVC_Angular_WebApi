using Sample.EntityModels.Core;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.EntityModels.Identity
{
    public class ClientEntityModel : BaseEntityModel
    {
        private ICollection<RefreshTokenEntityModel> _refreshTokens;

        //[Key]
        public string ClientId { get; set; }

        //[Required]
        public string Secret { get; set; }

        //[Required]
        //[MaxLength(100)]
        public string Name { get; set; }

        public int ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }

        //[MaxLength(100)]
        public string AllowedOrigin { get; set; }

        #region Navigation Properties
        [BsonIgnore]
        public virtual ICollection<RefreshTokenEntityModel> RefreshTokens
        {
            get { return _refreshTokens ?? (_refreshTokens = new List<RefreshTokenEntityModel>()); }
            set { _refreshTokens = value; }
        }
        #endregion
    }
}
