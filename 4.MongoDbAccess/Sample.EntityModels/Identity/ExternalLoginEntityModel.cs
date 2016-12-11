using Sample.EntityModels.Core;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EntityModels.Identity
{
    public class ExternalLoginEntityModel : BaseEntityModel
    {
        private UserEntityModel _user;

        #region Scalar Properties
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        //public virtual Guid UserId { get; set; }
        #endregion

        #region Navigation Properties
        [BsonIgnore]
        public virtual UserEntityModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                //UserId = value.UserId;
            }
        }
        #endregion
    }
}
