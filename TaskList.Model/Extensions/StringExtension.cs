using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class StringExtension
    {

        /// <summary>
        /// Verifica se uma string está nula ou vazia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Converte uma string para decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Converte uma string para int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converte uma string para long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return Convert.ToInt64(value);
        }
    }
}