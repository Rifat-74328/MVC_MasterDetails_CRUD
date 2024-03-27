//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_MasterDetails_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Experiences = new List<Experience>();
        }
    
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime DateOfBirth { get; set; }
        public int Total_Experience { get; set; }
        public bool IsAvailable { get; set; }
        public string PicPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Picture { get; set;}
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Experience> Experiences { get; set; }
    }
}