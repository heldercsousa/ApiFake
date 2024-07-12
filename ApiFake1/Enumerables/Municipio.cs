using ApiFake1.Model;

namespace ApiFake1.Enumerables
{
    public static class Municipio
    {
        public static readonly KeyValueModel<int,string> Brasilia = new KeyValueModel<int,string>{ Key = 5300108, Value = "Bras�lia"};
        public static readonly KeyValueModel<int,string> AbadiaDeGoias = new KeyValueModel<int,string>{ Key = 5200050, Value = "Abadia de Goi�s"};
        public static readonly KeyValueModel<int,string> Alexania = new KeyValueModel<int,string>{ Key = 5200308, Value = "Alex�nia"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return Brasilia;
                yield return AbadiaDeGoias;
                yield return Alexania;
            }
        }
    }
}