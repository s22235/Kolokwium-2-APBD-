using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Musician_Track
    {
        public int idTrack { get; set; }
        public int idMusician { get; set; }
        public virtual Musician musician { get; set; }
        public virtual Track track { get; set; }
    }
}
