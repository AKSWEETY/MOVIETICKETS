using KadariTicketSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace KadariTicketSales.Controllers
{
    public class CartController : Controller
    {
        
        // created by kadari
        
        public IActionResult Buy(int id)
        {
            //gets id of the event that the user wants to buy ticket for
            //using eventservices, gets an object representing event
            EventService eventService= new EventService();
            //retrives the evnet details by its id.
            Events selectedEvent = eventService.GetEvents(id);
            //start buying ticket by creating buyticket object and setting name of ticket and ticket price
            BuyTicketsModel buyTickets = new BuyTicketsModel(selectedEvent.Title, selectedEvent.TicketPrice);
            return View(buyTickets);//returns buy view
        }
        //action method which deals with form 
        public IActionResult Confirmation(BuyTicketsModel model)
        {
            //validates the property for conditions
            if (ModelState.IsValid)
            {
                //calls calculateamountdue method from buytickets model
                model.CalculateAmountDue();
                return View(model);//returns view of model
            }
            return View("Buy",model);//takes user back to buy tickets page
        }
    }
}
