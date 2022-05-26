using CrudApi.Models;
using System.Collections.Generic;

namespace CrudApi.Repositorio
{
    public interface IVagasRepositorio
    {
        VagasModel ListarPorId(int id);

        List<VagasModel> BuscarTodos();

        VagasModel Adicionar(VagasModel vagas);

        VagasModel Atualizar(VagasModel vagas);

        bool Apagar(int id);
    }
}
