using System.Collections.Generic;
using System.Linq;

namespace ARMSBackend.DTOs
{
    public class PlotlyChart<xType,yType>
    {
        public string mode { get; set; }
        public List<xType> x { get; set; }
        public List<yType> y { get; set; }

        public PlotlyChart(string mode)
        {
            this.mode = mode.ToLower();
            x = new List<xType>();
            y = new List<yType>();
        }

        public PlotlyChart(string mode, List<xType> x, List<yType> y)
        {
            this.mode = mode.ToLower();
            this.x = x;
            this.y = y; 
        }

        public void addToX(xType val)
        {
            this.x.Add(val);
        }

        public void addToY(yType val)
        {
            this.y.Add(val);
        }
    }
}
