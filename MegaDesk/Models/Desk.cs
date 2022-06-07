using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class Desk
    {
        public int DeskId { get; set; }

        [Required, Range(24, 96)]
        public int Width { get; set; }
        [Required, Range(12, 48)]
        public int Depth { get; set; }
        [Required, Range(0, 7)]
        public int NumDrawers { get; set; }

        // foreign keys
        public int DesktopMaterialId { get; set; }

        // data referenced by foreign keys
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}
