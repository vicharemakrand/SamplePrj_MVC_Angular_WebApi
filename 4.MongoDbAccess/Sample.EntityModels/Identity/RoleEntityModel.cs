using Sample.EntityModels.Core;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EntityModels.Identity
{
    public class RoleEntityModel : BaseEntityModel
    {
        #region Fields
        private ICollection<UserEntityModel> _users;
        #endregion

        #region Scalar Properties
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        [BsonIgnore]
        public ICollection<UserEntityModel> Users
        {
            get { return _users ?? (_users = new List<UserEntityModel>()); }
            set { _users = value; }
        }
        #endregion
    }
}
