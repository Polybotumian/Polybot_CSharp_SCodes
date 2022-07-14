using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAV.GavRes.DataAccess.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public UInt64 RegistrationId { get; set; }
        [Required][MinLength(1)] public string Name { get; set; }
        [Required] public DateTime RegistrationDate { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required][MinLength(1)] public string Sex { get; set; }
        [Required][MinLength(1)] public string Genus { get; set; }
        [Required][MinLength(1)] public string Breed { get; set; }
        [Required][MinLength(1)] public string Color { get; set; }
        [Required][MinLength(1)] public string DistinguishingMarks { get; set; }
        public UInt64 OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        protected virtual Client Client { get; set; }
    }
}
