using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeS.BLL;
using TimeS.Model;
using TimeS.Model.ViewModels;

namespace TimeS.Tests.Controllers
{
    [TestClass]
    public class TarefasTest
    {
        private readonly IAtividadeBLL _atividadeBll = new AtividadeBLL();
        [TestMethod]
        public void AddAtividadeComTarefaDeveCriarTarefaNaAtividade()
        {
            // Arrange
            Atividade atividade = _atividadeBll.GetAtividade(1);
            AtividadeViewModel viewAtividade = new AtividadeViewModel()
            {
                Nome = "test",
                Descricao = "teste"
            };
            viewAtividade.Tarefas.Add(new Tarefa()
            {
                Nome = "Testeeeee",
                Descricao = "Esta é uma Tarefa de Teste",
                Inicio = DateTime.Now,
                Entrega = DateTime.Now,
                Status = Status.Andamento,
            });

            // Act
            Atividade novaAtividade = _atividadeBll.EditarAtividade(viewAtividade);

            // Assert
            int IdTarefa = atividade.Tarefas.First().Id;
            int IdNovaTarefa = novaAtividade.Tarefas.First().Id;
            Assert.AreEqual(IdTarefa,IdNovaTarefa);
        }
    }
}
