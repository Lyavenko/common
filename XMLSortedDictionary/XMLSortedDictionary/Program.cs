using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/*
 * XML Serializable sorted Dictionary
 */

namespace XMLSortedDictionary
{

    class Program
    {
        static void Main(string[] args)
        {
            string filename = "test.xml";
            SortedDictionary<int, string>
                d = new SortedDictionary<int, string>();
            d.Add(5, "Here I am");
            d[2] = "On the road again";
            foreach (var q in d)
            {
                //
            }

            XmlSerializer ser = new XmlSerializer(
                typeof(SortedDictionary<int, string>)
            );

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, d);
            writer.Close();
        }
    }
}
