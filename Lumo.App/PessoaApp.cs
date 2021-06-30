using Lumo.Domain;
using Lumo.Repository;
using System.Collections.Generic;
using System.Data;

namespace Lumo.App
{
    public class PessoaApp
    {
        private ConexaoBD dbaccess;

        private Pessoa one(DataTable dataTable, int position)
        {

            if (dataTable.Rows.Count > 0)
            {
                var registro = new Pessoa()
                {
                    Id = int.Parse(dataTable.Rows[position]["id"].ToString()),
                    Nome = dataTable.Rows[position]["nome"].ToString(),
                    Titulo = dataTable.Rows[position]["titulo"].ToString(),
                    FisJur = dataTable.Rows[position]["fisjur"].ToString(),
                    Genero = dataTable.Rows[position]["genero"].ToString(),
                    CPF = dataTable.Rows[position]["cpf"].ToString(),
                    CNPJ = dataTable.Rows[position]["cnpj"].ToString(),
                    Endereco = dataTable.Rows[position]["endereco"].ToString(),
                    Complemento = dataTable.Rows[position]["complemento"].ToString(),
                    Bairro = dataTable.Rows[position]["bairro"].ToString(),
                    CEP = dataTable.Rows[position]["cep"].ToString(),
                    Cidade = dataTable.Rows[position]["cidade"].ToString(),
                    UF = dataTable.Rows[position]["uf"].ToString(),
                    Telefone1 = dataTable.Rows[position]["telefone1"].ToString(),
                    Telefone2 = dataTable.Rows[position]["telefone2"].ToString(),
                    Qualidade = dataTable.Rows[position]["qualidade"].ToString()
                };
                return registro;
            }
            else
                return new Pessoa();
        }

        private Pessoa one(string crud, List<string> par)
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

        private List<Pessoa> listStandart(string crud, List<string> par)
        {
            var list = new List<Pessoa>();
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

        private void insert(Pessoa pessoa)
        {
            var dados = new List<string>();
            dados.Add(pessoa.Nome);
            dados.Add(pessoa.Titulo);
            dados.Add(pessoa.FisJur);
            dados.Add(pessoa.Genero);
            dados.Add(pessoa.CPF);
            dados.Add(pessoa.CNPJ);
            dados.Add(pessoa.Endereco);
            dados.Add(pessoa.Complemento);
            dados.Add(pessoa.Bairro);
            dados.Add(pessoa.CEP);
            dados.Add(pessoa.Cidade);
            dados.Add(pessoa.UF);
            dados.Add(pessoa.Telefone1);
            dados.Add(pessoa.Telefone2);
            dados.Add(pessoa.Qualidade);

            var crud = "INSERT INTO pessoas(nome, titulo, fisjur, genero, cpf, cnpj, " +
                "endereco, complemento, bairro, cep, cidade, uf, telefone1, telefone2, " +
                "qualidade) VALUES (@dados0, @dados1, @dados2, @dados3, @dados4, @dados5, " +
                "@dados6, @dados7, @dados8, @dados9, @dados10, @dados11, @dados12, @dados13, @dados14)";

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

        private void update(Pessoa pessoa)
        {
            var dados = new List<string>();
            dados.Add(pessoa.Nome);
            dados.Add(pessoa.Titulo);
            dados.Add(pessoa.FisJur);
            dados.Add(pessoa.Genero);
            dados.Add(pessoa.CPF);
            dados.Add(pessoa.CNPJ);
            dados.Add(pessoa.Endereco);
            dados.Add(pessoa.Complemento);
            dados.Add(pessoa.Bairro);
            dados.Add(pessoa.CEP);
            dados.Add(pessoa.Cidade);
            dados.Add(pessoa.UF);
            dados.Add(pessoa.Telefone1);
            dados.Add(pessoa.Telefone2);
            dados.Add(pessoa.Qualidade);
            dados.Add(pessoa.Id.ToString());

            var crud = "UPDATE pessoas SET nome=@dados0, titulo=@dados1, fisjur=@dados2, genero=@dados3" +
                 "cpf=@dados4, cnpj=@dados5, endereco=@dados6, complemento=@dados7, bairro=@dados8, " +
                 "cep=@dados9, cidade=@dados10, uf=@dados11, telefone1=@dados12, telefone2=@dados13, " +
                 "qualidade=@dados14 WHERE id=@dados15";

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

        public void save(Pessoa pessoa)
        {
            if (pessoa.Id > 0)
                update(pessoa);
            else
                insert(pessoa);
        }

        public void delete(Pessoa pessoa)
        {
            var dados = new List<string>();
            dados.Add(pessoa.Id.ToString());

            dbaccess = new ConexaoBD();
            var crud = "DELETE FROM pessoas WHERE id=@dados0";
            try
            {
                dbaccess.commandExecuteNonQuery(crud, dados);
            }
            finally
            {
                dbaccess.Dispose();
            }
        }

        public Pessoa oneId(int id)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE id=" + id, dados);
        }

        public Pessoa oneNome(string nome)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE nome='" + nome + "'", dados);
        }

        public Pessoa oneCPF(string cpf)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE cpf='" + cpf + "'", dados);
        }

        public Pessoa oneCNPJ(string cnpj)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE cnpj='" + cnpj + "'", dados);
        }

        public Pessoa oneTelefone1(string fone)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE telefone1='" + fone + "'", dados);
        }

        public Pessoa oneTelefone2(string fone)
        {
            var dados = new List<string>();
            return one("SELECT * FROM pessoas WHERE telefone2='" + fone + "'", dados);
        }

        public List<Pessoa> listAll()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM pessoas ORDER BY id", dados);
        }

        public List<Pessoa> listFisica()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM pessoas WHERE fisjur='F'", dados);
        }

        public List<Pessoa> listJuridica()
        {
            var dados = new List<string>();
            return listStandart("SELECT * FROM pessoas WHERE fisjur='J'", dados);
        }
    }
}

