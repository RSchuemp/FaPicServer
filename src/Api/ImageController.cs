using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    [Route("image")]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly Models.FaPicContext _context;
        

        public ImageController( Models.FaPicContext context)
        {
          
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
  
            var id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
               
            return new JsonResult(from c in _context.ImageModels where c.ClientId.Equals(id) select new { Image= Convert.ToBase64String(c.Image), c.Id});
        
           
    }

        [HttpPost]     
        public async Task Post([FromBody]string image)
        {           
               var id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
                 _context.ImageModels.Add(new Models.ImageModel() { ClientId = id, Image = Convert.FromBase64String(image) });
                 _context.SaveChanges();
           
        }
    }
}
