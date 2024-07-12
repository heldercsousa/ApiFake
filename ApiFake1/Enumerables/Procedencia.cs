using ApiFake1.Model;
namespace ApiFake1.Enumerables
{
    public static class Procedencia
    {
        public static readonly KeyValueModel<int,string> Improcedente = new KeyValueModel<int,string>{ Key = 0, Value = "Improcedente"};
        public static readonly KeyValueModel<int,string> Procedente = new KeyValueModel<int,string>{ Key = 1, Value = "Procedente"};
        public static readonly KeyValueModel<int,string> EmTratamento = new KeyValueModel<int,string>{ Key = 2, Value = "Em tratamento"};
        public static readonly KeyValueModel<int,string> Outros = new KeyValueModel<int,string>{ Key = 3, Value = "Outros"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return Improcedente;
                yield return Procedente;
                yield return EmTratamento;
                yield return Outros;
            }
        }
    }
}