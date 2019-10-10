using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoCrudeFInalAPI.Controllers
{
    public class GraficoController : Controller
    {    
        
        // GET: Grafico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GraficoColuna()
        {
            Highcharts columnChart = new Highcharts("columnchart");
            columnChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            columnChart.SetTitle(new Title()
            {
                Text = "Classes BDO"
            });
            //columnChart.SetSubtitle(new Subtitle()
            //{
            //    Text = ""
            //});
            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Quantidade de vitórias no pvp por  classe", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = new[] { "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019" }
            });
            //columnChart.SetYAxis(new YAxis()
            //{
            //    Title = new YAxisTitle()
            //    {
            //        Text = "Pontos",
            //        Style = "fontWeight: 'bold', fontSize: '17px'"
            //    },
            //    ShowFirstLabel = true,
            //    ShowLastLabel = true,
            //    Min = 0
            //});
            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = System.Drawing.Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });
            columnChart.SetSeries(new Series[]
            {
                new Series{
                    Name = "Feiticeira",
                    Data = new Data(new object[] { 89, 59, 64, 62, 45, 49, 53, 53, 57 })
                },
                new Series()
                {
                    Name = "Ninja",
                    Data = new Data(new object[] { 82, 58, 78, 77, 75, 65, 59, 66, 50 })
                },
                new Series
                {
                    Name = "Mago",
                    Data = new Data(new object[] { 59, 31, 44, 51, 77, 31, 27, 33, 39 })
                }
            }            
            );
            return View(columnChart);
        }
    }
}