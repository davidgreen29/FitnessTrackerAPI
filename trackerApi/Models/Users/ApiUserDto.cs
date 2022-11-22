


using System.ComponentModel.DataAnnotations;
using trackerApi.Models.Weights;

namespace trackerApi.Models.Users
{
    public class ApiUserDto: LoginDto
    {
       

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        public string Password {get;set;}
        public List<UserWeightDto> Weights { get; set; }
    }

}
