namespace ApresentacaoOdair
{
    public class Cliente
    {
        public string Nome { get; set;}
        public Email Email { get; set;}
        public CPF CPF { get; set;}
        public DateTime DataNascimento {get; set;}

       public bool Validar()
        {
            return Email.Validar() && CPF.Validar();
        } 
    }
}