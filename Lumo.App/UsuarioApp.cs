using Lumo.Repository;
using Lumo.Domain;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class UsuarioApp
    {
        private ConexaoBD dbaccess;

        private Usuario one(DataTable dataTable, int position)
        {
            if (dataTable.Rows.Count > 0)
            {
                var registro = new Usuario()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Nome = dataTable.Rows[position]["nome"].ToString(),
                    Login = dataTable.Rows[position]["login"].ToString(),
                    Senha = dataTable.Rows[position]["senha"].ToString(),
                    Cargo = dataTable.Rows[position]["cargo"].ToString(),
                    Caminho = dataTable.Rows[position]["caminho"].ToString()
                };
                return registro;
            }
            else
                return new Usuario();
        }

        private Usuario one(string crud, List<string> par)
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

        private List<Usuario> listStandart(string crud, List<string> par)
        {
            var list = new List<Usuario>();
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

        private void insert(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Nome);
            dados.Add(usuario.Login);
            dados.Add(usuario.Senha);
            dados.Add(usuario.Cargo);
            dados.Add(usuario.Caminho);

            var crud = "INSERT INTO usuarios(nome, login, senha, cargo, caminho) " +
                "VALUES (@dados0, @dados1, @dados2, @dados3, dados4)";

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
        private void update(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Nome);
            dados.Add(usuario.Login);
            dados.Add(usuario.Senha);
            dados.Add(usuario.Cargo);
            dados.Add(usuario.Caminho);
            dados.Add(usuario.Id.ToString());

            var crud = "UPDATE usuarios SET nome=@dados0, login=@dados1, senha=@dados2, " +
                 "cargo=@dados3, caminho=@dados4 WHERE id=@dados5";

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

        public void save(Usuario usuario)
        {
            if (usuario.Id > 0)
                update(usuario);
            else
                insert(usuario);
        }

        public void delete(Usuario usuario)
        {
            var dados = new List<string>();
            dados.Add(usuario.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM usuarios WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Usuario oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE id=" + id, dados);
        }

        public Usuario oneNome(string nome)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE nome='" + nome + "'", dados);
        }

        public Usuario oneLogin(string log)
        {
            var dados = new List<string>();
            return one("SELECT * FROM usuarios WHERE login='" + log + "'", dados);
        }

        public List<Usuario> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM usuarios ORDER BY id", dados);
        }

    }
}
