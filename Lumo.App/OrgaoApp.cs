using Lumo.Domain;
using Lumo.Repository;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class OrgaoApp
    {
        private ConexaoBD dbaccess;

        private Orgao one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Orgao()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Tipo = dataTable.Rows[position]["tipo"].ToString(),
                    Sigla = dataTable.Rows[position]["sigla"].ToString(),
                    Descricao = dataTable.Rows[position]["descricao"].ToString(),
                    CNPJ = dataTable.Rows[position]["cnpj"].ToString(),
                    Endereco = dataTable.Rows[position]["endereco"].ToString(),
                    Complemento = dataTable.Rows[position]["complemento"].ToString(),
                    CEP = dataTable.Rows[position]["cep"].ToString(),
                    Cidade = dataTable.Rows[position]["cidade"].ToString(),
                    UF = dataTable.Rows[position]["uf"].ToString(),
                    Telefone1 = dataTable.Rows[position]["telefone1"].ToString(),
                    Telefone2 = dataTable.Rows[position]["telefone2"].ToString(),
                    EstadoResp = dataTable.Rows[position]["estadoresp"].ToString(),
                    MunicipioResp = dataTable.Rows[position]["municipioresp"].ToString(),
                };
                return registro;
            }
            else
                return new Orgao();
        }

        private Orgao one(string crud, List<string> par)
        {
            dbaccess = new ConexaoBD();

            try
            {
                var dataTable = dbaccess.dataTable(crud, par);
                return one(dataTable, 0);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        private List<Orgao> listStandart(string crud, List<string> par)
        {
            var list = new List<Orgao>();
            dbaccess = new ConexaoBD();

            try
            {
                var dataTable = dbaccess.dataTable(crud, par);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                    list.Add(one(dataTable, i));
            }
            finally
            {
                dbaccess.Dispose();
            }
            return list;
        }

        private void insert(Orgao orgao)
        {
            var dados = new List<string>();
            dados.Add(orgao.Tipo);
            dados.Add(orgao.Sigla);
            dados.Add(orgao.Descricao);
            dados.Add(orgao.CNPJ);
            dados.Add(orgao.Endereco);
            dados.Add(orgao.Complemento);
            dados.Add(orgao.CEP);
            dados.Add(orgao.Cidade);
            dados.Add(orgao.UF);
            dados.Add(orgao.Telefone1);
            dados.Add(orgao.Telefone2);
            dados.Add(orgao.EstadoResp);
            dados.Add(orgao.MunicipioResp);

            var crud = "INSERT INTO orgaos(tipo, sigla, descricao, cnpj, " +
                "endereco, complemento, cep, cidade, uf, telefone1, telefone2, " +
                "estadoresp, municipioresp) VALUES (@dados0, @dados1, @dados2, " +
                "@dados3, @dados4, @dados5, @dados6, @dados7, @dados8, @dados9, " +
                "@dados10, @dados11, @dados12)";

            dbaccess = new ConexaoBD();

            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        private void update(Orgao orgao)
        {
            var dados = new List<string>();
            dados.Add(orgao.Tipo);
            dados.Add(orgao.Sigla);
            dados.Add(orgao.Descricao);
            dados.Add(orgao.CNPJ);
            dados.Add(orgao.Endereco);
            dados.Add(orgao.Complemento);
            dados.Add(orgao.CEP);
            dados.Add(orgao.Cidade);
            dados.Add(orgao.UF);
            dados.Add(orgao.Telefone1);
            dados.Add(orgao.Telefone2);
            dados.Add(orgao.EstadoResp);
            dados.Add(orgao.MunicipioResp);
            dados.Add(orgao.Id.ToString());

            var crud = "UPDATE orgaos SET tipo=@dados0, sigla=@dados1, descricao=@dados2, " +
                 "cnpj=@dados3, endereco=@dados4, complemento=@dados5, cep=@dados6, " +
                 "cidade=@dados7, uf=@dados8, telefone1=@dados9, telefone2=@dados10, " +
                 "estadoresp=@dados11, municipioresp=@dados12 WHERE id=@dados13";

            dbaccess = new ConexaoBD();

            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void save(Orgao orgao)
        {
            if (orgao.Id > 0)
                update(orgao);
            else
                insert(orgao);
        }

        public void delete(Orgao orgao)
        {
            var dados = new List<string>();
            dados.Add(orgao.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM orgaos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Orgao oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE id=" + id, dados);
        }

        public Orgao oneSigla(string sigla)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE sigla='" + sigla + "'", dados);
        }

        public Orgao oneDescricao(string descr)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE descricao='" + descr + "'", dados);
        }

        public Orgao oneCNPJ(string cnpj)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE cnpj='" + cnpj + "'", dados);
        }

        public Orgao oneTelefone1(string fone)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE telefone1='" + fone + "'", dados);
        }

        public Orgao oneTelefone2(string fone)
        {
            var dados = new List<string>();
            return one("SELECT * FROM orgaos WHERE telefone2='" + fone + "'", dados);
        }

        public List<Orgao> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM orgaos ORDER BY id", dados);
        }

        public List<Orgao> listEstado(int uf)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM orgaos WHERE estadoresp='" + uf + "'", dados);
        }

        public List<Orgao> listMunicipio(int mp)
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM orgaos WHERE municipioresp='" + mp + "'", dados);
        }
    }
}

