using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FncExamenFinal.Models
{
    class Data
    {
        [Key]
        public string NameDevice { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string Event { get; set; }
    }
}
