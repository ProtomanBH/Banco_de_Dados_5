using Banco_de_Dados_5.Server.Data;
using Banco_de_Dados_5.Server.Models;
using Banco_de_Dados_5.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_de_Dados_5.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public PessoaController(ILogger<PessoaController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        /*
        public PessoaController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        */
        [HttpGet]
        public IActionResult GetPessoas()
        {
            List<Pessoa> Pessoas = _applicationDbContext.Pessoas.Where(p => p.Nome.StartsWith("N")).ToList();

            return Ok(Pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPessoaById(int id)
        {
            Pessoa Pessoa = _applicationDbContext.Pessoas.FirstOrDefault(p => p.Id == id);

            return Ok(Pessoa);
        }

        [HttpPost]
        public IActionResult AddPessoa(Pessoa pessoa)
        {
            try
            {
                _applicationDbContext.Pessoas.Add(pessoa);
                _applicationDbContext.SaveChanges();

                return Ok();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }        

        [HttpPut]
        public IActionResult UpdPessoa(Pessoa pessoa)
        {
            int id = pessoa.Id;
            Pessoa PessoaNoDb = _applicationDbContext.Pessoas.FirstOrDefault(p => p.Id == id);

            if (PessoaNoDb == null)
                return NotFound("Pessoa não encontrada.");

            PessoaNoDb.CPF = pessoa.CPF;
            //PessoaNoDb.DataNascimento = pessoa.DataNascimento;
            PessoaNoDb.Nome = pessoa.Nome;

            //Salva
            _applicationDbContext.SaveChanges();
            return Ok("Encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult DelPessoa(int id)
        {
            Pessoa pessoa = _applicationDbContext.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            _applicationDbContext.Pessoas.Remove(pessoa);
            _applicationDbContext.SaveChanges();

            return Ok($"A pessoa {pessoa.Nome} foi deletada com sucesso.");
        }

    }
}
