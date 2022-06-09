using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Service
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext context)
        {
            _dbContext = context;
        }

        public async Task<GetMusician> GetMusician(int idMusician)
        {        
            return await _dbContext.Musicians.Select(e => new GetMusician
              {
                  idMusician = e.idMusician,
                  firstName = e.firstName,
                  lastName = e.lastName,
                  nickName = e.nickName,          
                  Tracks = e.musician_Tracks.Select(e => new SomeSortOfTrack { idTrack = e.idTrack, trackName = e.track.trackName}).ToList()
              }).Where(e => e.idMusician == idMusician).FirstOrDefaultAsync();
        }

        public Task<string> RemoveMusician(int idMusician)
        {
            throw new NotImplementedException();
        }
    }
}
