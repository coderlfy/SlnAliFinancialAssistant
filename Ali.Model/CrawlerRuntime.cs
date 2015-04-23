using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ali.Model
{
    public class CrawlerDisableTimeMode1
    {
        private DateTime _minTime;

        public DateTime _MinTime
        {
            get { return _minTime; }
            set { _minTime = value; }
        }

        private DateTime _maxTime;

        public DateTime _MaxTime
        {
            get { return _maxTime; }
            set { _maxTime = value; }
        }

        private bool _usable;

        public bool _Usable
        {
            get { return _usable; }
            set { _usable = value; }
        }

    }

    public class CrawlerDisableTimeMode2
    {
        private DateTime _middleTime;

        public DateTime _MiddleTime
        {
            get { return _middleTime; }
            set { _middleTime = value; }
        }

        private int _fuzzyMinutes = 5;

        public int _FuzzyMinutes
        {
            get { return _fuzzyMinutes; }
            set { _fuzzyMinutes = value; }
        }


        private bool _usable;

        public bool _Usable
        {
            get { return _usable; }
            set { _usable = value; }
        }

    }
    public class CrawlerRuntime
    {
        private List<CrawlerDisableTimeMode1> _disableTime1;

        public List<CrawlerDisableTimeMode1> _DisableTime1
        {
            get { return _disableTime1; }
            set { _disableTime1 = value; }
        }

        private List<CrawlerDisableTimeMode2> _disableTime2;

        public List<CrawlerDisableTimeMode2> _DisableTime2
        {
            get { return _disableTime2; }
            set { _disableTime2 = value; }
        }

        public CrawlerRuntime()
        {
            #region
            if (this._disableTime1 == null)
                this._disableTime1 = new List<CrawlerDisableTimeMode1>();
            if (this._disableTime2 == null)
                this._disableTime2 = new List<CrawlerDisableTimeMode2>();
            #endregion
        }

        public void GetRuntime(
            object time1, object time2)
        {
            #region
            this._disableTime1.Clear();
            this._disableTime2.Clear();
            if (time1 != null &&
                !string.IsNullOrEmpty(time1.ToString()))
            {
                string[] times = time1.ToString().Split(',');
                foreach (string t in times)
                {
                    string[] stmp = t.Split('~');
                    DateTime d1, d2;
                    bool usable = false;
                    if (stmp.Length == 3)
                        if (DateTime.TryParse(stmp[0], out d1) &&
                            DateTime.TryParse(stmp[1], out d2) &&
                            Boolean.TryParse(stmp[2], out usable))
                        {
                            this._disableTime1.Add(new CrawlerDisableTimeMode1()
                            {
                                _MinTime = d1,
                                _MaxTime = d2,
                                _Usable = usable
                            });
                        }
                }

            }

            if (time2 != null &&
                !string.IsNullOrEmpty(time2.ToString()))
            {
                string[] times = time2.ToString().Split(',');
                foreach (string t in times)
                {
                    string[] stmp = t.Split('~');
                    DateTime d1;
                    int minutes = 5;
                    bool usable = false;
                    if (stmp.Length == 3)
                        if (DateTime.TryParse(stmp[0], out d1) &&
                            Int32.TryParse(stmp[1], out minutes) &&
                            Boolean.TryParse(stmp[2], out usable))
                        {
                            this._disableTime2.Add(new CrawlerDisableTimeMode2()
                            {
                                _MiddleTime = d1,
                                _FuzzyMinutes = minutes,
                                _Usable = usable
                            });
                        }
                }
            }
            #endregion
        }

        public bool Enable(DateTime time)
        {
            #region
            foreach (CrawlerDisableTimeMode1 t in this._disableTime1)
            {
                if (t._Usable)
                    if (time < t._MinTime || time > t._MaxTime)
                        continue;
                    else
                        return false;
            }

            foreach (CrawlerDisableTimeMode2 t in this._disableTime2)
            {
                if (t._Usable)
                    if (time < t._MiddleTime.AddMinutes(t._FuzzyMinutes)
                        || time > t._MiddleTime.AddMinutes(0 - t._FuzzyMinutes))
                        continue;
                    else
                        return false;
            }

            return true;
            #endregion
        }
        //time1格式：x~y,x1~y1
        //time2格式：x~m,y~n,z~i
    }
}
