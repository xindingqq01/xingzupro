﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsContact
    {
        public int insert_tb_Contact(string psTitle, string psName, string psCompanyName, string psAddress, string psEmail, string psFax, string psPhone, string psContents, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, bool pbCheck, string psWeb, string psPositon)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[17];
                sqlParameters[0] = new SqlParameter("@sTitle", SqlDbType.NVarChar);
                sqlParameters[0].Value = psTitle;

                sqlParameters[1] = new SqlParameter("@sName", SqlDbType.NVarChar);
                sqlParameters[1].Value = psName;

                sqlParameters[2] = new SqlParameter("@sCompanyName", SqlDbType.NVarChar);
                sqlParameters[2].Value = psCompanyName;

                sqlParameters[3] = new SqlParameter("@sAddress", SqlDbType.NVarChar);
                sqlParameters[3].Value = psAddress;

                sqlParameters[4] = new SqlParameter("@sEmail", SqlDbType.NVarChar);
                sqlParameters[4].Value = psEmail;

                sqlParameters[5] = new SqlParameter("@sFax", SqlDbType.NVarChar);
                sqlParameters[5].Value = psFax;

                sqlParameters[6] = new SqlParameter("@sPhone", SqlDbType.NVarChar);
                sqlParameters[6].Value = psPhone;

                sqlParameters[7] = new SqlParameter("@sContents", SqlDbType.NVarChar);
                sqlParameters[7].Value = psContents;

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

                sqlParameters[14] = new SqlParameter("@bCheck", SqlDbType.Bit);
                sqlParameters[14].Value = pbCheck;

                sqlParameters[15] = new SqlParameter("@sWeb", SqlDbType.NVarChar);
                sqlParameters[15].Value = psWeb;

                sqlParameters[16] = new SqlParameter("@sPositon", SqlDbType.NVarChar);
                sqlParameters[16].Value = psPositon;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Contact", sqlParameters);
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
        public DataTable Select_tb_ContactBynContactID(int pnContactID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nContactID", SqlDbType.Int);
                    sqlParameters[0].Value = pnContactID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ContactBynContactID", sqlParameters);
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
        public bool update_tb_ContactBynContactID(int nContactID,bool pbCheck)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@nContactID", SqlDbType.Int);
                sqlParameters[0].Value = nContactID;

                sqlParameters[1] = new SqlParameter("@bCheck", SqlDbType.Bit);
                sqlParameters[1].Value = pbCheck;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_ContactBynContactID", sqlParameters);
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
