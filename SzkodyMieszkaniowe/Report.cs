using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    public class Report
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public DateTime DateTime { get; protected set; }
        public Report()
        {
            
        }
        public Report(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public Report AddReport(Guid id, string content)
        {
            var report = new Report(id, content);
            return report;
        }
    }
}
