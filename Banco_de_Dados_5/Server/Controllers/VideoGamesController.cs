using Banco_de_Dados_5.Server.Data;
using Banco_de_Dados_5.Server.Models;
using Banco_de_Dados_5.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_de_Dados_5.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class VideoGamesController : ControllerBase
    {
    
        private readonly ApplicationDbContext _applicationDbContext;

        public VideoGamesController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetVideoGames()
        {
            List<VideoGames> VideoGames = _applicationDbContext.Video_Games.Where(p => p.Nome.StartsWith("N")).ToList();

            return Ok(VideoGames);
        }

        [HttpGet("{id}")]
        public IActionResult GetVideoGamesById(int id)
        {
            VideoGames VideoGame = _applicationDbContext.Video_Games.FirstOrDefault(p => p.Id == id);

            return Ok(VideoGame);
        }

        [HttpPost]
        public IActionResult AddVideoGame(VideoGames VideoGame) { 

            try
            {
                _applicationDbContext.Video_Games.Add(VideoGame);
                _applicationDbContext.SaveChanges();

                return Ok(VideoGame);
            }

            catch (Exception e)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdVideoGame([FromQuery] int id, [FromBody] VideoGames VideoGame)
        {
            VideoGames VideoGameNoDb = _applicationDbContext.Video_Games.FirstOrDefault(p => p.Id == id);

            if (VideoGameNoDb == null)
                return NotFound("Video Game não encontrado.");

            VideoGameNoDb.Marca = VideoGame.Marca;
            VideoGameNoDb.AnoLancamento = VideoGame.AnoLancamento;
            VideoGameNoDb.Nome = VideoGame.Nome;

            //Salva
            _applicationDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideoGame(int id)
        {
            VideoGames VideoGame = _applicationDbContext.Video_Games.FirstOrDefault(p => p.Id == id);

            if (VideoGame == null)
                return NotFound("Video Game não encontrado.");

            _applicationDbContext.Video_Games.Remove(VideoGame);
            _applicationDbContext.SaveChanges();

            return Ok($"A pessoa {VideoGame.Nome} foi deletada com sucesso.");
        }

    }
}

