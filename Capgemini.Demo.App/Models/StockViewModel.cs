using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capgemini.RACE.Platform.Common;

namespace Capgemini.Demo.App
{
    public class StockViewModel
    {
        public string StockId { get; set; }

        public string StockName { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public bool StockStatus { get; set; }

        public bool Flag { get; set; }

        public string tempDate { get; set; }

        public string Percentage { get; set; }

        public string Difference { get; set; }

    }
}