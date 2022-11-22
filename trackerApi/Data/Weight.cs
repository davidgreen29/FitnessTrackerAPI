using System.ComponentModel.DataAnnotations.Schema;

namespace trackerApi.Data
{
    public class Weight
    {
        public int Id { get; set; }
        public int WeightAmount { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
    }
}
