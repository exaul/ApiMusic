using ApiMusic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> _songs = new List<Song> {

              new Song
            {
                Id = 1,
                TiTle = "Kids with Guns",
                Language = "English"
            },
            new Song
            {
                Id = 2,
                TiTle = "Karma",
                Language = "English"
            },
            new Song
            {
                Id = 3,
                TiTle = "Iglesia",
                Language = "Español"
            },

            new Song
            {
                Id = 4,
                TiTle = "мой мармеладный",
                Language = "Ruso"
            }

        };

        [HttpGet]//Mediante este controlador podemos hacer la petición
        public IEnumerable<Song> GetAllSongs()
        {
            return _songs;
        }

        [HttpPost]
        public IActionResult SaveSong([FromBody] Song newSong) 
        {
            _songs.Add(newSong);
            return Ok();
        }

    }
}
