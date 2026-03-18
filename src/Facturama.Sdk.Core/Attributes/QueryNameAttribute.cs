using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryNameAttribute : Attribute
    {
        public string Name { get; }
        public QueryNameAttribute(string name)
        {
            Name = name;
        }

    }
}
