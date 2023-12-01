using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Palavras
{
    internal class ClasseDePalavras
    {
        public static Dictionary<string, string> ArrayDePalavras()
        {
            Dictionary<string, string> listaDePalavras = new Dictionary<string, string>()
            {
                {"Melancia", "Frutas"},
                {"Manga", "Frutas"},
                {"Jabuticaba", "Frutas"},
                {"Morango", "Frutas"},
                {"Banana", "Frutas"},
                {"Lasanha", "Comidas"},
                {"Feijoada", "Comidas"},
                {"Strogonoff", "Comidas"},
                {"Moqueca", "Comidas"},
                {"Sopa", "Comidas"},
                {"Medicina", "Carreiras"},
                {"Tecnologia", "Carreiras"},
                {"Engenharia", "Carreiras"},
                {"Pedagogia", "Carreiras"},
                {"Contabilidade", "Carreiras"},
                {"Amazonas", "Estados"},
                {"Bahia", "Estados"},
                {"Tocantins", "Estados"},
                {"Pernambuco", "Estados"},
                {"Sergipe", "Estados"}
            };

            return listaDePalavras;
        }
    }
}
