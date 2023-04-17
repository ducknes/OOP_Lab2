using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.ClubReport
{
    public interface IClubReportBuilder
    {
        void BuildHeader();

        void BuildMainPart();

        void BuildConclusion();

        ClubReport GetReport();
    }
}
