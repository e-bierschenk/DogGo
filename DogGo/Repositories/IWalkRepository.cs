using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAll();
        List<Walk> GetWalksByWalkerId(int walkerId);

        void AddWalk(Walk walk);
    }
}
