using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class DeskQuote
    {
        public DeskQuote()
        {

        }

        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 200.00M;
        private const decimal DRAWER_COST = 200.00M;

        [Key]
        public int DeskQuoteId { get; set; }

        [Required, Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Price")]
        [DisplayFormat(DataFormatString="{0:C}")]
        public decimal QuotePrice { get; set; }

        // reference to Desk and DeliveryType classes (foreign keys)
        public int DeskId { get; set; }

        [Display(Name = "Delivery Type")]
        public int DeliveryTypeId { get; set; }

        // referencing foreign keys are not enough. We need a way to store data referenced by the foreign key
        public Desk Desk { get; set; }

        public DeliveryType DeliveryType { get; set; }

        // methods (GetQuotePrice)
    }
}
