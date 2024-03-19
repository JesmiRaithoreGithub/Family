using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Family.Models
{
    [Table("FamilyMember")]
    public class FamilyMember
    {
        [Key]
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public int FamilyMemberTypeId { get; set; }
    }
}