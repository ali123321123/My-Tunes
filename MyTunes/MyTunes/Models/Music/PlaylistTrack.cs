using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models.Music
{
  public class PlaylistTrack
    {
        public int PlaylistId { get; set; }    //fk
        public int TrackId { get; set; } //fk
   
    }
}
