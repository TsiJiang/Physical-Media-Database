using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class MediaType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Media Type must have a name.")]
        public string Name { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public IEnumerable<MediaEntry> mediaEntries { get; set; }
    }
}
