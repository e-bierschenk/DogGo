using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Models.ViewModels
{
    public class WalkFormViewModel
    {
        public Walk Walk { get; set; }
        public List<Dog> Dogs { get; set; }
        public List<Walker> Walkers { get; set; }

        public List<int> ChosenDogIds { get; set; }
    }
}
