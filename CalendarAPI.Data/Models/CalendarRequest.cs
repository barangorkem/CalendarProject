using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CalendarAPI.Data.Models
{
    public class CalendarRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Girdiğiniz veri formatı Date tipinde değildir.")]
        public DateTime StartedDate { get; set; }
        [Required]
        [DataType(DataType.DateTime,ErrorMessage = "Girdiğiniz veri formatı Date tipinde değildir.")]
        public DateTime EndDate { get; set; }
        [Required]
        public int Result { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
