using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class Leaveout_sheet
    {
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
        [DataType(DataType.Date)]
        public DateTime LEAVINGDATE { get; set; }

        [Required]
        [StringLength(300)]
        public required string REASONFORLEAVING { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RETURNDATE { get; set; }

        [Required]
        [StringLength(100)]
        public required string CLASSTEACHER { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SIGNATUREDATE { get; set; }

        [Required]
        [StringLength(100)]
        public required string TOD { get; set; }  // Teacher on Duty

        [Required]
        [DataType(DataType.Date)]
        public DateTime TODDATE { get; set; }

        [Required]
        [StringLength(100)]
        public required string PRINCIPAL { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SIGNDATE { get; set; }
    }
}
