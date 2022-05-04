using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaExercicio2
{
    internal class QuestoesRepository
    {
        public Questoes[] Questoes;

        public void Initialize() {
            // As perguntas são retiradas da string <questao> sendo o formato:
            //                                      pergunta | alternativaA | alternativaB | alternativaC | alternativaD | resposta(sendo 0 -> A, 1 -> B e assim por diante) • <próxima pergunta>
            string questao = "O que é C#? | Linguagem Orientada a Objetos | Markdown | Uma língua extrangeira | Dó bemol | 0 •" +
                "Qual a cor do cavalo branco de napoleão? | Preto | Pedro | Cavalo | Branco??? kkk | 3 •" +
                "Quanto é doi mais a quinta parte de 60? | 2/5 | 14 | 62/5 | Nda | 1 •" +
                "Com quantos anos alguém se torna maior de idade no Brasil? | 18 | 19 | 17 | 16 | 0";

            string[,] qDividida = SplitText(questao);

            Questoes[] questoes = new Questoes[qDividida.GetLength(0)];

            for (int i = 0; i < questoes.Length; i++)
            {
                questoes[i] = new Questoes(qDividida[i, 0], new string[] { qDividida[i, 1], qDividida[i, 2], qDividida[i, 3], qDividida[i, 4] }, int.Parse(qDividida[i, 5]));
            }

            Questoes = questoes;
        }

        public string[,] SplitText(string text)
        {
            string[] firstSplit = text.Split('•');
            string[] secondSplit;
            string[,] splitedText = new string[firstSplit.Length, 6];

            for (int i = 0; i < firstSplit.Length; i++)
            {
                secondSplit = firstSplit[i].Split('|');
                for (int j = 0; j < secondSplit.Length; j++)
                {
                    splitedText[i, j] = secondSplit[j].Trim();
                }
            }

            return splitedText;
        }
    }
}
