using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCTest
{
    public class RawTournament
    {
        private string _date;

        public string Name { get; set; }

        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                this._date = value;

                // Parse string like Start Date: 9/7/2018&nbsp;&nbsp;End Date: 9/9/2018
                if (string.IsNullOrEmpty(this._date))
                {
                    return;
                }

                string[] separatingChars = { "&nbsp;" };
                string[] parts = this._date.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    this.StartDate = DateTime.Parse(GetTextAfterColon(parts[0]));
                    this.EndDate = DateTime.Parse(GetTextAfterColon(parts[1]));
                }
            }
        }

        private static string GetTextAfterColon(string text)
        {
            int pos = text.IndexOf(":");
            if (pos > 0)
            {
                return text.Substring(pos + 1).Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public List<RawDivision> Divisions { get; set; }

        public override string ToString()
        {
            PropertyInfo[] _PropertyInfos = null;

            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                if (!info.PropertyType.Namespace.Contains("Collections"))
                {
                    var value = info.GetValue(this, null) ?? "(null)";
                    sb.AppendLine(info.Name + ": " + value.ToString());
                }
            }

            foreach (var d in this.Divisions)
            {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString();
        }
    }
}
