using ApiFake1.Model;
namespace ApiFake1.Enumerables
{
    public static class NivelTratamento
    {
        public static readonly KeyValueModel<int,string> PrimeiroNivel = new KeyValueModel<int,string>{ Key = 0, Value = "Primeiro Nível"};
        public static readonly KeyValueModel<int,string> SegundoNivel = new KeyValueModel<int,string>{ Key = 1, Value = "Ouvidoria da distribuidora (segundo nível)"};
        public static readonly KeyValueModel<int,string> Outros = new KeyValueModel<int,string>{ Key = 2, Value = "Outros"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return PrimeiroNivel;
                yield return SegundoNivel;
                yield return Outros;
            }
        }
    }
}