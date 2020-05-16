namespace ApresentacaoOdair
{
    public class ClienteRepository
    {
        public void Adicionar(Cliente cliente)
        {
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "ConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATANASCIMENTO) VALUES (@nome, @email, @cpf, @datanascimento)";

                cmd.Parameters.AddWithValue("nome", Cliente.Nome);
                cmd.Parameters.AddWithValue("email", Cliente.Email);
                cmd.Parameters.AddWithValue("cpf", Cliente.CPF);
                cmd.Parameters.AddWithValue("datanascimento", Cliente.DataNascimento);

                cn.Open();
                cmd.ExecuteNonQuery();
            };
        }
    }
}