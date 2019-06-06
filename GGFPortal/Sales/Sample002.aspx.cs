using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.ReferenceCode;
using System.Collections.Generic;

namespace GGFPortal.Sales
{
    public partial class Sample002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        Get使用者資料 使用者資料 = new Get使用者資料();
        protected void Page_Load(object sender, EventArgs e)
        {
            FinalDayTB.Attributes["readonly"] = "readonly";
            DateTB.Attributes["readonly"] = "readonly";
            TDFinTB.Attributes["readonly"] = "readonly";
            SamOutTB.Attributes["readonly"] = "readonly";
            SamInTB.Attributes["readonly"] = "readonly";
            //MarkDateTB.Attributes["readonly"] = "readonly";
            if (Session["Uid"]==null)
                UpDateBT.Visible = false;
            if (Session["SampleNbr"] ==null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                Session.RemoveAll();
                Response.Redirect("Sample001.aspx");
            }
            else
            {
                SampleNbrLB.Text = Session["SampleNbr"].ToString();
            }
            if (Session["Site"] == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有公司別，請重新選取');</script>");
                Session.RemoveAll();
                Response.Redirect("Sample001.aspx");
            }
            else
            {
                SiteLB.Text = Session["Site"].ToString();
            }
            if (Session["style"] != null)
            {
                styleLB.Text = "("+ Session["style"].ToString()+")";
            }
            if (!Page.IsPostBack )
            { 
                if (Session["SamDay"]!=null )
                {
                    FinalDayTB.Text = Session["SamDay"].ToString();
                }
                if (Session["TDDay"] != null )
                {
                    TDFinTB.Text = Session["TDDay"].ToString();
                }
                if (Session["SamIn"] != null )
                {
                    SamInTB.Text = Session["SamIn"].ToString();
                }
                if (Session["SamOut"] != null )
                {
                    SamOutTB.Text = Session["SamOut"].ToString();
                }


            }
            string strsql = @"SELECT DISTINCT a.employee_no, b.dept_name + '-' + a.employee_name AS Name FROM bas_employee AS a LEFT OUTER JOIN bas_dept AS b ON a.site = b.site AND a.dept_no = b.dept_no WHERE ";
            string strwhere = "";
            switch (Session["Dept"].ToString())
            {
                case "TD":
                    strwhere = @" (a.dept_no IN ('G010')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";

                    break;
                case "Sam1":
                    strwhere = @" (a.dept_no IN ('M01B','K01B','N01B','E010')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";
                    break;
                case "Sam2":
                    strwhere = @" (a.dept_no IN ('D010','N01A','M01A','K01A','D01A')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";
                    SamOutBT.Visible = true;
                    SamOutTB.Enabled = true;
                    break;
                default:
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('無部門資料，請重新選取');</script>");
                    Session.RemoveAll();
                    Response.Redirect("Sample001.aspx");
                    break;
            }
            if(!string.IsNullOrEmpty(strwhere))
            {
                if (UserDDL.Items.Count == 0)
                {
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        DataSet Ds = new DataSet();
                        
                        SqlDataAdapter myAdapter = new SqlDataAdapter(strsql+ strwhere, Conn);
                        myAdapter.Fill(Ds, "DDL1");
                        if (Ds.Tables["DDL1"].Rows.Count > 0)
                        {
                            //for (int i = 0; i < Ds.Tables["DDL1"].Rows.Count; i++)
                            //{
                            //    if (i == 0)
                            //    {
                            //        UserDDL.Items.Add("");
                            //    }
                            //    ListIem items = new ListItem();
                            //    items.Text = Ds.Tables["DDL1"].Rows[i][""].ToString().Trim();
                            //    items.Value = Ds.Tables["DDL1"].Rows[i][""].ToString().Trim();
                            //    UserDDL.Items.Add(Ds.Tables["DDL1"].Rows[i][""].ToString());
                            //}
                            UserDDL.Items.Add("");
                            List<ListItem> ListDDL1 = new List<ListItem>();
                            foreach (DataRow item in Ds.Tables["DDL1"].Rows)
                            {
                                ListItem li = new ListItem(item["Name"].ToString(), item["employee_no"].ToString());
                                ListDDL1.Add(li);
                            }
                            UserDDL.Items.AddRange(ListDDL1.ToArray());
                        }
                    }
                }
            }
            string xxx = "";
            xxx=使用者資料.取得電腦名稱();
        }

        protected void AddBT_Click(object sender, EventArgs e)
        {
            string strCheck = CheckData();
            if (strCheck == "")
            {
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("InsertGGFRequestSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"INSERT INTO [dbo].[GGFRequestSam]
                                            ([site]
                                            ,[sam_nbr]
                                            ,[SampleType]
                                            ,[SampleUser]
                                            ,[SampleNo]
                                            ,[Qty]
                                            ,[SampleCreatDate]
                                            ,[Creator]
                                            ,[Remark]
                                            )
                                        VALUES
                                            (@site
                                            ,@sam_nbr
                                            ,@SampleType
                                            ,@SampleUser
                                            ,@SampleNo
                                            ,@Qty
                                            ,@SampleCreatDate
                                            ,@Creator
                                            ,@Remark
                                            )
                                            ");
                        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                        command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                        command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@Qty", SqlDbType.Decimal).Value = QtyTB.Text.Trim();
                        command1.Parameters.Add("@SampleCreatDate", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyyMMdd");
                        command1.Parameters.Add("@Creator", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = RemarkTB.Text.Trim();
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();

                        transaction1.Commit();

                        switch (TypeDDL.SelectedItem.Text)
                        {
                            case "TD":
                                //取消TD自動UPdate
                                if (F_UpdataWorkDate("TD", DateTime.Now.ToString("yyyy/MM/dd")))
                                    TDFinTB.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                break;
                            case "樣衣":
                                //if (F_UpdataWorkDate("樣衣完成", DateTime.Now.ToString("yyyy/MM/dd")))
                                //    SamOutTB.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                break;
                            case "裁版":
                                if (F_UpdataWorkDate("樣衣收單", DateTime.Now.ToString("yyyy/MM/dd")))
                                    SamInBT.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                break;
                            case "PP":
                                break;
                            case "尺寸套":
                                break;
                            default:
                                //if (F_UpdataWorkDate("打版完成", DateTime.Now.ToString("yyyy/MM/dd")))
                                //    FinalDayTB.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                break;
                        }

                        
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Insert Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + strCheck + "');</script>");
            }
                

        }

        protected void ClearData()
        {
            TypeDDL.SelectedValue = "";
            UserDDL.SelectedValue = "";
            QtyTB.Text = "";
            GridView1.DataBind();
            AddBT.Visible = true;
            UpDateBT.Visible = false;
            CancelBT.Visible = false;
            Session["Uid"] = null;
            GridView1.SelectedIndex = -1;
            DateLB.Visible = false;
            DateTB.Text = "";
            DateTB.Visible = false;
            UserLB.Text = "";
            RemarkTB.Text = "";
        }

        protected void UpDateBT_Click1(object sender, EventArgs e)
        {
            string strCheck = CheckData();
            if (strCheck == "")
            {
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("UpdateGGFRequestSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [SampleType] = @SampleType 
                                                            ,[SampleUser] = @SampleUser,[SampleNo] = @SampleNo
                                                            ,[Qty] = @Qty,[SampleCreatDate] = @SampleCreatDate
                                                            ,[Modifier] = @Modifier
                                                            ,[ModifyDate]=GETDATE() 
                                                            ,[Remark]=@Remark
                                                            WHERE uid = {0} ", Session["Uid"].ToString());
                        command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                        command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@Qty", SqlDbType.Decimal).Value = QtyTB.Text.Trim();
                        command1.Parameters.Add("@SampleCreatDate", SqlDbType.NVarChar).Value = DateTB.Text;
                        command1.Parameters.Add("@Modifier", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = RemarkTB.Text.Trim();
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        string strdate = DateTB.Text.Substring(0, 4) +"/"+ DateTB.Text.Substring(4, 2) + "/" + DateTB.Text.Substring(6, 2);
                        switch (TypeDDL.SelectedItem.Text)
                        {
                            case "TD":
                                if(F_UpdataWorkDate("TD", strdate))
                                    TDFinTB.Text = strdate;
                                break;
                            case "樣衣":
                                //if (F_UpdataWorkDate("樣衣完成", strdate))
                                //    SamOutTB.Text = strdate;

                                break;
                            case "裁版":
                                if (F_UpdataWorkDate("樣衣收單", strdate))
                                    SamInTB.Text = strdate;
                                break;
                            case "PP":
                                break;
                            case "尺寸套":
                                break;
                            default:
                                if (F_UpdataWorkDate("打版完成", strdate))
                                    FinalDayTB.Text = strdate;
                                break;
                        }
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ strCheck + "');</script>");
            }
                
        }

        protected void GridView1_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {
            //Session["Uid"] = this.GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
            //if (UserDDL.Items.Contains(UserDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text))==true)
            //{
            //    UserDDL.SelectedValue = UserDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text).Value;
            //    UserLB.Text = "";
            //}
            //else
            //{
            //    UserDDL.SelectedValue = "";
            //    UserLB.Text = "離職人員";
            //}
            //TypeDDL.SelectedValue = TypeDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[5].Text).Value;
            //QtyTB.Text = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text;
            //DateTB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text=="沒有資料")?"": this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text;
            //RemarkTB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[11].Text == "沒有資料") ? "" : this.GridView1.Rows[e.NewSelectedIndex].Cells[11].Text;
            //DateTB.Visible = true;
            //UpDateBT.Visible = true;
            //CancelBT.Visible = true;
            //DateLB.Visible = true;
            //DateTB.Visible = true;
            //AddBT.Visible = false;
            
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            
        }

        protected void CancelBT_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        protected string CheckData()
        {
            string strerror = "";
            if (Session["SampleNbr"] == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                strerror = "沒有樣品單號";
            }
            if (TypeDDL.SelectedValue == "")
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理方式" : "沒有選擇處理方式";
            }
            if (UserDDL.SelectedValue == "")
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理人員" : "沒有選擇處理人員";
            }
            if(DateTB.Text==""&& UpDateBT.Visible==true)
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理日期" : "沒有選擇處理日期";
            }
            if(QtyTB.Text!="")
            { 
                string RegularExpressions = null;
                RegularExpressions = "^[0-9]+(.[0-9]{1})?$";
                Match m = Regex.Match(QtyTB.Text, RegularExpressions);
                strerror += (m.Success) ? "" : (strerror.Length > 0) ? "、數量格式錯誤" : "數量格式錯誤";
            }
            

      

            return (strerror == "") ? "" : "資料錯誤："+strerror;
        }

        protected void IndexBT_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Sample001.aspx");
        }

        protected void DayUpdateBT_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(FinalDayTB.Text))
            {
                #region old code
                //using (SqlConnection conn1 = new SqlConnection(strConnectString))
                //{
                //    SqlCommand command1 = conn1.CreateCommand();
                //    SqlTransaction transaction1;
                //    conn1.Open();
                //    transaction1 = conn1.BeginTransaction("UpdateGGFSam");

                //    command1.Connection = conn1;
                //    command1.Transaction = transaction1;
                //    try
                //    {
                //        //TypeLB.Text = i.ToString();
                //        command1.CommandText = @"UPDATE [dbo].[samc_reqm] SET [samc_fin_date] = @samc_fin_date WHERE sam_nbr = @sam_nbr and site =@site ";
                //        command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = Convert.ToDateTime(FinalDayTB.Text);
                //        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                //        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                //        command1.ExecuteNonQuery();
                //        command1.Parameters.Clear();
                //        transaction1.Commit();
                //        ClearData();
                //    }
                //    catch (Exception ex1)
                //    {
                //        try
                //        {
                //            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                //        }
                //        catch (Exception ex2)
                //        {
                //            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                //        }
                //        finally
                //        {
                //            transaction1.Rollback();
                //            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('打版預計完成日上傳失敗');</script>");
                //        }
                //    }
                //    finally
                //    {
                //        conn1.Close();
                //        conn1.Dispose();
                //        command1.Dispose();
                //    }
                //}
                #endregion
                //F_UpdataWorkDate("打版完成");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇打版完成日');</script>");
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //int x = 0;
            //if (e.CommandName=="Select")
            //{
            //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //    string strid = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex.ToString();
            //}
            if (e.CommandName == "EditeDetail")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                //Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                Session["uid"] = strid;
                Response.Redirect("Sample008.aspx");
            }
            else if (e.CommandName == "EditData")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Session["Uid"] = this.GridView1.Rows[row.RowIndex].Cells[3].Text;
                if (UserDDL.Items.Contains(UserDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[6].Text)) == true)
                {
                    UserDDL.SelectedValue = UserDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[6].Text).Value;
                    UserLB.Text = "";
                }
                else
                {
                    UserDDL.SelectedValue = "";
                    UserLB.Text = "離職人員";
                }
                TypeDDL.SelectedValue = TypeDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[5].Text).Value;
                QtyTB.Text = GridView1.Rows[row.RowIndex].Cells[7].Text;
                DateTB.Text = (this.GridView1.Rows[row.RowIndex].Cells[8].Text == "沒有資料") ? "" : this.GridView1.Rows[row.RowIndex].Cells[8].Text;
                RemarkTB.Text = (this.GridView1.Rows[row.RowIndex].Cells[11].Text == "沒有資料") ? "" : this.GridView1.Rows[row.RowIndex].Cells[11].Text;
                DateTB.Visible = true;
                UpDateBT.Visible = true;
                CancelBT.Visible = true;
                DateLB.Visible = true;
                DateTB.Visible = true;
                AddBT.Visible = false;
            }
            else if (e.CommandName == "Delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                //string strid = GridView1.DataKeys[e.RowIndex].Value.ToString();

                using (SqlConnection conn = new SqlConnection(strConnectString))
                {
                    conn.Open();
                    SqlCommand command1 = conn.CreateCommand();
                    SqlTransaction transaction1;
                    transaction1 = conn.BeginTransaction("UpdateGGFRequestSam");

                    command1.Connection = conn;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [Flag] = 1 ,[ModifyDate]=GETDATE() ,Modifier=@Modifier  WHERE uid = {0} ", strid);
                        command1.Parameters.Add("@Modifier", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Delete Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('刪除失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                        command1.Dispose();
                    }

                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button 馬克BT = (Button)e.Row.FindControl("修改馬克");
                Button 編輯BT = (Button)e.Row.FindControl("Button2");
                Button 刪除BT = (Button)e.Row.FindControl("Button1");

                switch (Session["Dept"].ToString())
                {
                    //TD
                    case "TD":
                        if (e.Row.Cells[5].Text == "打版"|| e.Row.Cells[5].Text == "樣衣" || e.Row.Cells[5].Text== "裁版")
                        {
                            編輯BT.Visible = false;
                            刪除BT.Visible = false;
                            
                        }
                        馬克BT.Visible = false;
                        break;
                        //打版
                    case "Sam1":
                        if (e.Row.Cells[5].Text != "打版")
                        {
                            編輯BT.Visible = false;
                            刪除BT.Visible = false;
                            馬克BT.Visible = false;
                        }
                            
                        break;
                        //樣衣
                    case "Sam2":
                        if (e.Row.Cells[5].Text == "打版" || e.Row.Cells[5].Text == "TD" || e.Row.Cells[5].Text == "PP" || e.Row.Cells[5].Text == "尺寸套")
                        {
                            編輯BT.Visible = false;
                            刪除BT.Visible = false;
                            
                        }
                        馬克BT.Visible = false;
                        break;

                    default:
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('無部門資料，請重新選取');</script>");
                        Session.RemoveAll();
                        Response.Redirect("Sample001.aspx");
                        break;
                }


            }
        }
        Boolean F_UpdataWorkDate(string updataString,string update)
        {
            #region check TD Update
            //bool bcheck = true;
            bool UpDateCheck = true;
            if (updataString == "TD")
            {
                using (SqlConnection conn = new SqlConnection(strConnectString))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(
                        string.Format(@"
                        select * from [GGFRequestSam] where sam_nbr ='{0}' and Flag=0 and SampleType=4 and SampleCreatDate >'{1}'
                        ",SamNbrLB.Text,update), conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                    if (dt.Rows.Count == 0)
                        UpDateCheck = false;
                }
            }
            #endregion
            
            if(UpDateCheck)
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    string strDate="";

                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("UpdateGGFSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        if (updataString == "打版完成")
                            strDate = @"[samc_fin_date] = @samc_fin_date";
                        else if(updataString == "樣衣收單")
                            strDate = @"[sam_in_date] = @Sam_In_Date ,[s_real_arrival_date]=@s_real_arrival_date ,online_date=@online_date";
                        else if (updataString == "樣衣完成")
                        { 
                            strDate = @"[sam_out_date] = @Sam_Out_Date , [finish_date]=@finish_date";
                        }
                        else
                            strDate = @"[td_fin_date] = @TD_Fin_Date";

                        command1.CommandText = string.Format(@"UPDATE [dbo].[samc_reqm] SET {0} WHERE sam_nbr = @sam_nbr and site =@site ", strDate);

                        if (updataString == "打版完成")
                            command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                        else if (updataString == "樣衣收單")
                        {
                            command1.Parameters.Add("@Sam_In_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                            command1.Parameters.Add("@s_real_arrival_date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                            command1.Parameters.Add("@online_date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                        }
                        else if (updataString == "樣衣完成")
                        { 
                            command1.Parameters.Add("@Sam_Out_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                            command1.Parameters.Add("@finish_date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);
                        }
                        else
                            command1.Parameters.Add("@TD_Fin_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(update);

                        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        UpDateCheck = false;
                        try
                        {
                            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ updataString + "日上傳失敗');</script>");
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                    }
                }
            return UpDateCheck;
        }

        protected void SamInBT_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(SamInTB.Text))
            //{
            //    F_UpdataWorkDate("樣衣收單");
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇樣衣收單日');</script>");
            //}
        }

        protected void SamOutBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SamOutTB.Text))
            {
                F_UpdataWorkDate("樣衣完成",SamOutTB.Text);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇樣衣完成日');</script>");
            }
        }

        protected void TDFinBT_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(TDFinTB.Text))
            //{
            //    F_UpdataWorkDate("TD完成");
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇TD完成日');</script>");
            //}
        }

        //protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        //{
        //    string strsql = @"SELECT DISTINCT a.employee_no, b.dept_name + '-' + a.employee_name AS Name FROM bas_employee AS a LEFT OUTER JOIN bas_dept AS b ON a.site = b.site AND a.dept_no = b.dept_no WHERE ";
        //    switch (Session["Dept"].ToString())
        //    {
        //        case "TD":
        //            SqlDataSource2.SelectCommand = strsql+ @" (a.dept_no IN ('G010')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";
        //            break;
        //        case "Sam1":
        //            SqlDataSource2.SelectCommand = strsql + @" (a.dept_no IN ('M01B','K01B','N01B','E010')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";
        //            break;
        //        case "Sam2":
        //            SqlDataSource2.SelectCommand = strsql + @" (a.dept_no IN ('D010','N01A','M01A','K01A','D01A')) AND (a.employee_status <> 'IA') ORDER BY Name, a.employee_no";
        //            break;
        //        default:
        //            SqlDataSource2.SelectCommand = "";
        //            break;
        //    }
            

        //}

        //protected void SqlDataSource2_Selected(object sender, SqlDataSourceStatusEventArgs e)
        //{
        //    SqlDataSource2.DataBind();
        //}
    }
}