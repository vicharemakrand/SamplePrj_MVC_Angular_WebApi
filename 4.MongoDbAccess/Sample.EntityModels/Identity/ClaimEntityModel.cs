using Sample.EntityModels.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Sample.EntityModels.Identity
{
    public class ClaimEntityModel : BaseEntityModel
    {
        private UserEntityModel _user;

        #region Scalar Properties
        public virtual int ClaimId { get; set; }
        public virtual ObjectId UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        [BsonIgnore]
        public virtual UserEntityModel User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.Id;
            }
        }
        #endregion
    }
}
