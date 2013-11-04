﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration;
public partial class usercontrol_MutileUploaderUserControl4 : System.Web.UI.UserControl
{
    public string sSaveFolderPath
    {
        get
        {
            if (ViewState["SaveFolderPathUploaderUserControl4"] == null)
            {
                ViewState["SaveFolderPathUploaderUserControl4"] = "";
            }
            return ViewState["SaveFolderPathUploaderUserControl4"].ToString();
        }
        set
        {
            ViewState["SaveFolderPathUploaderUserControl4"] = value;
        }
    }
    public ArrayList filepathlist
    {
        get
        {
            if (ViewState["SavePathUploaderUserControl4"] == null)
            {
                ViewState["SavePathUploaderUserControl4"] = new ArrayList();
            }
            return (ArrayList)ViewState["SavePathUploaderUserControl4"];
        }
        set
        {
            ViewState["SavePathUploaderUserControl4"] = value;
        }

    }
    public ArrayList filenamelist
    {
        get
        {
            if (ViewState["SavenameUploaderUserControl4"] == null)
            {
                ViewState["SavenameUploaderUserControl4"] = new ArrayList();
            }
            return (ArrayList)ViewState["SavenameUploaderUserControl4"];
        }
        set
        {
            ViewState["SavenameUploaderUserControl4"] = value;
        }

    }
    public string sNewName
    {
        get
        {
            if (ViewState["sNewNameUploaderUserControl4"] == null)
            {
                ViewState["sNewNameUploaderUserControl4"] = "";
            }
            return ViewState["sNewNameUploaderUserControl4"].ToString();
        }
        set
        {
            ViewState["sNewNameUploaderUserControl4"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ViewState["dtFileList"] = null;
            //DataTable dtFileList = new DataTable();
            //DataColumn col = new DataColumn("sFilename");
            //dtFileList.Columns.Add(col);
            //DataColumn col1 = new DataColumn("nID");
            //dtFileList.Columns.Add(col1);
            //ViewState["dtFileList"] = dtFileList;
            //gvFileList.DataSource = dtFileList;
            //gvFileList.DataBind();
        }

    }

    public void Refresh()
    {
        gvFileList.DataSource = null;
        gvFileList.DataBind();
    }
    public void SavePath()
    {
        ArrayList filelist = new ArrayList();
        ArrayList namelist = new ArrayList();
        DataTable dtFileList = new DataTable();
        DataColumn col = new DataColumn("sFilename");
        dtFileList.Columns.Add(col);
        DataColumn col1 = new DataColumn("nID");
        dtFileList.Columns.Add(col1);

        HttpFileCollection postedFiles = Request.Files;
        for (int i = 0; i < postedFiles.Count; i++)
        {
            if (postedFiles[i].ContentLength > 0)
            {
                DataRow newrow = dtFileList.NewRow();
                newrow["sFilename"] = postedFiles[i].FileName;
                newrow["nID"] = i.ToString();
                dtFileList.Rows.Add(newrow);
                string basepath = "";


                if (sSaveFolderPath != "")
                    basepath = sSaveFolderPath + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        DateTime.Now.Second.ToString() + "/";

                else

                    basepath = "~/NewsUpload" + "/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                        DateTime.Now.Second.ToString() + "/";



                string filename = postedFiles[i].FileName.Substring(postedFiles[i].FileName.LastIndexOf("\\") + 1);
                if (sNewName != "" && sNewName.Length > 0)
                {
                    filename = sNewName + i + filename.Substring(filename.LastIndexOf("."));
                }


                string sSaveFolderFullPath = Server.MapPath(basepath);

                if (!System.IO.Directory.Exists(sSaveFolderFullPath))
                {
                    Directory.CreateDirectory(sSaveFolderFullPath);
                }
                string filefullpath = sSaveFolderFullPath + filename;
                string sSavepath = basepath + filename;
                postedFiles[i].SaveAs(filefullpath);
                namelist.Add(filename);
                filelist.Add(sSavepath);
            }
        }
        filenamelist = namelist;
        filepathlist = filelist;
        gvFileList.DataSource = dtFileList;
        gvFileList.DataBind();
    }

}