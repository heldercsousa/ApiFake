namespace ApiFake1.DataGen
{
    public static class ExcecaoRandomica
    {
        private static Random _rdn = new Random();
        public static void Gerar(int probabilidade, int universo)
        {           
            if (universo == 0)
            {
                throw new Exception("param universo deve ser maior que zero");
            }
            if (probabilidade == 0)
            {
                return;
            }
            if (probabilidade > universo)
            {
                throw new Exception("param probabilidade não pode ser maior que param universo");
            }

            var universoData = Enumerable
            .Range(1,universo)
            .Select(idx => probabilidade >= idx-1 ? 1 : 0)
            .ToList();

            var idSorteado = _rdn.Next(0, universoData.Count - 1);

            if (universoData[idSorteado] == 1)
            {
                throw new Exception("Erro aleatório foi disparado. Esta é uma simulação de exceção, e a probabilidade dela acontecer nesta API fake é de 1 em 1000");
            }
        }
    }
}