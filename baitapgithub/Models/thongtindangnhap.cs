//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace baitapgithub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class thongtindangnhap
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "khong de o trong ")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "khong de o trong ")]
        [Display(Name = "Passwords")]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }

        [Required(ErrorMessage = "khong de o trong ")]
        [Display(Name = "RePasswords")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("RePasswords",ErrorMessage=" mat khau khong dung ,thu lai !")]
        public string RePasswords { get; set; }

    }
}
