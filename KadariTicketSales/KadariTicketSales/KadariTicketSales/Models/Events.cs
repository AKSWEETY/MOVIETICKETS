namespace KadariTicketSales.Models
{
    public class Events
    {
        /* 
         ***** created by Kadari ******
        ****** 2222222222222222  ******
        this craetes a type for events
        each has an event name, description for the events, the category of the event and has an image to display
        */

        public int Id { get; set; }
        public string? Title { get; set; }
        public int CategoryId {  get; set; }
        public double TicketPrice {  get; set; }
        public string? Description {  get; set; }
        public string? ImageId { get; set;}
    }//event class
}//namespace ticketSales
