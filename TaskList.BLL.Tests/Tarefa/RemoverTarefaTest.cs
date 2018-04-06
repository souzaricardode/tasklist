using TaskList.BLL.Test;
using TaskList.Model.Model;
using Xunit;
using FluentAssertions;
using TaskList.Model.Excecoes;

namespace TaskList.BLL.Tests
{
    public class RemoverTarefaTest : NegocioBaseTest
    {
        private readonly TarefaNegocio negocio;

        public RemoverTarefaTest()
        {
            negocio = mocker.Resolve<TarefaNegocio>();
        }

        private Tarefa GerarEntidade()
        {
            var diretoria = new Tarefa
            {
                Id = 1,
                Descricao = "Tarefa 1",
            };
            return diretoria;
        }

        [Fact]
        public void AdicionarSucesso()
        {
            var entidade = GerarEntidade();
            negocio
                .Invoking(x => x.Remover(entidade))
                .Should()
                .NotThrow<ValidacaoException>();
        }

        [Fact]
        public void AdicionarErro()
        {
            var entidade = GerarEntidade();
            negocio
                .Invoking(x => x.Remover(entidade))
                .Should()
                .NotThrow<ValidacaoException>();
        }
    }
}
