using System.Collections.Generic;
using System.Linq;
using TimeS.DAL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.BLL
{
    public class AtividadeBLL : IAtividadeBLL
    {
        private readonly IAtividadeDAL _atividadeDal = new AtividadeDAL();
        public List<Atividade> GetAtividades()
        {
            return _atividadeDal.GetAtividades();
        }

        public Atividade AddAtividade(AtividadeViewModel atividade)
        {
            IUsuarioDAL usuarioDal = new UsuarioDAL();
            var tarefas = atividade.Tarefas != null ? atividade.Tarefas.ToList() : null;
            Atividade novaAtividade = new Atividade()
            {
                Nome = atividade.Nome,
                Descricao = atividade.Descricao,
                Responsavel_Id = atividade.Responsavel_Id,
                Criador_Id = atividade.Criador_Id,
                Tipo_Id = atividade.Tipo_Id,
                Tarefas = tarefas
            };
            if(atividade.Participantes != null)
                atividade.Participantes.ToList()
                    .ForEach(
                    p => novaAtividade.Participantes.Add(usuarioDal.GetUsuario(p))
                    );
            return _atividadeDal.AddAtividade(novaAtividade);
        }

        public Atividade EditarAtividade(AtividadeViewModel atividade)
        {
            IUsuarioDAL usuarioDal = new UsuarioDAL();
            Atividade novaAtividade = GetAtividade(atividade.Id);
            novaAtividade.Nome = atividade.Nome;
            novaAtividade.Descricao = atividade.Descricao;
            novaAtividade.Responsavel_Id = atividade.Responsavel_Id;
            novaAtividade.Criador_Id = atividade.Criador_Id;
            novaAtividade.Tipo_Id = atividade.Tipo_Id;
            if (atividade.Participantes != null)
                atividade.Participantes.ToList()
                    .ForEach(
                    p => novaAtividade.Participantes.Add(usuarioDal.GetUsuario(p))
                    );
            if (atividade.Tarefas != null)
                novaAtividade.Tarefas = atividade.Tarefas;
            return _atividadeDal.EditarAtividade(novaAtividade);
        }

        public bool DeleteAtividade(int id)
        {
            return _atividadeDal.DeleteAtividade(id);
        }

        public Atividade GetAtividade(int id)
        {
            return _atividadeDal.GetAtividade(id);
        }
    }
}
