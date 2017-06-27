using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamApp.Models.Extended
{
    [MetadataType(typeof(TableMetadata))]
    public partial class Table
    {

    }

    public class TableMetadata
    {
        [Display(Name = "ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Nama Depan")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Nama Depan Wajib")]
        public string FirstName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Wajib")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}