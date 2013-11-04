using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsJob
    {
        public int insert_tb_Job(string psJobPosition, string psJobAdr, string psJobYear, string psJobSalary,string psJobEducation,string pnJobCount,System.DateTime psJobTime,string psDetails, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting,string psJobPositionEN, string psJobAdrEN, string psJobYearEN, string psJobSalaryEN,string psJobEducationEN,string pnJobCountEN,string psDetailsEN)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[21];
                sqlParameters[0] = new SqlParameter("@sJobPosition", SqlDbType.NVarChar);
                sqlParameters[0].Value = psJobPosition;

                sqlParameters[1] = new SqlParameter("@sJobAdr", SqlDbType.NVarChar);
                sqlParameters[1].Value = psJobAdr;

                sqlParameters[2] = new SqlParameter("@sJobYear", SqlDbType.NVarChar);
                sqlParameters[2].Value = psJobYear;

                sqlParameters[3] = new SqlParameter("@sJobSalary", SqlDbType.NVarChar);
                sqlParameters[3].Value = psJobSalary;

                sqlParameters[4] = new SqlParameter("@sJobEducation", SqlDbType.NVarChar);
                sqlParameters[4].Value = psJobEducation;

                sqlParameters[5] = new SqlParameter("@nJobCount", SqlDbType.NVarChar);
                sqlParameters[5].Value = pnJobCount;

                sqlParameters[6] = new SqlParameter("@sJobTime", SqlDbType.DateTime);
                sqlParameters[6].Value = psJobTime;

                sqlParameters[7] = new SqlParameter("@sDetails", SqlDbType.NVarChar);
                sqlParameters[7].Value = psDetails;

                sqlParameters[8] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[8].Value = psCreatedBy;

                sqlParameters[9] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[9].Value = pdCreatedTime;

                sqlParameters[10] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[10].Value = psUpdatedBy;

                sqlParameters[11] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[11].Value = pdUpdatedTime;

                sqlParameters[12] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[12].Value = pbEnable;

                sqlParameters[13] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[13].Value = pnSorting;

                sqlParameters[14] = new SqlParameter("@sJobPositionEN", SqlDbType.NVarChar);
                sqlParameters[14].Value = psJobPositionEN;

                sqlParameters[15] = new SqlParameter("@sJobAdrEN", SqlDbType.NVarChar);
                sqlParameters[15].Value = psJobAdrEN;

                sqlParameters[16] = new SqlParameter("@sJobYearEN", SqlDbType.NVarChar);
                sqlParameters[16].Value = psJobYearEN;

                sqlParameters[17] = new SqlParameter("@sJobSalaryEN", SqlDbType.NVarChar);
                sqlParameters[17].Value = psJobSalaryEN;

                sqlParameters[18] = new SqlParameter("@sJobEducationEN", SqlDbType.NVarChar);
                sqlParameters[18].Value = psJobEducationEN;

                sqlParameters[19] = new SqlParameter("@nJobCountEN", SqlDbType.NVarChar);
                sqlParameters[19].Value = pnJobCountEN;

                sqlParameters[20] = new SqlParameter("@sDetailsEN", SqlDbType.NVarChar);
                sqlParameters[20].Value = psDetailsEN;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Jobs", sqlParameters);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    _nID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                else return _nID;
            }
            catch (Exception ex)
            {
                throw;
            }
            return _nID;
        }
        public DataTable Select_tb_JobBynJobID(int pnJobID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nJobID", SqlDbType.Int);
                    sqlParameters[0].Value = pnJobID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_JobsBynJobID", sqlParameters);
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool update_tb_JobBynJobID(int pnJobID, string psJobPosition, string psJobAdr, string psJobYear, string psJobSalary, string psJobEducation, string pnJobCount, System.DateTime psJobTime, string psDetails, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, string psJobPositionEN, string psJobAdrEN, string psJobYearEN, string psJobSalaryEN, string psJobEducationEN, string pnJobCountEN, string psDetailsEN)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[20];

                sqlParameters[0] = new SqlParameter("@nJobID", SqlDbType.Int);
                sqlParameters[0].Value = pnJobID;

                sqlParameters[1] = new SqlParameter("@sJobPosition", SqlDbType.NVarChar);
                sqlParameters[1].Value = psJobPosition;

                sqlParameters[2] = new SqlParameter("@sJobAdr", SqlDbType.NVarChar);
                sqlParameters[2].Value = psJobAdr;

                sqlParameters[3] = new SqlParameter("@sJobYear", SqlDbType.NVarChar);
                sqlParameters[3].Value = psJobYear;

                sqlParameters[4] = new SqlParameter("@sJobSalary", SqlDbType.NVarChar);
                sqlParameters[4].Value = psJobSalary;

                sqlParameters[5] = new SqlParameter("@sJobEducation", SqlDbType.NVarChar);
                sqlParameters[5].Value = psJobEducation;

                sqlParameters[6] = new SqlParameter("@nJobCount", SqlDbType.NVarChar);
                sqlParameters[6].Value = pnJobCount;

                sqlParameters[7] = new SqlParameter("@sJobTime", SqlDbType.DateTime);
                sqlParameters[7].Value = psJobTime;

                sqlParameters[8] = new SqlParameter("@sDetails", SqlDbType.NVarChar);
                sqlParameters[8].Value = psDetails;

                sqlParameters[9] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[9].Value = psUpdatedBy;

                sqlParameters[10] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[10].Value = pdUpdatedTime;

                sqlParameters[11] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[11].Value = pbEnable;

                sqlParameters[12] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[12].Value = pnSorting;

                sqlParameters[13] = new SqlParameter("@sJobPositionEN", SqlDbType.NVarChar);
                sqlParameters[13].Value = psJobPositionEN;

                sqlParameters[14] = new SqlParameter("@sJobAdrEN", SqlDbType.NVarChar);
                sqlParameters[14].Value = psJobAdrEN;

                sqlParameters[15] = new SqlParameter("@sJobYearEN", SqlDbType.NVarChar);
                sqlParameters[15].Value = psJobYearEN;

                sqlParameters[16] = new SqlParameter("@sJobSalaryEN", SqlDbType.NVarChar);
                sqlParameters[16].Value = psJobSalaryEN;

                sqlParameters[17] = new SqlParameter("@sJobEducationEN", SqlDbType.NVarChar);
                sqlParameters[17].Value = psJobEducationEN;

                sqlParameters[18] = new SqlParameter("@nJobCountEN", SqlDbType.NVarChar);
                sqlParameters[18].Value = pnJobCountEN;

                sqlParameters[19] = new SqlParameter("@sDetailsEN", SqlDbType.NVarChar);
                sqlParameters[19].Value = psDetailsEN;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_JobsBynJobID", sqlParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
