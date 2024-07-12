namespace ApiFake1.Model.Demanda
{
    public class DemandaModel
    {
        public string NumProtocolo { get; set; }
        public string NumUC { get; set; }
        public string NumCPFCNPJ { get; set; }
        public string NomTitularUC { get; set; }
        public int IdcCanalAtendimento { get; set; }
        public string IdcTipologia { get; set; }
        public int IdcStatus { get; set; }
        public int IdcProcedencia { get; set; }
        public string DthAbertura { get; set; }
        public string DthEncerramento { get; set; }
        public int IdeMunicipio { get; set; }
        public int IdcNivelTratamento { get; set; }
    }
}