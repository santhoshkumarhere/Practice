using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.xmlParsing
{
    class LoanRequestProcessor
    {
        public void ProcessXML()
        {
            var root = XElement.Parse(StaticXML.xmlFullText);

            var loanDetailsCollection = root.Elements("APP").Elements("LOAN_DETAILS");
            bool hasLoanDetails = loanDetailsCollection.Any();

            if (hasLoanDetails)
            {
                var loans = loanDetailsCollection.Elements("LOANPVO");

                var response = from result in loans
                               where result.Name == "LOANPVO" && result.Element("LOAN_DATA") != null
                               let chemical = result.Element("CHEMICAL_USAGE").Value
                               let seed = result.Element("SEED_USAGE").Value
                               select new LoanResponse
                               (
                                   result.Element("LOAN_DATA").Element("LOAN_YEAR").Value,
                                   result.Element("LOAN_DATA").Element("LOAN_STATUS").Value,
                                   chemical,
                                   seed
                               );

                var approvedLoans = response.Where(
                        x => x.Status.Equals("Approved") && x.TotalUsage > 0 || x.Status.Equals("Approved") && x.Year.Equals("2017") && x.TotalUsage <= 0);
                var hasLoan = approvedLoans.Any();
            }
        }


    }
}
