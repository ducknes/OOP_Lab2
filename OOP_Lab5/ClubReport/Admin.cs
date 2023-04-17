using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.ClubReport
{
    public class Admin
    {
        private readonly IClubReportBuilder _builder;

        public Admin(IClubReportBuilder builder)
        {
            _builder = builder;
        }

        public void Build()
        {
            _builder.BuildHeader();

            _builder.BuildMainPart();

            _builder.BuildConclusion();
        }
    }
}
