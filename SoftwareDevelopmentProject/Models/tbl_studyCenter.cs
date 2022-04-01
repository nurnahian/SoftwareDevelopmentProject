//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftwareDevelopmentProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_studyCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_studyCenter()
        {
            this.tbl_students = new HashSet<tbl_students>();
            this.tbl_users = new HashSet<tbl_users>();
        }

        
        public int study_center_id { get; set; }
        [Required(ErrorMessage = "Please enter Study Center Code.")]
        [Display(Name = "Center Code ")]
        public int study_center_code { get; set; }
        [Required(ErrorMessage = "Please enter Study Center Name.")]
        [Display(Name = "Center Name ")]
        public string study_center_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_students> tbl_students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_users> tbl_users { get; set; }
    }
}
