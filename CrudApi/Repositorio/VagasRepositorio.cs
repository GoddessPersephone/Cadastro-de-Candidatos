using CrudApi.Data;
using CrudApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace CrudApi.Repositorio
{
    public class VagasRepositorio : IVagasRepositorio
    {
        //Construtor do repositório, para injetar o contexto

        private readonly BancoContext _bancoContext; //Extraindo variavel do construtor para usar nos metodos
        public VagasRepositorio(BancoContext bancoContext)//injetando o banco de dados
        {
            _bancoContext = bancoContext; //injeção de dependência, referenciada na startup.cs

        }

        public VagasModel ListarPorId(int id)
        {
            return _bancoContext.Vagas.FirstOrDefault(x => x.Id == id);
        }

        public List<VagasModel> BuscarTodos()
        {
            return _bancoContext.Vagas.ToList();
        }

        //gravando no banco de dados os novas vagas
        public VagasModel Adicionar(VagasModel vaga)
        {
            _bancoContext.Vagas.Add(vaga);//Banco de dados da tabela vagas adiciona vagas com o metodo "Adicionar"
            _bancoContext.SaveChanges();//Salvando no banco de dados
            return vaga;//Retornando vagas adicionadas
        }

        public VagasModel Atualizar(VagasModel vagas)
        {
            VagasModel vagasDB = ListarPorId(vagas.Id);

            if (vagasDB == null) throw new System.Exception("Não foi possível atualizar a vaga.");

            vagasDB.Vagas = vagas.Vagas;
            vagasDB.Requisitos = vagas.Requisitos;

            _bancoContext.Vagas.Update(vagasDB);
            _bancoContext.SaveChanges();

            return vagasDB;
        }

        public bool Apagar(int id)
        {
            VagasModel vagasDB = ListarPorId(id);

            if (vagasDB == null) throw new System.Exception("Não foi possível deletar a vaga.");

            _bancoContext.Vagas.Remove(vagasDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
