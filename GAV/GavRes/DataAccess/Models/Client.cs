using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAV.GavRes.DataAccess.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public UInt64 RegistrationId { get; set; }
        [Required][MinLength(1)] public string Name { get; set; }
        [Required][MinLength(1)] public string Surname { get; set; }
        [Required][MinLength(1)] public string Addresses { get; set; }
        [Required][MinLength(1)] public string Telephone { get; set; }
        [Required] public DateTime RegistrationDate { get; set; }
    }
}
