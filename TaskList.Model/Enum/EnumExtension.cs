using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class EnumExtension
    {
        /// <summary>
        /// Retorna a descrição informada na enumeração através do "DescriptionAttribute".
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Descricao(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute),
                                                false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return value.ToString();
                }
            }
            catch
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Retornar o valor informado na enumeração (de fato por padrão enumeração são valores inteiros)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short Id(this Enum value)
        {
            return Convert.ToInt16(value);
        }
   }
}