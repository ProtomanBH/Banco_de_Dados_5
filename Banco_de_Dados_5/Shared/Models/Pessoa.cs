using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_de_Dados_5.Shared.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é um campo obrigatório.")]
        [StringLength(50)]
        public string Nome { get; set; }

        
        [Required(ErrorMessage ="O CPF é um campo obrigatório.")]
        public string CPF { get; set; }


        public List<VideoGames> VideoGames { get; set; }
    }
}
