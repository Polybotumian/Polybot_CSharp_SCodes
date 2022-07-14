using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAV.GavRes.DataAccess.Models
{
    [Table("Users")]
    public class User
    {
        //[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public UInt64 RegistrationId { get; set; }
        [Key][MinLength(1)] public string UserName { get; set; }
        [Required][MinLength(1)] public string Password { get; set; }
        [Required] public DateTime RegistrationDate { get; set; }
    }
}
