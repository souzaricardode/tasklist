using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public static class ButtonHelper
    {
        /// <summary>
        ///  (Botão para salvar tarefa) - Extensão para criar um botão html com tooltips e classes baseadas no padrão do projeto.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="labelText"></param>
        /// <param name="name"></param>
        /// <param name="adicionalCss"></param>
        /// <returns></returns>
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string labelText, string name = "btnSubmit", string adicionalCss = "")
        {
            string html = string.Format("<button data-toggle=\"tooltip\" title=\"{0}\" id={2} type = \"submit\" class=\"btn btn-primary {1}\"><span class=\"glyphicon glyphicon-floppy-disk\"></span> {0}</button>",
                                        labelText, adicionalCss, name);
            return MvcHtmlString.Create(html);
        }

        /// <summary>
        ///  (Botão para excluir tarefa) - Extensão para criar um botão html com tooltips e classes baseadas no padrão do projeto.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="labelText"></param>
        /// <param name="action"></param>
        /// <param name="idValue"></param>
        /// <param name="idName"></param>
        /// <param name="adicionalCss"></param>
        /// <returns></returns>
        public static MvcHtmlString DeleteButton(this HtmlHelper htmlHelper, string labelText, string action, long idValue, string idName = "id", string adicionalCss = "")
        {
            string html = string.Format("<a data-toggle=\"tooltip\" title=\"Excluir\" class=\"btn btn-danger {4}\" href = \"{0}?{1}={2}\"><span class=\"glyphicon glyphicon-trash\"></span> {3}</a>",
                                        action, idName, idValue, labelText, adicionalCss);

            return MvcHtmlString.Create(html);
        }

        /// <summary>
        ///  (Botão para concluir tarefa) - Extensão para criar um botão html com tooltips e classes baseadas no padrão do projeto.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="labelText"></param>
        /// <param name="action"></param>
        /// <param name="idValue"></param>
        /// <param name="idName"></param>
        /// <param name="adicionalCss"></param>
        /// <returns></returns>
        public static MvcHtmlString ConcludeButton(this HtmlHelper htmlHelper, string labelText, string action, long idValue, string idName = "id", string adicionalCss = "")
        {
            string html = string.Format("<a data-toggle=\"tooltip\" title=\"Concluir\" class=\"btn btn-success btn-flat {4}\" href = \"{0}?{1}={2}\"><span class=\"glyphicon glyphicon-ok-circle\"></span> {3}</a>",
                                        action, idName, idValue, labelText, adicionalCss);

            return MvcHtmlString.Create(html);
        }

        /// <summary>
        ///  (Botão para Reabrir Tarefa) - Extensão para criar um botão html com tooltips e classes baseadas no padrão do projeto.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="labelText"></param>
        /// <param name="action"></param>
        /// <param name="idValue"></param>
        /// <param name="idName"></param>
        /// <param name="adicionalCss"></param>
        /// <returns></returns>
        public static MvcHtmlString ReopenButton(this HtmlHelper htmlHelper, string labelText, string action, long idValue, string idName = "id", string adicionalCss = "")
        {
            string html = string.Format("<a data-toggle=\"tooltip\" title=\"Reabrir\" class=\"btn btn-danger btn-flat {4}\" href = \"{0}?{1}={2}\"><span class=\"glyphicon glyphicon-remove-circle\"></span> {3}</a>",
                                        action, idName, idValue, labelText, adicionalCss);

            return MvcHtmlString.Create(html);
        }

        /// <summary>
        ///  (Botão para editar tarefa) - Extensão para criar um botão html com tooltips e classes baseadas no padrão do projeto.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="labelText"></param>
        /// <param name="action"></param>
        /// <param name="idValue"></param>
        /// <param name="idName"></param>
        /// <param name="adicionalCss"></param>
        /// <returns></returns>
        public static MvcHtmlString EditButton(this HtmlHelper htmlHelper, string labelText, string action, long idValue, string idName = "id", string adicionalCss = "")
        {
            string html = string.Format("<a data-toggle=\"tooltip\" title=\"Editar\" class=\"btn btn-warning btn-flat {4}\" href = \"{0}?{1}={2}\"><span class=\"glyphicon glyphicon-pencil\"></span> {3}</a>",
                                        action, idName, idValue, labelText, adicionalCss);

            return MvcHtmlString.Create(html);
        }
    }
}
