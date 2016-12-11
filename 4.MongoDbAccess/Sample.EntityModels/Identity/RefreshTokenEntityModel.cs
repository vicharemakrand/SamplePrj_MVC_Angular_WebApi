using Sample.EntityModels.Core;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.EntityModels.Identity
{
    public class RefreshTokenEntityModel : BaseEntityModel
    {
        private ClientEntityModel _client;

        [Required]
        public string TokenId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        [Required]
        public string ProtectedTicket { get; set; }

        #region Navigation Properties
        [BsonIgnore]
        public virtual ClientEntityModel Client
        {
            get { return _client; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _client = value;
                ClientId = value.ClientId;
            }
        }
        #endregion
    }
}
