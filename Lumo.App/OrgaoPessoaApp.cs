using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class OrgaoPessoaApp
    {
        private ConexaoBD dbaccess;

        private OrgaoPessoa one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {
                var registro = new OrgaoPessoa()
                {
                    orgao = int.Parse(dataTable.Rows[position]["orgao"].ToString()),
                    pessoa = int.Parse(dataTable.Rows[position]["pessoa"].ToString()),
                };
                return registro;
            }
            else
                return new OrgaoPessoa();
        }

        private OrgaoPessoa one(string crud, List<string> par)
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

        private List<OrgaoPessoa> listStandart(string crud, List<string> par)
        {
            var list = new List<OrgaoPessoa>();
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

        public void save(OrgaoPessoa orgaoPessoa)
        {
            var dados = new List<string>();
            dados.Add(orgaoPessoa.orgao.ToString());
            dados.Add(orgaoPessoa.pessoa.ToString());

            var crud = "INSERT INTO orgaopessoa(orgao, pessoa) VALUES (@dados0, @dados1)";

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

        public void deleteOrgao(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM orgaopessoa WHERE orgao=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void deleteOrgaoPessoa(int orgao, int pessoa)
        {
            var dados = new List<string>();
            dados.Add(orgao.ToString());
            dados.Add(pessoa.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM orgaopessoa WHERE orgao=@dados0 AND pessoa=@dados1";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public OrgaoPessoa onePessoa(int orgao, int pessoa)
        {
            var dados = new List<string>();
            dados.Add(orgao.ToString());
            dados.Add(pessoa.ToString());
            return one("SELECT * FROM orgaopessoa WHERE " +
                "orgao=@dados0 AND pessoa=@dados1", dados);
        }

        public List<OrgaoPessoa> listorgao(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM orgaopessoa WHERE orgao=@dados0", dados);
        }

        public List<OrgaoPessoa> listpessoa(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM orgaopessoa WHERE pessoa=@dados0", dados);
        }
    }
}
