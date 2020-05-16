namespace ApresentacaoOdair
{
    public class Cliente
    {
        public string Nome { get; set;}
        public string Email { get; set;}
        public string CPF { get; set;}
        public DateTime DataNascimento {get; set;}

        // Faz a própria percistência
        public string AdicionarCliente()
        {
            //Valida os próprios campos

            if (!Email.Contains("@") && Email.Contains(".com"))
            {
                return "Cliente com e-mail inválido";
            }

            if (CPF.Length != 11)
            {
                return "Cliente com CPF inválido";
            }

            //Faz conexão com o banco
            
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "ConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATANASCIMENTO) VALUES (@nome, @email, @cpf, @datanascimento)";

                cmd.Parameters.AddWithValue("nome", Nome);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("cpf", CPF);
                cmd.Parameters.AddWithValue("datanascimento", DataNascimento);

                cn.Open();
                cmd.ExecuteNonQuery();
            };

            //Envia um email de confirmação

            var mail = new MailMessage("seuemail@eissoai.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem Vindo.";
            mail.Body = "Parabens! Você está cadastrado.";
            client.Send(mail);


            //Termina a operação

            return "Cliente cadastrado com sucesso";

        }
    }
}