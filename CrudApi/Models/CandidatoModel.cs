using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Models
{
    public class CandidatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do candidato")]//DataAnnotations 
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Celular do candidato")]
        [Phone(ErrorMessage = "Informe um nº de telefone válido!")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Digite o Email do candidato")]
        [EmailAddress(ErrorMessage = "Informe um Email válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe os Conhecimentos que o candidato possui")]
        public string Conhecimento { get; set; }

    }
}
