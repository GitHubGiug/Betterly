using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingApp.BettingApp.Model
{

    class Currency
    {
        private static readonly double ConversionRate = 1.17;

        public static double Rate { get { return ConversionRate; } }

        
    }
}
