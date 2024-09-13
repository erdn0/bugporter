using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Features.ReportBug
{
    public class ReportedBug
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public ReportedBug(string id, string summary, string description)
        {
            Id = id;
            Summary = summary;
            Description = description;
        }
    }
}
