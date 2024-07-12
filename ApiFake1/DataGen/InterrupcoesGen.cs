using ApiFake1.Model.Interrupcoes;
using ApiFake1.Model;
using System;
using System.Globalization;

namespace ApiFake1.DataGen;
public static class InterrupcoesGen
{
    private static List<InterrupcoesCsvModel> _interrupcoes = new List<InterrupcoesCsvModel>(); 

    public static List<InterrupcoesCsvModel> Interrupcoes
    {
        get
        {
            ExcecaoRandomica.Gerar(1,100);
            return _interrupcoes;
        }
    }

    public static void CarregarDados(int ideAgente)
    {
        var path = "DataGen/CSV/dados";
        var filePaths = Directory.EnumerateFiles(path).Where(x => x.Contains("extracaoInt") && x.Contains(ideAgente.ToString()));
        foreach (var filePath in filePaths)
        {
            var lines = File.ReadAllLines(filePath);

            var intervalos = Enumerable.Range(0, 48).Select(z =>
            {
                var hours = z / 2;
                var minutes = 0;
                if (z % 2 != 0)
                {
                    minutes = 30;
                }
                var r = new
                {
                    Intervalo = z,
                    TotalMinutes = z * 30,
                    Time = $"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}"
                };
                return r;
            })
            .ToList();

            var lst = lines.Skip(1).Select(x =>
            {
                var columns = x.Split(",");
                var r = new InterrupcoesCsvModel();
                if (columns.Length > 0)
                {
                    int IdeConjuntoUnidadeConsumidora = 0;
                    int.TryParse(columns[1], out IdeConjuntoUnidadeConsumidora);
                    r.IdeConjuntoUnidadeConsumidora = IdeConjuntoUnidadeConsumidora;

                    int IdeMunicipio = 0;
                    int.TryParse(columns[2], out IdeMunicipio);
                    r.IdeMunicipio = IdeMunicipio;

                    int QtdProgr = 0;
                    int.TryParse(columns[4], out QtdProgr);
                    r.QtdOcorrenciaProgramada = QtdProgr;

                    int QtdNProgr = 0;
                    int.TryParse(columns[5], out QtdNProgr);
                    r.QtdOcorrenciaNaoProgramada = QtdNProgr;

                    var cultureInfo = new CultureInfo("en-US");
                    DateTime DtInicio = DateTime.Parse(columns[3], cultureInfo);
                    r.Dia = DtInicio.Day;

                    string Faixa = columns[6].Substring(0,5);
                    int Intervalo = intervalos.Where(x => x.Time == Faixa).Select(x => x.Intervalo).Single();
                    r.Intervalo = Intervalo;
                }

                return r;
            })
            .ToList();

            _interrupcoes.AddRange(lst);

        }
    }
}