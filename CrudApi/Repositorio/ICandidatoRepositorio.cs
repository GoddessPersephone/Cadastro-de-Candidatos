using CrudApi.Models;
using System.Collections.Generic;

namespace CrudApi.Repositorio
{
    public interface ICandidatoRepositorio
    {
        CandidatoModel ListarPorId(int id);

        List<CandidatoModel> BuscarTodos();

        CandidatoModel Adicionar(CandidatoModel candidato);

        CandidatoModel Atualizar(CandidatoModel candidato);

        bool Apagar(int id);
    }
}
