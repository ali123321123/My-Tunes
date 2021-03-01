using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models
{
   public class Track
    {
        public int TrackId { get; set; } //pk
        public int AlbumId { get; set; } //fk
        public int MediaTypeId { get; set; } //fk
        public int GenreId { get; set; } //fk
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public int UnitPrice { get; set; }

    }
}
