using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaExercicio2
{
    public partial class Form1 : Form
    {
        public int QuestaoAtual = 0;
        public double Acertos = 0;
        QuestoesRepository q = new QuestoesRepository();
        bool[] QuestoesChecked;
        int[] AlternativasSelecionadas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            q.Initialize();

            QuestoesChecked = new bool[q.Questoes.Length];
            AlternativasSelecionadas = new int[q.Questoes.Length];

            for (int i = 0; i < q.Questoes.Length; i++)
            {
                QuestoesChecked[i] = false;
            }

            QuestoesChecked[0] = true;

            lblQuestao.Text = $"Questão {QuestaoAtual + 1}";
            lblPergunta.Text = q.Questoes[QuestaoAtual].Questao;
            radioButton1.Text = q.Questoes[QuestaoAtual].Alternativas[0];
            radioButton2.Text = q.Questoes[QuestaoAtual].Alternativas[1];
            radioButton3.Text = q.Questoes[QuestaoAtual].Alternativas[2];
            radioButton4.Text = q.Questoes[QuestaoAtual].Alternativas[3];

            buttonBack.Text = "Voltar";
            buttonBack.Visible = false;
            buttonNext.Text = "Próximo";
            buttonFinalizar.Visible = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            AtualizaQuestao(1);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AtualizaQuestao(-1);
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            AtualizaQuestao(0);

            ContabilizaAcertos();
            q.Initialize();

            double TamanhoArray = q.Questoes.Length;

            panel2.Visible = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            buttonFinalizar.Visible = false;

            lblAcertos.Text = $"{Acertos} / {TamanhoArray}";
            lblNotaFinal.Text = $"{(Acertos / TamanhoArray) * 10:F2} / 10";
        }

        public void AtualizaQuestao(int incremento)
        {
            int questaoAtual = QuestaoAtual;

            AdicionaSelecao(questaoAtual);

            QuestaoAtual += incremento;
            questaoAtual = QuestaoAtual;

            if (!QuestoesChecked[questaoAtual])
            {
                radioButton1.Checked = true;
            }
            else
            {
                switch (AlternativasSelecionadas[questaoAtual])
                {
                    case 0:
                        radioButton1.Checked = true;
                        break;
                    case 1:
                        radioButton2.Checked = true;
                        break;
                    case 2:
                        radioButton3.Checked = true;
                        break;
                    case 3:
                        radioButton4.Checked = true;
                        break;
                }
            }
            
            QuestoesChecked[questaoAtual] = true;

            q.Initialize();

            lblQuestao.Text = $"Questão {questaoAtual + 1}";
            lblPergunta.Text = q.Questoes[questaoAtual].Questao;
            radioButton1.Text = q.Questoes[questaoAtual].Alternativas[0];
            radioButton2.Text = q.Questoes[questaoAtual].Alternativas[1];
            radioButton3.Text = q.Questoes[questaoAtual].Alternativas[2];
            radioButton4.Text = q.Questoes[questaoAtual].Alternativas[3];

            bool ultimo = false;

            if (lblPergunta.Text == q.Questoes.Last().Questao)
            {
                ultimo = true;
            }

            if (lblPergunta.Text == q.Questoes[0].Questao || ultimo)
            {
                if (lblPergunta.Text == q.Questoes[0].Questao)
                {
                    buttonBack.Visible = false;

                }
                else if (ultimo && panel2.Visible)
                {
                    buttonFinalizar.Visible = false;
                    buttonNext.Visible = false;
                }
                else
                {
                    buttonFinalizar.Visible = true;
                    buttonNext.Visible = false;
                }
            }
            else
            {
                buttonBack.Visible = true;
                buttonNext.Visible = true;
                buttonFinalizar.Visible = false;
            }
        }

        public void ContabilizaAcertos()
        {
            for (int i = 0; i < AlternativasSelecionadas.Length; i++)
            {
                if (AlternativasSelecionadas[i] == q.Questoes[i].AlternativaCorreta)
                {
                    Acertos++;
                }
            }
        }

        public void AdicionaSelecao(int questaoAtual)
        {
            bool[] opcoes = new bool[] { radioButton1.Checked, radioButton2.Checked, radioButton3.Checked, radioButton4.Checked };

            for (int i = 0; i < opcoes.Length; i++)
            {
                if (opcoes[i])
                {
                    AlternativasSelecionadas[questaoAtual] = i;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
