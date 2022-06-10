using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class DesktopMaterial
    {
        [Key]
        public int DesktopMaterialId { get; set; }

        public string? DesktopMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}
