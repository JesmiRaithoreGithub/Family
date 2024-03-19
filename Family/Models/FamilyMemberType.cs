using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Family.Models
{
    [Table("FamilyMemberType")]
    public class FamilyMemberType
    {
        [Key]
        public int id { get; set; }
        public string Type { get; set; }
    }
}