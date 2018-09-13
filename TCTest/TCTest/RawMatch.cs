using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCTest
{
    public class RawMatch
    {
        // F, SF
        public string Round { get; set; }

        // (2) Hayden Himka d. Robert Box
        public string Result { get; set; }

        // 6-0; 6-0
        public string Score { get; set; }

        public override string ToString()
        {
            PropertyInfo[] _PropertyInfos = null;

            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }
}
