//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Family.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Task
    {
        [Key]
        public int Task_Id { get; set; }
       
        [Display(Name = "Task Name")]
        public string Task_Name { get; set; }
        [Required]
        [Display(Name = "Task Preparation")]
        public string Task_Preparation { get; set; }
        [Required]
        [Display(Name = "Task Duration")]
        public Nullable<int> Task_Duration { get; set; }
        [Required]
        [Display(Name = "Task Status")]
        public string Task_Status { get; set; }
        [Required]
        public Nullable<int> Task_FamilyMemberId { get; set; }
    
        public virtual FamilyMember FamilyMember { get; set; }
    }
}
