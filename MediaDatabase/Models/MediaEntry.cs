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
        public enum MediaType
        {
            Book,
            Magazine,
            Comic,
            Manga,
            CompactDisc,
            DigitalVersatileDisc,
            VideoHomeSystem,
            Cassette,
            VinylRecord,
            FlashDrive,
            SecureDigitalCard,
            ExternalHardDiscDrive,
            VideoGameCD,
            VideoGameDVD,
            VideoGameCartridge,
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Media Item must have a Name.")]
        public string Name{ get; set; }
        public DateTime LastModified { get; set; }
        public double Size { get; set; }
        public string SizeType { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("MediaType")]
        public int MediaTypeId { get; set; }
    }
}
