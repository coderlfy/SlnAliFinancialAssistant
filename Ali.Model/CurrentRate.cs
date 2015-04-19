using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ali.Model
{
    public class CurrentRate
    {
        public const String KeyNameFetchTime = "FetchTime";
        public const String KeyNameMonth1To6 = "Month1To6";
        public const String KeyNameMonth6To12 = "Month6To12";
        public const String KeyNameMonth12To24 = "Month12To24";
        private DateTime _fetchTime;

        public DateTime _FetchTime
        {
            get { return _fetchTime; }
            set { _fetchTime = value; }
        }

        private decimal _month1To6;

        public decimal _Month1To6
        {
            get { return _month1To6; }
            set { _month1To6 = value; }
        }
        private decimal _month6To12;

        public decimal _Month6To12
        {
            get { return _month6To12; }
            set { _month6To12 = value; }
        }
        private decimal _month12To24;

        public decimal _Month12To24
        {
            get { return _month12To24; }
            set { _month12To24 = value; }
        }
        

    }
}
