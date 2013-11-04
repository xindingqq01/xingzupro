using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsPartners
    {


        public int insert_tb_Partners(string psPartnersName,string psImageNameCN, string psImageNameEN, string psWebAdr, string psImagePath, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@sPartnersName", SqlDbType.NVarChar);
                sqlParameters[0].Value = psPartnersName;

                sqlParameters[1] = new SqlParameter("@sImageNameCN", SqlDbType.NVarChar);
                sqlParameters[1].Value = psImageNameCN;

                sqlParameters[2] = new SqlParameter("@sImageNameEN", SqlDbType.NVarChar);
                sqlParameters[2].Value = psImageNameEN;

                sqlParameters[3] = new SqlParameter("@sWebAdr", SqlDbType.NVarChar);
                sqlParameters[3].Value = psWebAdr;

                sqlParameters[4] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[4].Value = psImagePath;

                sqlParameters[5] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[5].Value = psCreatedBy;

                sqlParameters[6] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[6].Value = pdCreatedTime;

                sqlParameters[7] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[7].Value = psUpdatedBy;

                sqlParameters[8] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[8].Value = pdUpdatedTime;

                sqlParameters[9] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[9].Value = pbEnable;

                sqlParameters[10] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[10].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Partners", sqlParameters);
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


        public DataTable Select_tb_PartnersBynPartnersID(int pnPartnersID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nPartnersID", SqlDbType.Int);
                    sqlParameters[0].Value = pnPartnersID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_PartnersBynPartnersID", sqlParameters);
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
        public bool update_tb_PartnersBynPartnersID(int nPartnersID,string sPartnersName, string sImageNameCN, string sImageNameEN, string psWebAdr, string sImagePath, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[10];
                sqlParameters[0] = new SqlParameter("@nPartnersID", SqlDbType.Int);
                sqlParameters[0].Value = nPartnersID;

                sqlParameters[1] = new SqlParameter("@sPartnersName", SqlDbType.NVarChar);
                sqlParameters[1].Value = sPartnersName;

                sqlParameters[2] = new SqlParameter("@sImageNameCN", SqlDbType.NVarChar);
                sqlParameters[2].Value = sImageNameCN;

                sqlParameters[3] = new SqlParameter("@sImageNameEN", SqlDbType.NVarChar);
                sqlParameters[3].Value = sImageNameEN;

                sqlParameters[4] = new SqlParameter("@sWebAdr", SqlDbType.NVarChar);
                sqlParameters[4].Value = psWebAdr;

                sqlParameters[5] = new SqlParameter("@sImagePath", SqlDbType.NVarChar);
                sqlParameters[5].Value = sImagePath;

                sqlParameters[6] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[6].Value = psUpdatedBy;

                sqlParameters[7] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[7].Value = pdUpdatedTime;

                sqlParameters[8] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[8].Value = pbEnable;

                sqlParameters[9] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[9].Value = pnSorting;

                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_PartnersBynPartnersID", sqlParameters);
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

        public bool sp_DeleteNormalTableByIDPartners(int pnKeyID, string psTableName)
        {
            string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@nKeyID", SqlDbType.Int);
            sqlParameters[0].Value = pnKeyID;

            sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
            sqlParameters[1].Value = psTableName;
            try
            {
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_DeleteNormalTableByIDPartners", sqlParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
