//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

/*namespace Family.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FamilyMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamilyMember()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public Nullable<int> FamilyMemberTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
*/

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
        [Display(Name = "Assigned Name")]
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}