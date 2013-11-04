using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBLL
{
    public class clsProduct
    {


        public int insert_tb_Product(int pnProductCategoryID, bool pbHot, string psPImagePath, string psProductNameCN, string psProductNameEN, string psSummaryCN, string psSummaryEN, string psIntroCN,
            string psIntroEN, string psCreatedBy, System.DateTime pdCreatedTime, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, string psThumbPath, string psEnsitivityCN,
            string psEnsitivityEN, string psChannelBalanceCN, string psChannelBalanceEN, string psImpedanceCN, string psImpedanceEN, string psFrequencyCN, string psFrequencyEN, string psRatedPowerCN,
            string psRatedPowerEN, string psMaximumPowerCN, string psMaximumPowerEN, string psBrandNameCN, string psBrandNameEN)
        {
            int _nID = 0;
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                SqlParameter[] sqlParameters = new SqlParameter[30];
                sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                sqlParameters[0].Value = pnProductCategoryID;

                sqlParameters[1] = new SqlParameter("@bHot", SqlDbType.Bit);
                sqlParameters[1].Value = pbHot;

                sqlParameters[2] = new SqlParameter("@sPImagePath", SqlDbType.NVarChar);
                sqlParameters[2].Value = psPImagePath;

                sqlParameters[3] = new SqlParameter("@sProductNameCN", SqlDbType.NVarChar);
                sqlParameters[3].Value = psProductNameCN;

                sqlParameters[4] = new SqlParameter("@sProductNameEN", SqlDbType.NVarChar);
                sqlParameters[4].Value = psProductNameEN;

                sqlParameters[5] = new SqlParameter("@sSummaryCN", SqlDbType.NVarChar);
                sqlParameters[5].Value = psSummaryCN;

                sqlParameters[6] = new SqlParameter("@sSummaryEN", SqlDbType.NVarChar);
                sqlParameters[6].Value = psSummaryEN;

                sqlParameters[7] = new SqlParameter("@sIntroCN", psIntroCN);

                sqlParameters[8] = new SqlParameter("@sIntroEN", psIntroEN);

                sqlParameters[9] = new SqlParameter("@sCreatedBy", SqlDbType.NVarChar);
                sqlParameters[9].Value = psCreatedBy;

                sqlParameters[10] = new SqlParameter("@dCreatedTime", SqlDbType.DateTime);
                sqlParameters[10].Value = pdCreatedTime;

                sqlParameters[11] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[11].Value = psUpdatedBy;

                sqlParameters[12] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[12].Value = pdUpdatedTime;

                sqlParameters[13] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[13].Value = pbEnable;

                sqlParameters[14] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[14].Value = pnSorting;

                sqlParameters[15] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[15].Value = psThumbPath;

                sqlParameters[16] = new SqlParameter("@sEnsitivityCN", SqlDbType.NVarChar);
                sqlParameters[16].Value = psEnsitivityCN;

                sqlParameters[17] = new SqlParameter("@sEnsitivityEN", SqlDbType.NVarChar);
                sqlParameters[17].Value = psEnsitivityEN;

                sqlParameters[18] = new SqlParameter("@sChannelBalanceCN", SqlDbType.NVarChar);
                sqlParameters[18].Value = psChannelBalanceCN;

                sqlParameters[19] = new SqlParameter("@sChannelBalanceEN", SqlDbType.NVarChar);
                sqlParameters[19].Value = psChannelBalanceEN;

                sqlParameters[20] = new SqlParameter("@sImpedanceCN", SqlDbType.NVarChar);
                sqlParameters[20].Value = psImpedanceCN;

                sqlParameters[21] = new SqlParameter("@sImpedanceEN", SqlDbType.NVarChar);
                sqlParameters[21].Value = psImpedanceEN;

                sqlParameters[22] = new SqlParameter("@sFrequencyCN", SqlDbType.NVarChar);
                sqlParameters[22].Value = psFrequencyCN;

                sqlParameters[23] = new SqlParameter("@sFrequencyEN", SqlDbType.NVarChar);
                sqlParameters[23].Value = psFrequencyEN;

                sqlParameters[24] = new SqlParameter("@sRatedPowerCN", SqlDbType.NVarChar);
                sqlParameters[24].Value = psRatedPowerCN;

                sqlParameters[25] = new SqlParameter("@sRatedPowerEN", SqlDbType.NVarChar);
                sqlParameters[25].Value = psRatedPowerEN;

                sqlParameters[26] = new SqlParameter("@sMaximumPowerCN", SqlDbType.NVarChar);
                sqlParameters[26].Value = psMaximumPowerCN;

                sqlParameters[27] = new SqlParameter("@sMaximumPowerEN", SqlDbType.NVarChar);
                sqlParameters[27].Value = psMaximumPowerEN;

                sqlParameters[28] = new SqlParameter("@sBrandNameCN", SqlDbType.NVarChar);
                sqlParameters[28].Value = psBrandNameCN;

                sqlParameters[29] = new SqlParameter("@sBrandNameEN", SqlDbType.NVarChar);
                sqlParameters[29].Value = psBrandNameEN;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_insert_tb_Product", sqlParameters);
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
        public DataTable Select_tb_ProductBybHot(bool pbHot)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@bHot", pbHot);

                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBybHot", sqlParameters);
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
        public DataTable Select_tb_ProductBynProductCategoryID(int pnProductCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynProductCategoryID", sqlParameters);
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
        public DataTable Select_tb_ProductBynProductID(int pnProductID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynProductID", sqlParameters);
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
        public DataTable Select_tb_ProductBynProductIDEnable(int pnProductID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                    sqlParameters[0].Value = pnProductID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynProductIDEnable", sqlParameters);
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
        public DataTable Select_tb_ProductBynParentCategoryID(int nParentCategoryID)
        {
            try
            {
                try
                {
                    string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here

                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@nParentCategoryID", SqlDbType.Int);
                    sqlParameters[0].Value = nParentCategoryID;



                    DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_Select_tb_ProductBynParentCategoryID", sqlParameters);
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
        public bool update_tb_ProductBynProductID(int nProductID, int nProductCategoryID, bool bHot,string sPImagePath, string sProductNameCN, string sProductNameEN, string psSummaryCN, string psSummaryEN,
            string sIntroCN, string sIntroEN, string psUpdatedBy, System.DateTime pdUpdatedTime, bool pbEnable, int pnSorting, string psThumbPath, string psEnsitivityCN,
            string psEnsitivityEN, string psChannelBalanceCN, string psChannelBalanceEN, string psImpedanceCN, string psImpedanceEN, string psFrequencyCN, string psFrequencyEN, string psRatedPowerCN,
            string psRatedPowerEN, string psMaximumPowerCN, string psMaximumPowerEN, string psBrandNameCN, string psBrandNameEN)
        {
            try
            {
                string connectionString = dbstring.dbconnectionstring.ToString();  // get your connection string here
                SqlParameter[] sqlParameters = new SqlParameter[29];
                sqlParameters[0] = new SqlParameter("@nProductID", SqlDbType.Int);
                sqlParameters[0].Value = nProductID;

                sqlParameters[1] = new SqlParameter("@nProductCategoryID", SqlDbType.Int);
                sqlParameters[1].Value = nProductCategoryID;

                sqlParameters[2] = new SqlParameter("@bHot", SqlDbType.Bit);
                sqlParameters[2].Value = bHot;

                sqlParameters[3] = new SqlParameter("@sPImagePath", SqlDbType.NVarChar);
                sqlParameters[3].Value = sPImagePath;

                sqlParameters[4] = new SqlParameter("@sProductNameCN", SqlDbType.NVarChar);
                sqlParameters[4].Value = sProductNameCN;

                sqlParameters[5] = new SqlParameter("@sProductNameEN", SqlDbType.NVarChar);
                sqlParameters[5].Value = sProductNameEN;

                sqlParameters[6] = new SqlParameter("@sSummaryCN", SqlDbType.NVarChar);
                sqlParameters[6].Value = psSummaryCN;

                sqlParameters[7] = new SqlParameter("@sSummaryEN", SqlDbType.NVarChar);
                sqlParameters[7].Value = psSummaryEN;

                sqlParameters[8] = new SqlParameter("@sIntroCN", SqlDbType.NVarChar);
                sqlParameters[8].Value = sIntroCN;

                sqlParameters[9] = new SqlParameter("@sIntroEN", SqlDbType.NVarChar);
                sqlParameters[9].Value = sIntroEN;

                sqlParameters[10] = new SqlParameter("@sUpdatedBy", SqlDbType.NVarChar);
                sqlParameters[10].Value = psUpdatedBy;

                sqlParameters[11] = new SqlParameter("@dUpdatedTime", SqlDbType.DateTime);
                sqlParameters[11].Value = pdUpdatedTime;

                sqlParameters[12] = new SqlParameter("@bEnable", SqlDbType.Bit);
                sqlParameters[12].Value = pbEnable;

                sqlParameters[13] = new SqlParameter("@nSorting", SqlDbType.Int);
                sqlParameters[13].Value = pnSorting;

                sqlParameters[14] = new SqlParameter("@sThumbPath", SqlDbType.NVarChar);
                sqlParameters[14].Value = psThumbPath;

                sqlParameters[15] = new SqlParameter("@sEnsitivityCN", SqlDbType.NVarChar);
                sqlParameters[15].Value = psEnsitivityCN;

                sqlParameters[16] = new SqlParameter("@sEnsitivityEN", SqlDbType.NVarChar);
                sqlParameters[16].Value = psEnsitivityEN;

                sqlParameters[17] = new SqlParameter("@sChannelBalanceCN", SqlDbType.NVarChar);
                sqlParameters[17].Value = psChannelBalanceCN;

                sqlParameters[18] = new SqlParameter("@sChannelBalanceEN", SqlDbType.NVarChar);
                sqlParameters[18].Value = psChannelBalanceEN;

                sqlParameters[19] = new SqlParameter("@sImpedanceCN", SqlDbType.NVarChar);
                sqlParameters[19].Value = psImpedanceCN;

                sqlParameters[20] = new SqlParameter("@sImpedanceEN", SqlDbType.NVarChar);
                sqlParameters[20].Value = psImpedanceEN;

                sqlParameters[21] = new SqlParameter("@sFrequencyCN", SqlDbType.NVarChar);
                sqlParameters[21].Value = psFrequencyCN;

                sqlParameters[22] = new SqlParameter("@sFrequencyEN", SqlDbType.NVarChar);
                sqlParameters[22].Value = psFrequencyEN;

                sqlParameters[23] = new SqlParameter("@sRatedPowerCN", SqlDbType.NVarChar);
                sqlParameters[23].Value = psRatedPowerCN;

                sqlParameters[24] = new SqlParameter("@sRatedPowerEN", SqlDbType.NVarChar);
                sqlParameters[24].Value = psRatedPowerEN;

                sqlParameters[25] = new SqlParameter("@sMaximumPowerCN", SqlDbType.NVarChar);
                sqlParameters[25].Value = psMaximumPowerCN;

                sqlParameters[26] = new SqlParameter("@sMaximumPowerEN", SqlDbType.NVarChar);
                sqlParameters[26].Value = psMaximumPowerEN;

                sqlParameters[27] = new SqlParameter("@sBrandNameCN", SqlDbType.NVarChar);
                sqlParameters[27].Value = psBrandNameCN;

                sqlParameters[28] = new SqlParameter("@sBrandNameEN", SqlDbType.NVarChar);
                sqlParameters[28].Value = psBrandNameEN;
                DataSet ds = sqlhelper.SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_update_tb_ProductBynProductID", sqlParameters);
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
