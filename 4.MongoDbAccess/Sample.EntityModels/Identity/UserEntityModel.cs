using Sample.EntityModels.Core;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EntityModels.Identity
{
    
 public class UserEntityModel : BaseEntityModel
    {
        
        #region Fields
        private ICollection<ClaimEntityModel> _claims;
        private ICollection<ExternalLoginEntityModel> _externalLogins;
        private ICollection<RoleEntityModel> _roles;
        #endregion

        #region Scalar Properties
        //public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int AgeRange { get; set; }
        public int Gender { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int UserStatus { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        [BsonIgnore]
        public virtual ICollection<ClaimEntityModel> Claims
        {
            get { return _claims ?? (_claims = new List<ClaimEntityModel>()); }
            set { _claims = value; }
        }

        [BsonIgnore]
        public virtual ICollection<ExternalLoginEntityModel> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLoginEntityModel>());
            }
            set { _externalLogins = value; }
        }

        [BsonIgnore]
        public virtual ICollection<RoleEntityModel> Roles
        {
            get { return _roles ?? (_roles = new List<RoleEntityModel>()); }
            set { _roles = value; }
        }

        #endregion
    }
}
