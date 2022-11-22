using Microsoft.AspNetCore.Identity;

namespace trackerApi.Data
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public virtual IList<Weight> Weights { get; set; }


    }
}
