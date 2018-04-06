using FluentValidation;
using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;
using TaskList.Model.Model;
using TaskList.Model.Resources;

namespace TaskList.BLL.Validacao
{
    public class TarefaValidacao : BaseValidacao<Tarefa>
    {
        protected void ValidarDescricao(ITarefaRepositorio repository)
        {
            RuleFor(x => x.Descricao)
              .MaximumLength(ColumnLength.Descricao)
              .WithMessage(x => string.Format(ResourceValidacoes.MAXIMO_CARACTERES, new object[] { ResourceCampos.TAREFA_DESCRICAO, ColumnLength.Descricao }));
        }
    }
}
