using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOAuth2.comum.Extensions
{
    public static class ObjectsExtension
    {
        public static T CastX<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }

        public static List<T> SkipX<T>(this IEnumerable<T> lista, int pagina, int quantidadePorPagina)
        {
            if (quantidadePorPagina > 0)
            {
                return lista.Skip((pagina - 1) * quantidadePorPagina).Take(quantidadePorPagina).ToList();
            }
            else
            {
                return lista.ToList();
            }
        }

        public static decimal? AbsNegative(this decimal? valor, int tipo)
        {
            return (valor != null) ? valor * (tipo == 1 ? -1 : 1) : null;
        }

        public static decimal AbsNegative(this decimal valor, int tipo)
        {
            return valor * (tipo == 1 ? -1 : 1);
        }

        public static int SubIndexSplit(this string valor, int index)
        {
            var i = valor.Split(',');
            return Convert.ToInt32(i[index]);
        }

    }
}