using ApiFake1.Model.Demanda;
using ApiFake1.Model;
using System;
using System.Net;
using System.Globalization;

namespace ApiFake1.DataGen;
public static class DemandaGen
{
    private static List<DemandaModel> _demandas; 

    public static List<DemandaModel> Demandas
    {
        get
        {
            ExcecaoRandomica.Gerar(1,100);
            return _demandas;
        }
    }

    public static void GerarDados()
    {
        var canalAtendimento = Enumerables.CanalAtendimento.List.ToList();
        var status = Enumerables.Status.List.ToList();
        var procedencia = Enumerables.Procedencia.List.ToList();
        var nivelTratamento = Enumerables.NivelTratamento.List.ToList();
        var tipologia = Enumerables.Tipologia.List.ToList();
        var municipio = Enumerables.Municipio.List.ToList();
        
        var rdnLst = new RandomizarElementoLista();

        var dtIni = DateTime.Now.AddMonths(-1);
        var dtFim = DateTime.Now;

        var rdn = new Random();

        _demandas = Enumerable.Range(1,1000).Select(idx => 
        {
            var r = new DemandaModel();
            r.NumProtocolo = idx.ToString().PadLeft(30,'0');
            r.NumUC = RandomizarALFANUM.ProximoAlfaNumerico(30);
            r.NumCPFCNPJ = RandomizarALFANUM.ProximoNumerico(14);          

            var nameCount = rdn.Next(2, 7);
            r.NomTitularUC = Lorem.GetName(nameCount);

            r.IdcCanalAtendimento = rdnLst.Proximo<IList<KeyValueModel<int,string>>,KeyValueModel<int,string>>(canalAtendimento).Key;
            r.IdcTipologia = rdnLst.Proximo<IList<KeyValueModel<string,string>>,KeyValueModel<string,string>>(tipologia).Key;
            r.IdcStatus =  rdnLst.Proximo<IList<KeyValueModel<int,string>>,KeyValueModel<int,string>>(status).Key;
            r.IdcProcedencia = rdnLst.Proximo<IList<KeyValueModel<int,string>>,KeyValueModel<int,string>>(procedencia).Key;
            
            var dtAbertura = RandomizarData.Proximo(dtIni, dtFim);
            r.DthAbertura = dtAbertura.Value.ToString();

            var dtEncerramento = RandomizarData.Proximo(dtAbertura.Value, dtFim, true);
            r.DthEncerramento = dtEncerramento.HasValue ? dtEncerramento.Value.ToString() : null;

            r.IdeMunicipio = rdnLst.Proximo<IList<KeyValueModel<int, string>>, KeyValueModel<int, string>>(municipio).Key;
            r.IdcNivelTratamento = rdnLst.Proximo<IList<KeyValueModel<int,string>>,KeyValueModel<int,string>>(nivelTratamento).Key;

            return r;
        })
        .ToList();
    }
}