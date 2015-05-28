using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Model
{
    public interface IPresentationRepository
    {
        Task<List<Presentations>> AllPresentations();

        Task<Presentations> Get(ObjectId id);

        void Add(Presentations presentations);

        void Update(Presentations presentations);

        Task<bool> Remove(ObjectId id);
    }
}