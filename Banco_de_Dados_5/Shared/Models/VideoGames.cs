using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_de_Dados_5.Shared.Models
{
    public class VideoGames
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        //public DateTime DataDoRegistro { get; set; }
        public string Marca { get; set; }
        public int? AnoLancamento { get; set; }
        [ForeignKey("Pessoa")]
        public int Id_Pessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
