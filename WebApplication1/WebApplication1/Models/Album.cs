using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Album
    {
        public int idAlbum { get; set; }
        public string albumName { get; set; }
        public DateTime publishDate { get; set; }
        public int idMusicLabel { get; set; }
        public virtual MusicLabel musicLabel { get; set; }
        public virtual ICollection<Track> tracks { get; set; }

    }
}
