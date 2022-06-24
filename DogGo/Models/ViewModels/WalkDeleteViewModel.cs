using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkDeleteViewModel
    {
        public List<Walk> Walks { get; set; }

        public bool[] ChosenWalkIds { get; set; }
    }
}
