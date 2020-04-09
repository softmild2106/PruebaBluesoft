using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Database.Base
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        [DefaultValue(0)]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
