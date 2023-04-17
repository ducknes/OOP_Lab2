using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.ClubReport
{
    public class ClubReportBuilder : IClubReportBuilder
    {
        private ClubReport _clubReport;

        private readonly IEnumerable<Computer> _computers;

        public ClubReportBuilder(IEnumerable<Computer> computers)
        {
            _computers = computers;
            _clubReport = new ClubReport();
        }

        public void BuildHeader()
        {
            _clubReport.Header =
                $"Отчет о всех компьютерах в клубе. Дата:{DateTime.Now}\n";

            _clubReport.Header +=
                "\n----------------------------------------------------------------------------------------\n";
        }

        public void BuildMainPart()
        {
            _clubReport.MainPart =
                string.Join(Environment.NewLine,
                    _computers.Select(comp =>
                    $"\nID: {comp.ComputerID}" +
                    $"\nТип процессора: {comp.ProcessorType}" +
                    $"\nЧастота процессора: {comp.ProcessorFrequency} гцц" +
                    $"\nОбъём ОЗУ: {comp.MemoryCapacity} гб" +
                    $"\nВидеокарта: {comp.VideoCard}" +
                    $"\nОбъём видеопамяти: {comp.VideoCapacity} гб" +
                    $"\nБлок питания: {comp.PowerUnit} вт" +
                    $"\nЦена компьютера: {comp.ComputerCost} руб\n"));
        }

        public void BuildConclusion()
        {
            _clubReport.Conclusion =
                "\n----------------------------------------------------------------------------------------\n";

            _clubReport.Conclusion +=
                $"Общее число компьютеров в клубе: {_computers.Count()}\t\t" +
                $"Суммарная стоимость всех компьютеров: {_computers.Sum(comp => comp.ComputerCost)} руб";
        }

        public ClubReport GetReport()
        {
            ClubReport clubReport = _clubReport;

            _clubReport = new ClubReport();

            return clubReport;
        }
    }
}
