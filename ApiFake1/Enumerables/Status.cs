using ApiFake1.Model;

namespace ApiFake1.Enumerables
{
    public static class Status
    {
        public static readonly KeyValueModel<int,string> EmAndamento = new KeyValueModel<int,string>{ Key = 0, Value = "Em andamento"};
        public static readonly KeyValueModel<int,string> Encerrada = new KeyValueModel<int,string>{ Key = 1, Value = "Encerrada"};
        public static readonly KeyValueModel<int,string> Outros = new KeyValueModel<int,string>{ Key = 2, Value = "Outros"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return EmAndamento;
                yield return Encerrada;
                yield return Outros;
            }
        }
    }
}