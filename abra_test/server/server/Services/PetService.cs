using MongoDB.Driver;
using server.Models;

namespace server.Services
{
    public class PetService : IPetService
    {
        private readonly IMongoCollection<Pet> _pets;

        public PetService(IPetsStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _pets = database.GetCollection<Pet>(settings.PetsCollectionName);
        }

        public Pet Create(Pet pet)
        {
            _pets.InsertOne(pet);
            return pet;
        }

        public List<Pet> Get()
        {
            return _pets.Find(pet => true).ToList();
        }

        public Pet Get(string id)
        {
            return _pets.Find(pet => pet.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _pets.DeleteOne(pet => pet.Id == id);
        }

        public void Update(string id, Pet pet)
        {
            _pets.ReplaceOne(pet => pet.Id == id, pet);
        }
    }
}
