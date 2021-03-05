using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using backend_database_HTTP_Requests.Models;

namespace backend_database_HTTP_Requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        public static List<Games> GetGames()
        {
            List<Games> games = new List<Games>();
            games.Add(new Games(){Id = 1, Name = "Game 1", Price = 10});
            games.Add(new Games(){Id = 2, Name = "Game 2", Price = 15});
            games.Add(new Games(){Id = 3, Name = "Game 3", Price = 20});
            games.Add(new Games(){Id = 4, Name = "Game 4", Price = 25});
            games.Add(new Games(){Id = 5, Name = "Game 5", Price = 30});
            return games;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Games>> GetGames_List()
        {
            return GetGames();
        }

        [HttpGet("{id}")]
        public ActionResult<Games> GetGames_ById(int id)
        {
            var games = GetGames().Find(x => x.Id == id);
            if(games != null)
            {
                return games;
            }
            else 
            {
                return NotFound();
            }
        }
    }
}