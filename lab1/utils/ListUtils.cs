using System.Collections.Generic;
using System.Linq;

namespace SqlServerEFSample
{
    public class ListUtils
    {
        public static string listToString<T>(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return "";
            }

            string str = "[";
            for (var i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    str += ", ";
                }

                str += list.ElementAt(i).ToString();
            }

            return str + "]";
        }
    }
}
