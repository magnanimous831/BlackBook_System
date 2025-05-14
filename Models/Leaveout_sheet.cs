using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class Leaveout_sheet
    {
        public Leaveout_sheet()
        {
            STUDENTNAME = "";
            ADMNO = "";
            CLASS = "";
            REASONFORLEAVING = "";
            CLASSTEACHER = "";
            TOD = "";
            PRINCIPAL = "";
        }
        [Key]
        public int LEAVEOUTID { get; set; }

        [Required]
        [StringLength(100)]
        public required string STUDENTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public required string ADMNO { get; set; }

        [Required]
        [StringLength(50)]
        public required string CLASS { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime LEAVINGDATE { get; set; }

        [Required]
        [StringLength(300)]
        public required string REASONFORLEAVING { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public   DateTime RETURNDATE { get; set; }

        [Required]
        [StringLength(100)]
        public  string CLASSTEACHER { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SIGNATUREDATE { get; set; }

        [Required]
        [StringLength(100)]
        public required string TOD { get; set; }  // Teacher on Duty

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TODDATE { get; set; }

        [Required]
        [StringLength(100)]
        public  string PRINCIPAL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SIGNDATE { get; set; }

        [StringLength(500)]
        public string? CertificatePath { get; set; }
    }
}
