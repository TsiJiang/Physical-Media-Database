using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Email is Required.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required.")]
        [MinLength(8,ErrorMessage ="Password must be at least 8 characters.")]
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public IEnumerable<MediaEntry> MediaEntries { get; set; }
    }
}
