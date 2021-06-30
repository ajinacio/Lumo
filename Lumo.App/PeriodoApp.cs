using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class PeriodoApp
    {
        private ConexaoBD dbaccess;

        private Periodo one(DataTable dataTable, int position)
        {
            OrgaoApp orgaoApp = new OrgaoApp();

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Periodo()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Descricao = dataTable.Rows[position]["descricao"].ToString(),
                    orgao = orgaoApp.oneId(int.Parse(dataTable.Rows[position]["orgao"].ToString())),
                    Representacao = dataTable.Rows[position]["representacao"].ToString(),
                };
                return registro;
            }
            else
                return new Periodo();
        }

        private Periodo one(string crud, List<string> par)
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

        private List<Periodo> listStandart(string crud, List<string> par)
        {
            var list = new List<Periodo>();
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

        private void insert(Periodo periodo)
        {
            var dados = new List<string>();
            dados.Add(periodo.Descricao);
            dados.Add(periodo.orgao.Id.ToString());
            dados.Add(periodo.Representacao);

            var crud = "INSERT INTO periodos(descricao, orgao, representacao) " +
                "VALUES (@dados0, @dados1, @dados2)";

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

        private void update(Periodo periodo)
        {
            var dados = new List<string>();
            dados.Add(periodo.Descricao);
            dados.Add(periodo.orgao.Id.ToString());
            dados.Add(periodo.Representacao);
            dados.Add(periodo.Id.ToString());

            var crud = "UPDATE periodos SET descricao=@dados0, orgao=@dados1, representacao=@dados2 " +
                 "WHERE id=@dados3";

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

        public void save(Periodo periodo)
        {
            if (periodo.Id > 0)
                update(periodo);
            else
                insert(periodo);
        }

        public void delete(Periodo periodo)
        {
            var dados = new List<string>();
            dados.Add(periodo.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM periodos WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Periodo oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM periodos WHERE id=" + id, dados);
        }

        public Periodo oneDescricao(string descr)
        {
            var dados = new List<string>();
            return one("SELECT * FROM periodos WHERE descricao='" + descr + "'", dados);
        }

        public Periodo oneOrgaoDescricao(int orgao, string descr)
        {
            var dados = new List<string>();
            dados.Add(descr);
            dados.Add(orgao.ToString());
            return one("SELECT * FROM periodos WHERE descricao=@dados0" + 
                " AND orgao=@dados1", dados);
        }

        public List<Periodo> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM periodos ORDER BY id", dados);
        }

        public List<Periodo> listOrgao(int org)
        {
            var dados = new List<string>();
            dados.Add(org.ToString());
            return listStandart("SELECT * FROM periodos WHERE orgao=@dados0", dados);
        }
    }
}

