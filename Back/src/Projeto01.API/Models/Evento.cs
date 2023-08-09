using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.API.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoa { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }
    }
}