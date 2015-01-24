using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Configuration;

namespace Basic.Xml
{
    public class XMLToDataTable
    {
        public static DataTable createDataSource(string strAppSettingsKey, string strText)
        {
            //create a data table to store the data for the ddl_langauge control
            DataTable dt = new DataTable();

            //define the columns of the table
            dt.Columns.Add("" + strText + "", typeof(string));

            //read the content of the xml file into a DataSet
            DataSet lanDS = new DataSet();
            string filePath = HttpContext.Current.Request.PhysicalApplicationPath + ConfigurationManager.AppSettings["" + strAppSettingsKey + ""];
            lanDS.ReadXml(filePath);

            if (lanDS.Tables.Count > 0)
            {
                foreach (DataRow copyRow in lanDS.Tables[0].Rows)
                {
                    dt.ImportRow(copyRow);
                }
            }

            //  DataView dv = new DataView(dt);

            return dt;
        }
    }
}
