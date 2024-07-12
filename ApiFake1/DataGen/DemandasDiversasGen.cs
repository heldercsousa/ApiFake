using ApiFake1.Model.DemandasDiversas;
using ApiFake1.Model;
using System;
using System.Globalization;

namespace ApiFake1.DataGen;
public static class DemandasDiversasGen
{
    private static List<DemandasDiversasCsvModel> _demandasDiversas = new List<DemandasDiversasCsvModel>(); 

    public static List<DemandasDiversasCsvModel> DemandasDiversas
    {
        get
        {
            ExcecaoRandomica.Gerar(1,100);
            return _demandasDiversas;
        }
    }

    public static void CarregarDados(int ideAgente)
    {
        var path = "DataGen/CSV/dados";
        var filePaths = Directory.EnumerateFiles(path).Where(x => x.Contains("extracaoRec") && x.Contains(ideAgente.ToString()));
        foreach (var filePath in filePaths)
        {
            var lines = File.ReadAllLines(filePath);

            var lst = lines.Skip(1).Select(x =>
            {
                var columns = x.Split(",");
                var r = new DemandasDiversasCsvModel();
                if (columns.Length > 0)
                {
                    int IdeAgente = 0;
                    int.TryParse(columns[0], out IdeAgente);
                    r.IdeAgente = IdeAgente;

                    int CodFormaContato = 0;
                    int.TryParse(columns[2], out CodFormaContato);
                    r.IdcCanalAtendimento = CodFormaContato;

                    string DescRca = columns[3];
                    r.IdcTipologia = DescRca;

                    string ano = columns[4];
                    r.Ano = ano;

                    string mes = columns[5];
                    r.Mes = mes;

                    int QtdAndamento = 0;
                    int.TryParse(columns[10], out QtdAndamento);
                    r.QtdAndamentoNoMomento = QtdAndamento;

                    int QtdRegistradaNoDia = 0;
                    int.TryParse(columns[6], out QtdRegistradaNoDia);
                    r.QtdRegistradaNoDia = QtdRegistradaNoDia;

                    int QtdRecebidasImprocedentes = 0;
                    int.TryParse(columns[7], out QtdRecebidasImprocedentes);
                    r.QtdImprocedenteNoDia = QtdRecebidasImprocedentes;

                    int QtdRecebidasProcedentes = 0;
                    int.TryParse(columns[8], out QtdRecebidasProcedentes);
                    r.QtdProcedenteNoDia = QtdRecebidasProcedentes;

                    int Dia = 0;
                    int.TryParse(columns[11], out Dia);
                    r.Dia = Dia;

                    int Intervalo = 0;
                    int.TryParse(columns[12], out Intervalo);
                    r.Intervalo = Intervalo;
                }

                return r;
            })
            .ToList();

            _demandasDiversas.AddRange(lst);

        }
    }
}