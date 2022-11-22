using System.ComponentModel.DataAnnotations;

namespace trackerApi.Models.Weights
{
    public abstract class BaseWeightDto
    {
        [Required]
        public int WeightAmount { get; set; }
        public DateTime DateTime { get; set; }
       
       


    }
}
