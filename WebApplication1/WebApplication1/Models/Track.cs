using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Track
    {
        public int idTrack { get; set; }
        public string trackName { get; set; }
        public float duration { get; set; }
        public int idMusicAlbum { get; set; }
        public virtual Album album { get; set; }
        public virtual ICollection<Musician_Track> musician_Tracks { get; set; }

    }
}
