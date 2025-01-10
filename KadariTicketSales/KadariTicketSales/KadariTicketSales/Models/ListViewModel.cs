namespace KadariTicketSales.Models
{
    public class ListViewModel
    {
        //created by kadari
        public IEnumerable<Events> Events    { get; }
        public List<Category> Categories { get;  }

        public String? SelectedCategory{get;}
        public ListViewModel(IEnumerable<Events> events, List<Category> categories, string selectedCategory) {
            Events = events;
            Categories = categories;
            SelectedCategory=selectedCategory;
        }

    }//ListViewModel clas
}// namespce 
