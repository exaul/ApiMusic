using ApiMusic.Data;
using ApiMusic.DTO;
using ApiMusic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext dbContext; 
        
        public SongsController (ApiDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return dbContext.Songs;
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id no debe de ser 0");
            }
            Song song = dbContext.Songs.Find(id);
            if (song == null)
            {
                return NotFound("La musica no existe");
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] SongDTO newSong)
        {
            if (newSong == null)
            {
                return BadRequest("No se admiten datos vacíos");
            }
            if ((string.IsNullOrEmpty(newSong.Title)) || string.IsNullOrEmpty(newSong.Language))
            {
                return BadRequest("los campos son obligatorios");
            }
            var song = new Song
            {
                TiTle = newSong.Title,
                Language = newSong.Language
            };
            dbContext.Songs.Add(song);
            dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Song updatedSong)
        {
            if (updatedSong == null)
            {
                return BadRequest("Ingresaste datos nulos");
            }

            var existingSong = dbContext.Songs.Find(id);

            if (existingSong == null)
            {
                return BadRequest("No existe su canción ");
            }


            existingSong.TiTle = updatedSong.TiTle;
            existingSong.Language = updatedSong.Language;

            dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var songToDelete = dbContext.Songs.Find(id);
            if (songToDelete != null)
            {
                dbContext.Songs.Remove(songToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
