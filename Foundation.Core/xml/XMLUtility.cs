using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Foundation.Core
{
    public class XMLUtility
    {
        public string ConvertDataTableToXML(
            DataTable xmlDs)
        {
            #region
            /*
            foreach (DataColumn dc in xmlDs.Columns)
            {
                foreach (DataRow dr in xmlDs.Rows)
                {
                    if (dr[dc.ColumnName] == System.DBNull.Value)
                        dr[dc.ColumnName] = "";
                }
            }*/
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
                {
                    xmlDs.WriteXml(writer, XmlWriteMode.IgnoreSchema, true);
                    long count = stream.Length;
                    byte[] arr = new byte[count];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(arr, 0, (int)count);
                    return Encoding.UTF8.GetString(arr);
                }
            }
            #endregion
        }

        public void ConvertXMLToDataSet(
            string xmlData, DataSet ds)
        {
            #region
            using (StringReader stream = new StringReader(xmlData)) {
                using (XmlTextReader reader = new XmlTextReader(stream))
                {
                    ds.ReadXml(reader);
                }
            }
            #endregion
        }
    }
}
