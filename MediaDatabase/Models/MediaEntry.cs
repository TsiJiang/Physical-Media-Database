using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Models
{
    public class MediaEntry
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public DateTime LastModified { get; set; }
        public double Size { get; set; }
        public string SizeType { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
