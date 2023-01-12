using System.Net.Cache;

namespace GC_Practice_Assessment_MVC.Models
{
    public class PersonVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public bool CanDrink { get; set; } 
        public bool CanDrive { get; set; }
        
        public PersonVM()
        {
            
        }
    }
    
}
