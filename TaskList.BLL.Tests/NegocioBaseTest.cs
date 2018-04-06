using AutoMoq;
using System;
using System.Linq;

namespace TaskList.BLL.Test
{
    public abstract class NegocioBaseTest
    {
        protected readonly AutoMoqer mocker;

        protected NegocioBaseTest()
        {
            mocker = new AutoMoqer();
        }

        protected string GerarStringMaximoCaracteres(int numeroCaracteres)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, numeroCaracteres)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
