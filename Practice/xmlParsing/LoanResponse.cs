using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.xmlParsing
{
    class LoanResponse
    {
        public readonly string Year;
        public readonly string Status;
        public readonly decimal TotalUsage;

        public LoanResponse(string year, string status, string chemicalUsage, string seedUsage)
        {
            this.Year = year;
            this.Status = status;
            this.TotalUsage = this.CalculateUsage(chemicalUsage, seedUsage);
        }

        private string GetStatus(IEnumerable<XElement> statuses)
        {
            var status = statuses.Where(x => x.Element("LOAN_STATUS").Value == "Approved")
                            .Select(x => x.Element("LOAN_STATUS").Value).FirstOrDefault();
            return status == null ? "" : status;
        }

        private decimal CalculateUsage(string chemicalUsage, string seedUsage)
        {
            decimal chemical, seed;
            decimal.TryParse(chemicalUsage, out chemical);
            decimal.TryParse(seedUsage, out seed);
            return chemical + seed;
        }
    }
}
