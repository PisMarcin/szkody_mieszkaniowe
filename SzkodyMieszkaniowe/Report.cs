using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    public class Report
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateAt { get; private set; }
        public Report()
        {
            
        }
        public Report(Guid id, string content)
        {
            Id = id;
            Content = content;
            CreateAt = DateTime.UtcNow;
        }

        public Report AddReport(Guid id, string content)
        {
            var report = new Report(id, content);
            report.CreateAt = DateTime.UtcNow;
            return report;
        }
    }
}
