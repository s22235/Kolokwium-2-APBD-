using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MusicLabel
    {
        public int idMusicLabel { get; set; }
        public string name { get; set; }
        public virtual ICollection<Album> albums { get; set; }
    }
}
