using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTO
{
    public class GetMusician
    {
        public int idMusician { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickName { get; set; }
        public List<SomeSortOfTrack> Tracks { get; set; }
    }
}
