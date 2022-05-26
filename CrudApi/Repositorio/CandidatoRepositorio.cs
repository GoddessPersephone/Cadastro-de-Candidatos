using CrudApi.Data;
using CrudApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace CrudApi.Repositorio
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        //Construtor do repositório, para injetar o contexto

        private readonly BancoContext _bancoContext; //Extraindo variavel do construtor para usar nos metodos
        public CandidatoRepositorio(BancoContext bancoContext)//injetando o banco de dados
        {
            _bancoContext = bancoContext; //injeção de dependência, referenciada na startup.cs

        }

        public CandidatoModel ListarPorId(int id)
        {
            return _bancoContext.Candidatos.FirstOrDefault(x => x.Id == id);
        }

        public List<CandidatoModel> BuscarTodos()
        {
            return _bancoContext.Candidatos.ToList();
        }

        //gravando no banco de dados os novos candidatos
        public CandidatoModel Adicionar(CandidatoModel candidato)
        {
            _bancoContext.Candidatos.Add(candidato);//Banco de dados da tabela candidatos adiciona candidato com o metodo "Adicionar"
            _bancoContext.SaveChanges();//Salvando no banco de dados
            return candidato;//Retornando candidatos adicionados
        }

        public CandidatoModel Atualizar(CandidatoModel candidato)
        {
            CandidatoModel candidatoDB = ListarPorId(candidato.Id);

            if (candidatoDB == null) throw new System.Exception("Não foi possível atualizar o cadastro.");

            candidatoDB.Nome = candidato.Nome;
            candidatoDB.Celular = candidato.Celular;
            candidatoDB.Email = candidato.Email;
            candidatoDB.Conhecimento = candidato.Conhecimento;

            _bancoContext.Candidatos.Update(candidatoDB);
            _bancoContext.SaveChanges();

            return candidatoDB;
        }

        public bool Apagar(int id)
        {
            CandidatoModel candidatoDB = ListarPorId(id);

            if (candidatoDB == null) throw new System.Exception("Não foi possível deletar o cadastro.");

            _bancoContext.Candidatos.Remove(candidatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
