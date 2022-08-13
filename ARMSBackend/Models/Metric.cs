using System;

namespace ARMSBackend.Models
{
    public class Metric
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public int MetricTypeId { get; set; }
        public MetricType MetricType { get; set; }
    }
}
