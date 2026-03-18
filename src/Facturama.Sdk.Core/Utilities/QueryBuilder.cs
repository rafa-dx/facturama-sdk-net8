using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Utilities
{
    public class QueryBuilder
    {
        public static Dictionary<string, string?> FromObject( object obj)
        {
            var dictionary = new Dictionary<string, string?>();
            
            foreach(var property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = property.GetValue(obj);
                if ( value == null)
                {
                    continue;
                }
                dictionary[property.Name] = value.ToString();
            }
            return dictionary;
        }
    }
}
