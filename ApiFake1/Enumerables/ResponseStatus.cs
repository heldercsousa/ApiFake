using ApiFake1.Model;

namespace ApiFake1.Enumerables
{
    public static class ResponseStatus
    {
        public static readonly KeyValueModel<int,string> Sucesso = new KeyValueModel<int,string>{ Key = 1, Value = "Sucesso"};
        public static readonly KeyValueModel<int,string> Erro = new KeyValueModel<int,string>{ Key = 2, Value = "Erro"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return Sucesso;
                yield return Erro;
            }
        }
    }
}