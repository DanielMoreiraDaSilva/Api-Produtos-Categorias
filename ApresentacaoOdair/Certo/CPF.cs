namespace ApresentacaoOdair
{
    public class CPF
    {
        public string CPF { get; set;}

        public bool Validar()
        {
            if (!CPF.Length == 11)
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