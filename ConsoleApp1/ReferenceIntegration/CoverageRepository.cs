using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceIntegration
{
    public class CoverageRepository : IReadOnlyRepository<Coverage>
    {
        private readonly Dictionary<string, Coverage> coverageDictionary;
        public CoverageRepository()
        {
            this.coverageDictionary = new Dictionary<string, Coverage>();

            PopulateCoverage();
        }

        public Coverage Find(string id)
        {
            if (!coverageDictionary.TryGetValue(id, out Coverage region))
            {
                throw new Exception("Not Found");
            }

            return region;
        }

        public IEnumerable<Coverage> ListAll()
        {
            return coverageDictionary.Select(r => r.Value);
        }

        private void PopulateCoverage()
        {
            //Api to fill Coverage

            //Sample data hard coded
            Coverage r1 = new Coverage { Id = "1", Des = "Cov1" };
            Coverage r2 = new Coverage { Id = "2", Des = "Cov2" };
            Coverage r3 = new Coverage { Id = "3", Des = "Cov3" };
            Coverage r4 = new Coverage { Id = "4", Des = "Cov4" };

            coverageDictionary.Add("1", r1);
            coverageDictionary.Add("2", r2);
            coverageDictionary.Add("3", r3);
            coverageDictionary.Add("4", r4);
        }
    }

}
