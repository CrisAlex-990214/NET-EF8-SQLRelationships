using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLRelationships.Entities;

namespace SQLRelationships.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetAll(Context context)
        {
            return context.User
                .Include(x => x.Address)
                .Include(x => x.Products)
                .Include(x => x.Coupons);
        }
    }
}