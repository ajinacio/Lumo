using Lumo.Domain;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Image = Xceed.Document.NET.Image;

namespace LumoForm
{
    partial class FrmAvaliacao
    {
        private void btnRelatorio_Click(object sender, EventArgs e)
        {

            FrmRelatorio frm = new FrmRelatorio();
            frm.ShowDialog();
            if (frm.numeroRelat == "") return;

            TextFormat textFormat = new TextFormat();
            RadioButton rdb;
            string texto;
            string cod;
            string nameArq;

            if (usuario.Caminho.Substring(usuario.Caminho.Length - 1, 1) == @"\")
                nameArq = "Relatorio_";
            else
                nameArq = @"\Relatorio_";

            string arq = usuario.Caminho + nameArq + DateTime.Now.Year + DateTime.Now.Month +
                DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute +
                DateTime.Now.Second + DateTime.Now.ToString("fff") + ".docx";
            var document = DocX.Create(arq);

            document.MarginTop = 0;
            document.MarginLeft = 90;
            document.MarginRight = 60;

            Border border = new Border();
            border.Color = Color.Transparent;
            Paragraph parag;

            document.AddHeaders();

            document.DifferentFirstPage = false;
            document.DifferentOddAndEvenPages = false;

            ///// Begin - Header ////////

            var tabCab = document.Headers.Odd.InsertTable(3, 3);

            int lateral = 60;
            int central = 390;

            tabCab.Alignment = Alignment.center;

            tabCab.SetBorder(TableBorderType.Top, border);
            tabCab.SetBorder(TableBorderType.Bottom, border);
            tabCab.SetBorder(TableBorderType.Left, border);
            tabCab.SetBorder(TableBorderType.Right, border);
            tabCab.SetBorder(TableBorderType.InsideH, border);
            tabCab.SetBorder(TableBorderType.InsideV, border);

            tabCab.Rows[0].Cells[0].Width = lateral;
            tabCab.Rows[0].Cells[1].Width = central;
            tabCab.Rows[0].Cells[2].Width = lateral;

            tabCab.Rows[1].Cells[0].Width = lateral;
            tabCab.Rows[1].Cells[1].Width = central;
            tabCab.Rows[1].Cells[2].Width = lateral;

            tabCab.Rows[2].Cells[0].Width = lateral;
            tabCab.Rows[2].Cells[1].Width = central;
            tabCab.Rows[2].Cells[2].Width = lateral;

            tabCab.MergeCellsInColumn(0, 0, 2);
            tabCab.MergeCellsInColumn(2, 0, 2);

            Image i = document.AddImage(@"logo_tce.png");

            Picture p = i.CreatePicture();

            tabCab.Rows[0].Cells[0].Paragraphs[0].AppendPicture(p);

            i = document.AddImage(@"logo_diceti.jpg");

            p = i.CreatePicture();

            tabCab.Rows[0].Cells[2].Paragraphs[0].AppendPicture(p);
            tabCab.Rows[0].Cells[2].Paragraphs[0].Alignment = Alignment.right;

            texto = config.Entidade.ToUpper() + "    ";
            tabCab.Rows[0].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12B);
            tabCab.Rows[0].Cells[1].VerticalAlignment = VerticalAlignment.Center;
            tabCab.Rows[0].Cells[1].Paragraphs[0].Alignment = Alignment.center;

            texto = "Secretaria Geral de Controle Externo    ";
            tabCab.Rows[1].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12B);
            tabCab.Rows[1].Cells[1].Paragraphs[0].Alignment = Alignment.center;
            tabCab.Rows[1].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            texto = config.Setor + "    ";
            tabCab.Rows[2].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12B);
            tabCab.Rows[2].Cells[1].Paragraphs[0].Alignment = Alignment.right;
            tabCab.Rows[2].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            //////////  End - Header /////////////

            document.InsertParagraph();

            var tabBody = document.InsertTable(3, 2);

            tabBody.Rows[0].Cells[0].Width = 40;
            tabBody.Rows[1].Cells[0].Width = 40;
            tabBody.Rows[2].Cells[0].Width = 40;

            tabBody.Rows[0].Cells[1].Width = 370;
            tabBody.Rows[1].Cells[1].Width = 370;
            tabBody.Rows[2].Cells[1].Width = 370;

            texto = "Órgão";
            tabBody.Rows[0].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes12B);

            texto = cbbOrgao.Text;
            tabBody.Rows[0].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12b);

            texto = "Responsável";
            tabBody.Rows[1].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes12B);

            orgaoPessoas = orgaoPessoaApp.listorgao(orgaoApp.oneDescricao(cbbOrgao.Text).Id);
            if (orgaoPessoas.Count > 0)
                texto = pessoaApp.oneId(orgaoPessoas[0].pessoa).Nome;
            else
                texto = "";
            tabBody.Rows[1].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12b);

            texto = "Assunto";
            tabBody.Rows[2].Cells[0].Paragraphs[0].Append(texto, textFormat.FTimes12B);

            texto = "Portal da Transparência";
            tabBody.Rows[2].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12b);

            document.InsertParagraph();
            document.InsertParagraph();

            texto = "Relatório nº " + frm.numeroRelat;
            parag = document.InsertParagraph(texto, false, textFormat.FTimes16B);
            parag.Alignment = Alignment.center;

            document.InsertParagraph();
            document.InsertParagraph();
            texto = "INTRODUÇÃO";
            document.InsertParagraph(texto, false, textFormat.FArialBlack12b);

            document.InsertParagraph();
            texto = "A exigência de transparência no serviço público brasileiro tem como base o princípio " +
              "da publicidade elencado no art. 37 da Constituição Federal de 1988 e vem tecendo sua rede " +
               "normativa desde então. A Lei Complementar 101/2000, que estabelece normas de finanças " +
               "públicas voltadas para a responsabilidade na gestão fiscal, já estabelece no § 1º. do " +
               "art. 1º, que a responsabilidade na gestão fiscal pressupõe a ação planejada e transparente. " +
               "A Lei Complementar 131/2009, determina a disponibilização, em tempo real, de informações " +
               "pormenorizadas sobre a execução orçamentária e financeira dos entes da federação.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            texto = "Assim sendo, tempo real, pressupõe-se, dentro do atual estado da arte, sítio eletrônico " +
                "ou portal de transparência. Desta forma, a Lei 12.527/2011 regulamenta o acesso a informações " +
                "previsto no inciso XXXIII do art. 5º , no inciso II do § 3º do art. 37 e no § 2º do art. 216 " +
                "da Constituição Federal e por conseguinte, também regula a instituição de Portal da " +
                "Transparência dos Órgãos Públicos.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            texto = "Entretanto, para assegurar o acesso à informação por parte do cidadão e da sociedade é " +
                "importante investigar a aderência e adequação desses portais eletrônicos a luz da legislação " +
                "aplicável.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            texto = "Desta forma, espera-se que a presente inspeção atinja o objetivo de melhorar os controles, " +
                "tanto internos como externos, bem como contribuir para a observância do princípio da " +
                "Transparência nos Portais da Administração Pública Estadual e Municipal. ";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            document.InsertParagraph();
            texto = "METODOLOGIA";
            document.InsertParagraph(texto, false, textFormat.FArialBlack12b);

            document.InsertParagraph();

            texto = "O presente é gerado de forma automatizada por sistema informatizado desenvolvido no próprio " +
                "âmbito da DICETI, baseado na cartilha “Escala Brasil Transparente” da Controladoria Geral da " +
                "União – CGU, com adaptações.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            texto = "Abordamos nesse relatório os itens abaixo, classificando-os como cumpridos ou não cumpridos, " +
                "aos quais se atribui uma nota conforme a gravidade:";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            //document.InsertParagraph();

            var tabAvalicao = document.InsertTable(1, 3);

            tabAvalicao.SetBorder(TableBorderType.Top, border);
            tabAvalicao.SetBorder(TableBorderType.Bottom, border);
            tabAvalicao.SetBorder(TableBorderType.Left, border);
            tabAvalicao.SetBorder(TableBorderType.Right, border);
            tabAvalicao.SetBorder(TableBorderType.InsideH, border);
            tabAvalicao.SetBorder(TableBorderType.InsideV, border);

            tabAvalicao.Alignment = Alignment.center;

            tabAvalicao.Rows[0].Cells[0].Width = 20;
            tabAvalicao.Rows[0].Cells[1].Width = 200;
            tabAvalicao.Rows[0].Cells[2].Width = 40;

            int nrow;
            int ct = 0;
            int avaliado = 0;
            int total = 0;
            double perc = 0;
            litem = itemApp.listAllCodigo();
            foreach (Item it in litem)
            {
                tabAvalicao.InsertRow();
                nrow = tabAvalicao.RowCount - 1;
                tabAvalicao.Rows[nrow].Cells[0].Width = 20;
                tabAvalicao.Rows[nrow].Cells[1].Width = 200;
                tabAvalicao.Rows[nrow].Cells[2].Width = 40;
                if (it.Nivel == 1)
                    tabAvalicao.Rows[nrow].Cells[1].Paragraphs[0].Append(it.Descricao, textFormat.FTimes12B);
                else
                {
                    ct += 1;
                    tabAvalicao.Rows[nrow].Cells[0].Paragraphs[0].Append(ct.ToString(), textFormat.FTimes12b);
                    tabAvalicao.Rows[nrow].Cells[0].Paragraphs[0].Alignment = Alignment.right;

                    tabAvalicao.Rows[nrow].Cells[1].Paragraphs[0].Append(it.Descricao, textFormat.FTimes12b);
                    tabAvalicao.Rows[nrow].Cells[1].Paragraphs[0].Alignment = Alignment.left;

                    cod = "rdb" + it.Codigo.Substring(0, 2) + it.Codigo.Substring(3, 2) + "Sim";
                    rdb = this.Controls.Find(cod, true)[0] as RadioButton;

                    if (rdb.Checked)
                    {
                        tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Append(it.Pontos.ToString(), textFormat.FTimes12b);
                        avaliado += it.Pontos;
                    }
                    else
                        tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Append("0", textFormat.FTimes12b);

                    total += it.Pontos;
                    tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Alignment = Alignment.right;
                }
            }

            tabAvalicao.InsertRow();
            nrow = tabAvalicao.RowCount - 1;
            tabAvalicao.Rows[nrow].Cells[0].Width = 20;
            tabAvalicao.Rows[nrow].Cells[1].Width = 200;
            tabAvalicao.Rows[nrow].Cells[2].Width = 40;
            tabAvalicao.Rows[nrow].Cells[1].Paragraphs[0].Append("Total", textFormat.FTimes12B);
            tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Append(avaliado.ToString(), textFormat.FTimes12b);
            tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Alignment = Alignment.right;

            tabAvalicao.InsertRow();
            nrow = tabAvalicao.RowCount - 1;
            tabAvalicao.Rows[nrow].Cells[0].Width = 20;
            tabAvalicao.Rows[nrow].Cells[1].Width = 200;
            tabAvalicao.Rows[nrow].Cells[2].Width = 40;
            perc = (Convert.ToDouble(avaliado) / Convert.ToDouble(total));
            tabAvalicao.Rows[nrow].Cells[1].Paragraphs[0].Append("Percentual", textFormat.FTimes12B);
            tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Append(perc.ToString("P"), textFormat.FTimes12b);
            tabAvalicao.Rows[nrow].Cells[2].Paragraphs[0].Alignment = Alignment.right;

            document.InsertParagraph();

            texto = "Os itens marcados com valor de 300 pontos são essenciais e indispensáveis, de maneira que sua ausência " +
                "no portal da transparência será considerado grave, não sendo compensado por outros itens de menor pontuação.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;
            document.InsertParagraph();
            document.InsertParagraph();
            texto = "ANÁLISE";
            document.InsertParagraph(texto, false, textFormat.FArialBlack12b);
            document.InsertParagraph();

            texto = "Na análise do portal da Transparência conforme critérios acima, a ";
            texto += cbbOrgao.Text;
            texto += ", obteve " + avaliado.ToString() + " pontos, equivalente a ";
            texto += perc.ToString("P") + ". Assim sendo, consideramos que a ";
            texto += cbbOrgao.Text;
            texto += " não está respeitando a Legislação de Acesso à Informação. ";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            document.InsertParagraph();
            texto = "CONCLUSÃO";
            document.InsertParagraph(texto, false, textFormat.FArialBlack12b);
            document.InsertParagraph();
            texto = "Assim sendo, sugerimos ao Nobre Secretário Geral de Controle Externo solicitar " +
                "abertura de processo de REPRESENTAÇÃO nos termos do art. 208 da Resolução TCE nº " +
                "04/2002, contra a " + cbbOrgao.Text + ", na pessoa ";

            orgaoPessoas = orgaoPessoaApp.listorgao(orgaoApp.oneDescricao(cbbOrgao.Text).Id);
            if (orgaoPessoas.Count > 0)
            {
                pessoa = pessoaApp.oneId(orgaoPessoas[0].pessoa);

                if (pessoa.Genero == "M")
                    texto += "do Sr. ";
                else
                    texto += "da Sra. ";
                texto += pessoa.Nome + ", ";
                texto += pessoa.Titulo;
            }

            texto += ", para a devida apuração dos fatos e atendimento aos princípios do contraditório e " +
                "da ampla defesa, com fulcro no receio de lesão ao erário, nos termos do inciso VIII do " +
                "art. 10 da Lei 8.429/1992.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;
            parag.IndentationFirstLine = 40;

            document.InsertParagraph();
            document.InsertParagraph();
            texto = "É o Relatório.";
            document.InsertParagraph(texto, false, textFormat.FTimes12B);

            document.InsertParagraph();
            document.InsertParagraph();
            texto = config.Setor.ToUpper() + " DO " + config.Entidade.ToUpper();
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12B);

            texto = ", em Manaus, " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") +
                " de " + DateTime.Now.Year + ".";
            parag.Append(texto, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;

            for (int k = 0; k < 5; k++)
                document.InsertParagraph();

            texto = usuario.Nome;
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.center;

            texto = usuario.Cargo;
            parag = document.InsertParagraph(texto, false, textFormat.FTimes10b);
            parag.Alignment = Alignment.center;

            for (int k = 0; k < 4; k++)
                document.InsertParagraph();

            texto = config.TitularSetor;
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.Alignment = Alignment.center;

            texto = "Diretor da " + config.SiglaSetor;
            parag = document.InsertParagraph(texto, false, textFormat.FTimes10b);
            parag.Alignment = Alignment.center;

            try
            {
                document.Save();
            }
            catch { }

            Process.Start("WINWORD.EXE", arq);

        }
    }
}
