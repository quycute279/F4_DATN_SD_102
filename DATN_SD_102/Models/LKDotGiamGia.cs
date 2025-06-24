using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class LKDotGiamGia
    {
        [Key]
        public Guid LKDotGiamGiaId { get; set; }
        public Guid? LkId { get; set; }
        public Guid? GiamGiaId { get; set; }

        public LinhKien? LinhKien { get; set; }
        public GiamGia? GiamGia { get; set; }
    }
}
