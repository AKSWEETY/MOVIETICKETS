using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KadariTicketSales.Models
{
    public class BuyTicketsModel
    {
        //created by kadari
        /* this is the supporting model for buy view which is a form that accesses this class
         this class has an overloaded constructor for events name and for sales and ticket price default parameterkess constuctor for binding model.
        this class has an overloaded constructor with two signatures a default constructor and onw with parameters for events name and for sale and ticket price default parameterless constructor is needed for binding model
        this  parameterized constuctor is callled from the cart controler's buy action method , to be sent as viewmodel. supports buy from. there re two methods:calculateDiscount() and processsale () methods*/
        private const Double SR_DISCOUNT_RATE = 0.2D;// const


        public string? EventName {  get; set; }
        public string? CustomerName {  get; set; }

        [Required(ErrorMessage="Email is a required field")]
        [EmailAddress(ErrorMessage ="please enter a valid email id")]//formats emails
        [Display(Name ="Email address:")]
        public string? Email { get; set;}

        public double Ticketprice {  get; set; }
        public string? SaleDate {  get; set; }
        [Required(ErrorMessage ="please enter number of tickets")]
        [Range(1,10,ErrorMessage ="number of tickets shold be between 1 and 10")]
        public int NumberOfTickets {  get; set; }

        [Display(Name ="Senior discount")]
        public bool SeniorDiscount {  get; set; }
        [Required(ErrorMessage ="delivery option is required")]
        [Display(Name ="Select mode of delivery:")]
        public string? DeliveryMode {  get; set; }//underlying property for dropdown
        //other properties
        
        public double SubTotal {  get; set; }
        public double SalesDiscount {  get; set; }
        public double DeliveryCharge  { get; set; }
        public double AmountDue { get; set; }

        //collection for select dropdown
        public List<SelectListItem> DeliveryOptions = new()
        {
            new SelectListItem{ Value="",Text=""},
            new SelectListItem{Value="Mail",Text="Mail"},
            new SelectListItem{Value="Print",Text="Print"},
            new  SelectListItem{Value="Digital",Text="Digital"},
            new SelectListItem{Value="Call", Text="Call"}

        };
        public BuyTicketsModel()
        {
            //parameterless constructor
        }

        //overloaded constructor sets parameters from action method in the cart controller
        public BuyTicketsModel(string? eventName, double ticketprice)
        {
            this.EventName= eventName;
            this.Ticketprice= ticketprice;
        }
        // CaluclateDiscount to calcuate discount for senior citizens
        public void CalculateDiscount()
        {
            SalesDiscount = SubTotal * SR_DISCOUNT_RATE;
        }
        // CalcuateAmountDue methos calculate total ticket price
        public void CalculateAmountDue()
        {
            //calculate the amount due and sets the saledate
            SaleDate = DateTime.Today.ToString();
            SubTotal = Ticketprice * NumberOfTickets;
            //check if they are senior citizens
            if (SeniorDiscount)
            {
                CalculateDiscount();
            }
            //check delivery for deliverymode 
            if(DeliveryMode == "Mail")
            {
                DeliveryCharge = 3.95;
            }
            else
            {
                DeliveryCharge = 0;
            }
            AmountDue = SubTotal - SalesDiscount + DeliveryCharge;
        }//sales

    }
}
