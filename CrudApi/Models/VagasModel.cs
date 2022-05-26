using CrudApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Models
{
    public class VagasModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a vaga disponível")]
        public VagasEnum Vagas { get; set; }
        [Required(ErrorMessage = "Informe os requisitos para a vaga")]
        public string Requisitos { get; set; }
        
    }
}
