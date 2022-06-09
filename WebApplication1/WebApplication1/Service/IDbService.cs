using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Service
{
    public interface IDbService
    {
        Task<GetMusician> GetMusician(int idMusician);
        Task<String> RemoveMusician(int idMusician);
    }
}
