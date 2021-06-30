using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class ConfigApp
    {
        private ConexaoBD dbaccess;

        private Config one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {
                var registro = new Config()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Entidade = dataTable.Rows[position]["entidade"].ToString(),
                    Sigla = dataTable.Rows[position]["sigla"].ToString(),
                    Setor = dataTable.Rows[position]["setor"].ToString(),
                    SiglaSetor = dataTable.Rows[position]["siglasetor"].ToString(),
                    TitularSetor = dataTable.Rows[position]["titularsetor"].ToString(),
                    Secretaria = dataTable.Rows[position]["secretaria"].ToString(),
                    SiglaSecretaria = dataTable.Rows[position]["siglasecretaria"].ToString(),
                    TitularSecretaria = dataTable.Rows[position]["titularsecretaria"].ToString()
                };
                return registro;
            }
            else
                return new Config();
        }

        private Config one(string crud, List<string> par)
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

        private void insert(Config config)
        {
            var dados = new List<string>();
            dados.Add(config.Entidade);
            dados.Add(config.Sigla);
            dados.Add(config.Setor);
            dados.Add(config.SiglaSetor);
            dados.Add(config.TitularSetor);
            dados.Add(config.Secretaria);
            dados.Add(config.SiglaSecretaria);
            dados.Add(config.TitularSecretaria);

            var crud = "INSERT INTO config(entidade, sigla, setor, siglasetor, " +
                "titularsetor, secretaria, siglasecretaria, titularsecretaria) " +
                "VALUES (@dados0, @dados1, @dados2, @dados3, @dados4, @dados5, " +
                "@dados6, @dados7)";

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

        private void update(Config config)
        {
            var dados = new List<string>();
            dados.Add(config.Entidade);
            dados.Add(config.Sigla);
            dados.Add(config.Setor);
            dados.Add(config.SiglaSetor);
            dados.Add(config.TitularSetor);
            dados.Add(config.Secretaria);
            dados.Add(config.SiglaSecretaria);
            dados.Add(config.TitularSecretaria);
            dados.Add(config.Id.ToString());

            var crud = "UPDATE config SET entidade=@dados0, sigla=@dados1, setor=@dados2, " +
                 "siglasetor=@dados3, titularsetor=@dados4, secretaria=@dados5, " +
                 "siglasecretaria=@dados6, titularsecretaria=@dados7 WHERE id=@dados8";

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

        public void save(Config config)
        {
            if (config.Id > 0)
                update(config);
            else
                insert(config);
        }

        public void delete(Config config)
        {
            var dados = new List<string>();
            dados.Add(config.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM config WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Config configuracao()
        {
            var dados = new List<string>();
            return one("SELECT * FROM config", dados);
        }

    }
}
