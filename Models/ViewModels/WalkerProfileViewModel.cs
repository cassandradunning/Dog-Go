using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerProfileViewModel
    {
        public Walker Walker { get; set; }
       
        public List<Walks> Walks { get; set; }
      
    }
}

// could add a property that adds all the time 