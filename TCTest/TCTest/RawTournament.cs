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
        public string Name { get; set; }
        public string Date { get; set; }
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
