using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;


namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService) 
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return _petService.Get();
        }

        [HttpGet]
        public ActionResult<Pet> Get(string id)
        {
            var pet = _petService.Get(id);
            if (pet == null)
            {
                return NotFound($"Pet with Id = {id} not found");
            }
            return pet;
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            _petService.Create(pet);
            return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
        }
                

    }
}
