namespace ApresentacaoOdair
{
    public class ClienteService
    {
        public string AdicionarCliente(Cliente cliente)
        {
            //valida
            if(!cliente.Validar())
            {
                return "Dados invalidos.";
            }

            //salva no banco
            var repositorio = new ClienteRepository();
            repositorio.Adicionar(cliente);

            //envia o email
            EmailService.Enviar("demim@enviando.com", cliente.Email.Endereco, "Email de validação", "Parabens, você está cadastrado");

            //conclui
            return "Cliente cadastrado com sucesso";
        }
    }
}