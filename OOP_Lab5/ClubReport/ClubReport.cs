using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.ClubReport
{
    public class ClubReport
    {
        public string Header { get; set; }

        public string MainPart { get; set; }

        public string Conclusion { get; set; }

        public override string ToString() =>
            new StringBuilder()
            .Append(Header)
            .Append(MainPart)
            .Append(Conclusion)
            .ToString();
    }
}
