using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DBLL
{
  public   class AlbumDBLL
    {


         public DataTable selecttb_AlbumOfAll(bool bIncludeUnable)
        {

            string cmd = "sp_selectNormalTableOfAll";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
            sqlParameters[0].Value = bIncludeUnable;

            sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
            sqlParameters[1].Value = "tb_Album";

            try
            {
                DataTable dt = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.StoredProcedure, cmd, sqlParameters).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

         public DataTable selecttb_AlbumBynDMID(int nDMID)
         {
             string cmd = " Select * from [tb_Album] where nAlbumID=@nAlbumID and bEnable=1 ";
             SqlParameter[] sqlParameters = new SqlParameter[1];
             sqlParameters[0] = new SqlParameter("@nAlbumID", SqlDbType.Int);
             sqlParameters[0].Value = nDMID;


             try
             {
                 DataTable dt = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.Text, cmd, sqlParameters).Tables[0];
                 return dt;
             }
             catch (Exception ex)
             {
                 throw;
             }
         }

         public DataTable selecttb_AlbumOfAllBynRootDMID(int nTCategoryID)
         {

             string cmd = "[sp_selectNormalTableOfAllByfield]";
             SqlParameter[] sqlParameters = new SqlParameter[4];
             sqlParameters[0] = new SqlParameter("@bIncludeUnable", SqlDbType.Bit);
             sqlParameters[0].Value = false;

             sqlParameters[1] = new SqlParameter("@sTableName", SqlDbType.NVarChar);
             sqlParameters[1].Value = "tb_Album";

             sqlParameters[2] = new SqlParameter("@sfieldname", SqlDbType.NVarChar);
             sqlParameters[2].Value = "nTCategoryID";

             sqlParameters[3] = new SqlParameter("@sfieldvalue", SqlDbType.NVarChar);
             sqlParameters[3].Value = nTCategoryID.ToString();
             try
             {
                 DataTable dt = sqlhelper.SqlHelper.ExecuteDataset(dbstring.dbconnectionstring, CommandType.StoredProcedure, cmd, sqlParameters).Tables[0];
                 return dt;
             }
             catch (Exception ex)
             {
                 throw;
             }

         }
    }
}
