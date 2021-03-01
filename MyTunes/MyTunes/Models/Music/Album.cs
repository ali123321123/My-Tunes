using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models
{
    public class Album
    {
        public int AlbumId { get; set; } // PK
        public string Title { get; set; }
        public int ArtistId { get; set; } //Fk

    }
}
