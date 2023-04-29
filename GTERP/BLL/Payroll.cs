using GTERP.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace GTERP.BLL
{
    public class PayrollRepository
    {
        public static List<string> GetProssTypes()
        {
            List<string> prossList = new List<string>();
            clsConnectionNew clsCon = new clsConnectionNew();
            string sqlQuery = "Select Distinct Prosstype,dtInput from HR_ProcessedDataSal order by dtInput Desc";
            IDataReader reader = clsCon.GetReader(sqlQuery);

            string process = "";
            while (reader.Read())
            {
                process = reader["ProssType"].ToString();
                DateTime d = DateTime.Parse(process);
                if (prossList.Contains(process))
                {
                    continue;
                }
                else
                {
                    prossList.Add(process);
                }
            }
            return prossList;
        }

        public static List<string> GetElProssTypes()
        {
            List<string> prossList = new List<string>();
            clsConnectionNew clsCon = new clsConnectionNew();
            string sqlQuery = "Select Distinct(CONVERT(VARCHAR(13), DATENAME(MM, dteffective), 100)) +'-' + convert(varchar, Year(dteffective)) as dteffective           ,dtInput from HR_Earn_Leave order by dteffective Desc";
            IDataReader reader = clsCon.GetReader(sqlQuery);

            string process = "";
            while (reader.Read())
            {
                process = reader["dteffective"].ToString();
                DateTime d = DateTime.Parse(process);
                if (prossList.Contains(process))
                {
                    continue;
                }
                else
                {
                    prossList.Add(process);
                }
            }
            return prossList;
        }
        public static List<string> GetFestBonusProssTypes()
        {
            List<string> prossList = new List<string>();
            clsConnectionNew clsCon = new clsConnectionNew();
            //string sqlQuery = "Select Distinct ProssType,dtBonus as dt from HR_FestBonusAll " +
            //                  "union " +
            //                  "Select Distinct ProssType, dtInput as dt from HR_FestAdvSalary " +
            //                  "order by dt desc";
            string sqlQuery = "Select Distinct Prosstype,dtInput from HR_FestBonusAll " +
                                "union " +
                               "Select Distinct ProssType, dtInput as dt from HR_Gratuity " +
                                "union " +
                               "Select Distinct ProssType, dtInput as dt from HR_NaboBarsha " +
                                "union " +
                               "Select Distinct ProssType, dtInput as dt from HR_RecreationAllow " +
                               "order by dtInput Desc";
            IDataReader reader = clsCon.GetReader(sqlQuery);

            string process = "";
            while (reader.Read())
            {
                process = reader["ProssType"].ToString();
                DateTime d = DateTime.Parse(process);
                if (prossList.Contains(process))
                {
                    continue;
                }
                else
                {
                    prossList.Add(process);
                }
            }
            return prossList;
        }

    }
}