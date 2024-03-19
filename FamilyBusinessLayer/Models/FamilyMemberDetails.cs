using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyBusinessLayer.Models
{
    [Table("FamilyMember")]
    public class FamilyMemberDetails
    {
        [Key]
        public int FamilyMemberId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public int FamilyMemberTypeId { get; set; }
    }
}