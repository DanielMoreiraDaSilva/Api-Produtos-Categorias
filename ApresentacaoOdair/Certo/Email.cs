namespace ApresentacaoOdair
{
    public class Email
    {
        public string Endereco { get; set;}

        public bool Validar()
        {
            if (!Endereco.Contains("@"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}