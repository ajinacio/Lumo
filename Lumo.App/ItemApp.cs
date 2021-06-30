using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class ItemApp
    {
        private ConexaoBD dbaccess;

        private Item one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {
                var registro = new Item()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Codigo = dataTable.Rows[position]["codigo"].ToString(),
                    Descricao = dataTable.Rows[position]["descricao"].ToString(),
                    Nivel = int.Parse(dataTable.Rows[position]["nivel"].ToString()),
                    Pontos = int.Parse(dataTable.Rows[position]["pontos"].ToString())
                };
                return registro;
            }
            else
                return new Item();
        }

        private Item one(string crud, List<string> par)
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

        private List<Item> listStandart(string crud, List<string> par)
        {
            var list = new List<Item>();
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

        private void insert(Item item)
        {
            var dados = new List<string>();
            dados.Add(item.Codigo);
            dados.Add(item.Descricao);
            dados.Add(item.Nivel.ToString());
            dados.Add(item.Pontos.ToString());

            var crud = "INSERT INTO itens(codigo, descricao, nivel, pontos) " +
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

        private void update(Item item)
        {
            var dados = new List<string>();
            dados.Add(item.Codigo);
            dados.Add(item.Descricao);
            dados.Add(item.Nivel.ToString());
            dados.Add(item.Pontos.ToString());
            dados.Add(item.Id.ToString());

            var crud = "UPDATE itens SET codigo=@dados0, descricao=@dados1, nivel=@dados2, " +
                 "pontos=@dados3 WHERE id=@dados4";

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

        public void save(Item item)
        {
            if (item.Id > 0)
                update(item);
            else
                insert(item);
        }

        public void delete(Item item)
        {
            var dados = new List<string>();
            dados.Add(item.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM itens WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Item oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM itens WHERE id=" + id, dados);
        }

        public Item oneCodigo(string cod)
        {
            var dados = new List<string>();
            return one("SELECT * FROM itens WHERE codigo='" + cod + "'", dados);
        }

        public Item oneDescricao(string descr)
        {
            var dados = new List<string>();
            return one("SELECT * FROM itens WHERE descricao='" + descr + "'", dados);
        }

        public List<Item> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM itens ORDER BY id", dados);
        }

        public List<Item> listAllCodigo()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM itens ORDER BY codigo ASC", dados);
        }

        public List<Item> listAnalitico()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM itens WHERE nivel=" + 2 +
                " ORDER BY codigo", dados);
        }

    }
}
