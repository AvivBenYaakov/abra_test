using server.Models;

namespace server.Services
{
    public interface IPetService
    {
        List<Pet> Get();
        Pet Get(string id);
        Pet Create(Pet pet);
        void Update(string id, Pet pet);
        void Remove(string id);
    }
}
