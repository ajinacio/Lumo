using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class OrgaoItemApp
    {
        private ConexaoBD dbaccess;

        private OrgaoItem one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {   
                var registro = new OrgaoItem()
                {
                    orgao = int.Parse(dataTable.Rows[position]["orgao"].ToString()),
                    item = int.Parse(dataTable.Rows[position]["item"].ToString()),
                    periodo = int.Parse(dataTable.Rows[position]["periodo"].ToString()),
                    Avaliacao = dataTable.Rows[position]["avaliacao"].ToString()
                };
                return registro;
            }
            else
                return new OrgaoItem();
        }

        private OrgaoItem one(string crud, List<string> par)
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

        private List<OrgaoItem> listStandart(string crud, List<string> par)
        {
            var list = new List<OrgaoItem>();
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

        public void save(OrgaoItem orgaoItem)
        {
            var dados = new List<string>();
            dados.Add(orgaoItem.orgao.ToString());
            dados.Add(orgaoItem.item.ToString());
            dados.Add(orgaoItem.periodo.ToString());
            dados.Add(orgaoItem.Avaliacao);

            var crud = "INSERT INTO orgaoitem(orgao, item, periodo, avaliacao) " +
                "VALUES (@dados0, @dados1, @dados2, @dados3)";

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
            var crud = "DELETE FROM orgaoitem WHERE orgao=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public void deleteItem(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM orgaoitem WHERE item=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public OrgaoItem oneItem(int item, int orgao, int periodo)
        {
            var dados = new List<string>();
            dados.Add(item.ToString());
            dados.Add(orgao.ToString());
            dados.Add(periodo.ToString());
            return one("SELECT * FROM orgaoitem WHERE item=@dados0 AND " +
                "orgao=@dados1 AND periodo=@dados2", dados);
        }

        public List<OrgaoItem> listOrgao(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM orgaoitem WHERE orgao=@dados0", dados);
        }

        public List<OrgaoItem> listItem(int id)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            return listStandart("SELECT * FROM orgaoitem WHERE item=@dados0", dados);
        }

        public List<OrgaoItem> listOrgaoPeriodo(int id, int per)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            dados.Add(per.ToString());
            return listStandart("SELECT * FROM orgaoitem WHERE orgao=@dados0 AND periodo=@dados1", dados);
        }

        public List<OrgaoItem> listItemPeriodo(int id, string per)
        {
            var dados = new List<string>();
            dados.Add(id.ToString());
            dados.Add(per);
            return listStandart("SELECT * FROM orgaoitem WHERE item=@dados0 AND periodo=@dados1", dados);
        }
    }
}
