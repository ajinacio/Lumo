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
        private void btnRepres_Click(object sender, EventArgs e)
        {
            TextFormat textFormat = new TextFormat();
            RadioButton rdb;
            string texto;
            string cod;
            string nameArq;

            if (usuario.Caminho.Substring(usuario.Caminho.Length - 1, 1) == @"\")
                nameArq = "Minuta_de_Representacao_";
            else
                nameArq = @"\Minuta_de_Representacao_";

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

            texto = "TRIBUNAL DE CONTAS DO ESTADO DO AMAZONAS    ";
            tabCab.Rows[0].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12B);
            tabCab.Rows[0].Cells[1].VerticalAlignment = VerticalAlignment.Center;
            tabCab.Rows[0].Cells[1].Paragraphs[0].Alignment = Alignment.center;

            texto = "Secretaria Geral de Controle Externo    ";
            tabCab.Rows[1].Cells[1].Paragraphs[0].Append(texto, textFormat.FTimes12B);
            tabCab.Rows[1].Cells[1].Paragraphs[0].Alignment = Alignment.center;
            tabCab.Rows[1].Cells[1].VerticalAlignment = VerticalAlignment.Center;

            //////////  End - Header /////////////

            document.InsertParagraph();

            texto = "EXCELENTÍSSIMO SENHOR CONSELHEIRO PRESIDENTE DO EGRÉGIO TRIBUNAL DE " +
                "CONTAS DO ESTADO DO AMAZONAS";
            document.InsertParagraph(texto, false, textFormat.FTimes12b);

            for (int w = 0; w < 10; w++)
                document.InsertParagraph();

            texto = @"O SECRETÁRIO GERAL DE CONTROLE EXTERNO, no exercício da competência que lhe é " +
                "atribuída pelo art. 286, § único do Regimento Interno do TCE / AM, Resolução nº " +
                "04 / 2002 - TCE / AM, vem, perante Vossa Excelência, oferecer ";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);

            texto = "REPRESENTAÇÃO";
            parag.Append(texto, textFormat.FTimes12B);

            texto = " em face ";
            parag.Append(texto, textFormat.FTimes12b);

            orgaoPessoas = orgaoPessoaApp.listorgao(orgaoApp.oneDescricao(cbbOrgao.Text).Id);
            if (orgaoPessoas.Count > 0)
            {
                pessoa = pessoaApp.oneId(orgaoPessoas[0].pessoa);

                if (pessoa.Genero == "M")
                    texto = "do Sr. ";
                else
                    texto = "da Sra. ";
                parag.Append(texto, textFormat.FTimes12b);

                texto = pessoa.Nome;
                parag.Append(texto, textFormat.FTimes12B);
                texto = ", " + pessoa.Titulo + " de " + orgaoApp.oneDescricao(cbbOrgao.Text).Cidade;
                parag.Append(texto, textFormat.FTimes12b);
            }
            else
            {
                texto = "do Sr. ... ";
                parag.Append(texto, textFormat.FTimes12b);
            }

            texto = @", para que se verifique possível burla ao art. 21 da Lei 8.666/1993 " +
            "c/c o art. 6º e 7º da Lei 12.527/2011, ao princípio da Publicidade dos processos " +
            "licitatórios e Isonomia dos participantes.";
            parag.Append(texto, textFormat.FTimes12b);
            parag.Alignment = Alignment.both;

            document.InsertParagraph();

            texto = "1. DOS FATOS";
            document.InsertParagraph(texto, false, textFormat.FTimes12B).IndentationFirstLine = 20;

            document.InsertParagraph();
            document.InsertParagraph();

            texto = "2. DO DIREITO";
            document.InsertParagraph(texto, false, textFormat.FTimes12B).IndentationFirstLine = 20; ;

            document.InsertParagraph();
            document.InsertParagraph();

            texto = "3. PEDIDO";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12B);
            parag.IndentationFirstLine = 20;
            document.InsertParagraph();

            document.InsertParagraph();

            texto = "Sugerem-se as seguintes providências visando a observância da legalidade " +
                "dos atos administrativos pela " + cbbOrgao.Text + ":";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.IndentationFirstLine = 50;
            parag.Alignment = Alignment.both;

            document.InsertParagraph();

            texto = "a) Converter a atual demanda em processo de ";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);

            texto = "REPRESENTAÇÃO";
            parag.Append(texto, textFormat.FTimes12B);

            texto = @" (Art. 208, Resolução TCE nº 04/2002) contra a " + cbbOrgao.Text + " na pessoa ";
            parag.Append(texto, textFormat.FTimes12b);

            orgaoPessoas = orgaoPessoaApp.listorgao(orgaoApp.oneDescricao(cbbOrgao.Text).Id);
            if (orgaoPessoas.Count > 0)
            {
                pessoa = pessoaApp.oneId(orgaoPessoas[0].pessoa);

                if (pessoa.Genero == "M")
                    texto = "do Sr. ";
                else
                    texto = "da Sra. ";
                parag.Append(texto, textFormat.FTimes12b);

                texto = pessoa.Nome;
                parag.Append(texto, textFormat.FTimes12B);
                texto = ", " + pessoa.Titulo + ", ";
                parag.Append(texto, textFormat.FTimes12b);
            }
            else
            {
                texto = "do Sr. ... ";
                parag.Append(texto, textFormat.FTimes12b);
            }

            texto = @"para a devida apuração dos fatos e atendimento aos princípios do contraditório " +
                "e da ampla defesa, com fulcro no receio de lesão ao erário, nos termos do inciso VIII " +
                "do art. 10 da Lei 8.429/1992, que considera atos de improbidade administrativa que " +
                "causam prejuízo ao erário a frustração da licitude de processo licitatório ou a sua " +
                "dispensa indevida, e de desvio do interesse público;";
            parag.Append(texto, textFormat.FTimes12b);

            parag.IndentationFirstLine = 50;
            parag.Alignment = Alignment.both;

            document.InsertParagraph();

            texto = "b) Comunicar ao Ministério Público de Contas sobre as irregularidades citadas nesta " +
                "peça técnica, bem como sobre a sugestão de abertura de Representação através da " +
                "Secretaria Geral de Controle Externo, para que promova ações no âmbito de sua " +
                "competência; e  ";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.IndentationFirstLine = 50;
            parag.Alignment = Alignment.both;

            document.InsertParagraph();

            texto = @"c) Comunicar ao Poder competente do Município sobre os indícios de irregularidades " +
                "apontadas, na forma do art. 1º, XXIV, da Lei 2.423/96 c/c art. 5º, XXIV e II, IV, " +
                "alínea “b”, da Resolução TCE nº 04/2002.";
            parag = document.InsertParagraph(texto, false, textFormat.FTimes12b);
            parag.IndentationFirstLine = 50;
            parag.Alignment = Alignment.both;

            for (int w = 0; w < 3; w++)
                document.InsertParagraph();

            texto = "Manaus, " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") +
                " de " + DateTime.Now.Year + ".";
            document.InsertParagraph(texto, false, textFormat.FTimes12b).Alignment = Alignment.center;


            for (int w = 0; w < 3; w++)
                document.InsertParagraph();

            texto = config.TitularSecretaria.ToUpper();
            document.InsertParagraph(texto, false, textFormat.FTimes12B).Alignment = Alignment.center; ;

            texto = "Secretário Geral de Controle Externo";
            document.InsertParagraph(texto, false, textFormat.FTimes10b).Alignment = Alignment.center; ;

            try
            {
                document.Save();
            }
            catch { }

            Process.Start("WINWORD.EXE", arq);

        }
    }
}
