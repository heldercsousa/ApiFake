using ApiFake1.Model;
namespace ApiFake1.Enumerables
{
    public static class CanalAtendimento
    {
        public static readonly KeyValueModel<int,string> Presencial = new KeyValueModel<int,string>{ Key = 1, Value = "Presencial"};
        public static readonly KeyValueModel<int,string> Telefonico = new KeyValueModel<int,string>{ Key = 2, Value = "Telefônico"};
        public static readonly KeyValueModel<int,string> AgenciaVirtual = new KeyValueModel<int,string>{ Key = 3, Value = "Agência Virtual"};
        public static readonly KeyValueModel<int,string> ConsumidorGov = new KeyValueModel<int,string>{ Key = 4, Value = "Consumidor.Gov"};
        public static readonly KeyValueModel<int,string> Aplicativo = new KeyValueModel<int,string>{ Key = 5, Value = "Aplicativo"};
        public static readonly KeyValueModel<int,string> Email = new KeyValueModel<int,string>{ Key = 6, Value = "E-mail"};
        public static readonly KeyValueModel<int,string> SMS = new KeyValueModel<int,string>{ Key = 7, Value = "SMS"};
        public static readonly KeyValueModel<int,string> RedesSociais = new KeyValueModel<int,string>{ Key = 8, Value = "Redes Sociais"};
        public static readonly KeyValueModel<int,string> Outros = new KeyValueModel<int,string>{ Key = 9, Value = "Outros"};

        public static IEnumerable<KeyValueModel<int,string>> List
        {
            get 
            {
                yield return Presencial;
                yield return Telefonico;
                yield return AgenciaVirtual;
                yield return ConsumidorGov;
                yield return Aplicativo;
                yield return Email;
                yield return SMS;
                yield return RedesSociais;
                yield return Outros;
            }
        }
    }
}