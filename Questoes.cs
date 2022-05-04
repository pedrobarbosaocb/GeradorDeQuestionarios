using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaExercicio2
{
    internal class Questoes
    {
        public string Questao;
        public string[] Alternativas;
        public int AlternativaCorreta;        

        public Questoes(string questao, string[] alternativas, int alternativaCorreta)
        {
            Questao = questao;
            Alternativas = alternativas;
            AlternativaCorreta = alternativaCorreta;
        }

    }
}
