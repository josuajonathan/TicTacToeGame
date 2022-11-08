using Database.Models;
using Database.Services;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PlayerDBController : ControllerBase {
        public PlayerDBController()
        {
        }

        //GET All Action
        [HttpGet]
        public ActionResult<List<PlayerDB>> GetAll() =>
        PlayerDBServices.GetAll();
        
        //GET by id Action
        [HttpGet("{id}")]
        public ActionResult<PlayerDB> Get(int id)
        {
            var db = PlayerDBServices.Get(id);

            if (db == null)
                return NotFound();

            return db;
        }


        //PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, PlayerDB db)
        {
            if (id != db.id)
                return BadRequest();

            var existingPizza = PlayerDBServices.Get(id);
            if (existingPizza is null)
                return NotFound();

            PlayerDBServices.Update(db);
            return NoContent();
        }

    }


}