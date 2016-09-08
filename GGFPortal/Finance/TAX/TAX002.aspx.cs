using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance.TAX
{

    public partial class TAX002 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止上一頁
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);
            DeleteBT.Attributes.Add("onclick ", "return confirm( '確定要刪除嗎');");
            if (IsPostBack)
            {
                Session["DeleteCheck"] = "N";
            }
            if (DateDDL.Items.Count == 0)
            {
                POPPanel_ModalPopupExtender.Hide();
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015) * 12 + (DateTime.Now.Month - 12);


                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        DateDDL.Items.Add("");
                    }
                    DateDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (checkData())
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Please Select Search Data');</script>");
            else
            {
                DBInit2();//Search Data
                DBInit();

            }
        }
        private void DBInit2()
        {
            int iMonth, iYear;
            iYear = int.Parse(DateDDL.SelectedItem.Text.Substring(0, 4));
            iMonth = int.Parse(DateDDL.SelectedItem.Text.Substring(4, 2));
            string strsql = string.Format(@"select a.*,b.CheckFlag,c.vendor_name,dbo.F_PkdCheck(b.timestamp) AS PkdSelect  from purc_pkm a left join purc_pkm_for_acr b on a.site=b.site and a.pak_nbr=b.pak_nbr and b.CheckFlag<>'CA'
                                             left join bas_vendor_master c on a.site=c.site and a.vendor_id=c.vendor_id
                                            where a.pkm_status ='NA' and DATEPART(MONTH, a.pak_date) ={0} and DATEPART(YEAR,  a.pak_date) ={1} 
                                            order by a.pak_date
                                            ", iMonth, iYear);
            if (Ds.Tables.Contains("purc_pkm"))
                Ds.Tables.Remove("purc_pkm");
            SearchReportData("purc_pkm", strsql);

            if (Ds.Tables["purc_pkm"].Rows.Count > 0)
            {
                // Create a DataView
                //已挑選purc_pkm
                DataView dv = new DataView(Ds.Tables["purc_pkm"]);
                dv.RowFilter = " CheckFlag is not null";
                if (Ds.Tables.Contains("SelectedPurc_pkm"))
                    Ds.Tables.Remove("SelectedPurc_pkm");
                if (dv.Count > 0)
                    Ds.Tables.Add(dv.ToTable("SelectedPurc_pkm"));

                //未挑選purc_pkm
                DataView dv2 = new DataView(Ds.Tables["purc_pkm"]);
                dv2.RowFilter = " CheckFlag is null and PkdSelect = 'N' ";
                if (Ds.Tables.Contains("PKM"))
                    Ds.Tables.Remove("PKM");
                if (dv2.Count > 0)
                    Ds.Tables.Add(dv2.ToTable("PKM"));

                //已被ACR對應挑選purc_pkm
                DataView dv3 = new DataView(Ds.Tables["purc_pkm"]);
                dv3.RowFilter = " PkdSelect = 'Y'";
                if (Ds.Tables.Contains("purc_pkd_acr"))
                    Ds.Tables.Remove("purc_pkd_acr");
                if (dv3.Count > 0)
                    Ds.Tables.Add(dv3.ToTable("purc_pkd_acr"));
                if (Ds.Tables.Contains("SelectedPurc_pkm"))
                    if (Ds.Tables["SelectedPurc_pkm"].Rows.Count > 0)
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('已有挑選紀錄');</script>");


            }
            else
            {
                if (Ds.Tables.Contains("SelectedPurc_pkm"))
                    Ds.Tables.Remove("SelectedPurc_pkm");
                if (Ds.Tables.Contains("Purc_pkm"))
                    Ds.Tables.Remove("Purc_pkm");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('No Data');</script>");
            }
        }

        private void DBInit()
        {
            if (Ds.Tables.Contains("SelectedPurc_pkm"))
                if (Ds.Tables["SelectedPurc_pkm"].Rows.Count > 0)
                {
                    ShowGV("ConvertGV", true);
                    ConvertGV.DataSource = Ds.Tables["SelectedPurc_pkm"];
                    ConvertGV.DataBind();
                }
                else
                    ShowGV("ConvertGV", false);
            else
                ShowGV("ConvertGV", false);
            if (Ds.Tables.Contains("PKM"))
                if (Ds.Tables["PKM"].Rows.Count > 0)
                {
                    ShowGV("PackageGV", true);
                    PackageGV.DataSource = Ds.Tables["PKM"];
                    PackageGV.DataBind();
                }
                else
                    ShowGV("PackageGV", false);
            else
                ShowGV("PackageGV", false);
        }

        private void ShowGV(string strGV, Boolean bshow)
        {
            switch (strGV)
            {
                case "ConvertGV":
                    DeleteBT.Visible = (bshow) ? true : false;
                    ConvertGV.Visible = (bshow) ? true : false;
                    ConvertLB.Visible = (bshow) ? true : false;
                    break;
                case "PackageGV":
                    PackageGV.Visible = (bshow) ? true : false;
                    PackageLB.Visible = (bshow) ? true : false;
                    break;
                default:
                    break;
            }

        }
        private void SearchReportData(string strType, string strsql)
        {
            //if(Ds.Tables[strType].Rows.Count>0)
            //    Ds.Tables[strType].Clear();
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                conn.Open();
                //Create a SqlConnection to the Northwind database.
                SqlCommand command = new SqlCommand(strsql, conn);
                command.CommandType = CommandType.Text;
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.SelectCommand = command;
                    adapter.Fill(Ds, strType);
                }
                catch (Exception ex)
                {
                    ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
                    Log.ErrorLog(ex, strType + " Search Data", "TAX002.aspx");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('資料搜尋錯誤:\\n" + ex.Message + "\\n請洽MIS Stone');</script>");
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        private Boolean checkData()
        {
            Boolean bCheck = false;
            if (string.IsNullOrEmpty(DateDDL.SelectedItem.Text))
                bCheck = true;
            return bCheck;
        }
        protected void ConvertBT_Click(object sender, EventArgs e)
        {
            //POPPanel_ModalPopupExtender.Show();
            //測試
            if (Ds.Tables.Contains("SelectedAcr"))
            {
                if (Ds.Tables["SelectedAcr"].Rows.Count > 0)
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('已有結轉資料\\n請先刪除再重新節轉');</script>");
            }
            else
            {
                if ( Ds.Tables.Contains("PKM"))
                {
                    //單頭單身要有資料
                    if (Ds.Tables["PKM"].Rows.Count > 0)
                    { 
                        using (SqlConnection conn1 = new SqlConnection(strConnectString))
                        {
                            SqlCommand command1 = conn1.CreateCommand();
                            SqlTransaction transaction1;
                            conn1.Open();
                            transaction1 = conn1.BeginTransaction("createpkd");

                            command1.Connection = conn1;
                            command1.Transaction = transaction1;

                            ReferenceCode.SysLog Log = new ReferenceCode.SysLog();

                            try
                            {



                                foreach (DataRow pkdDT in Ds.Tables["PKM"].Rows)
                                {
                                    string strtimestamp = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                                    #region 表頭
                                    command1.CommandText = @"INSERT INTO [dbo].[purc_pkd_for_acr]
                                                        ([timestamp],[site],[pak_nbr],[pak_seq],[cus_item_no],[rec_nbr]
                                                        ,[rec_seq],[stockroom],[rs_type],[uncount_qty],[coint_qty],[item_no]
                                                        ,[box_no],[box_qty],[tot_net_wt],[tot_gross_wt],[cube_feet],[rec_unit]
                                                        ,[pur_price],[rec_qty],[customs_decleartion_price],[customs_decleartion_amt]
                                                        ,[clear_Customs_price],[currency_id],[combine],[pkd_status],[filter_creator]
                                                        ,[filter_dept],[creator],[create_date],[modifier],[modify_date],[vendor_id])
                                                        select 
                                                        @timestamp,[site],[pak_nbr],[pak_seq],[cus_item_no],[rec_nbr]
                                                        ,[rec_seq],[stockroom],[rs_type],[uncount_qty],[coint_qty]
                                                        ,[item_no],[box_no],[box_qty],[tot_net_wt],[tot_gross_wt]
                                                        ,[cube_feet],[rec_unit],[pur_price],[rec_qty],[customs_decleartion_price]
                                                        ,[customs_decleartion_amt],[clear_Customs_price],[currency_id],[combine]
                                                        ,[pkd_status],[filter_creator],[filter_dept],[creator]
                                                        ,[create_date],[modifier],[modify_date],[vendor_id]
                                                        from [dbo].[purc_pkd]
                                                        where [site]=@site and [pak_nbr]=@pak_nbr
                                                                ";
                                    command1.Parameters.Add("@timestamp", SqlDbType.VarChar).Value = strtimestamp;
                                    command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = pkdDT["site"];
                                    command1.Parameters.Add("@pak_nbr", SqlDbType.NVarChar).Value = pkdDT["pak_nbr"];
                                    #endregion
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();

                                    command1.CommandText = @"INSERT INTO [dbo].[purc_pkd_for_acr]
                                                                ([timestamp],[site],[pak_nbr],[pak_seq],[cus_item_no],[rec_nbr]
                                                                ,[rec_seq],[stockroom],[rs_type],[uncount_qty],[coint_qty],[item_no]
                                                                ,[box_no],[box_qty],[tot_net_wt],[tot_gross_wt],[cube_feet]
                                                                ,[rec_unit],[pur_price],[rec_qty],[customs_decleartion_price]
                                                                ,[customs_decleartion_amt],[clear_Customs_price],[currency_id]
                                                                ,[combine],[pkd_status],[filter_creator],[filter_dept],[creator]
                                                                ,[create_date],[modifier],[modify_date],[vendor_id])
                                                                select
                                                                @timestamp,[site],[pak_nbr],[pak_seq],[cus_item_no],[rec_nbr]
                                                                ,[rec_seq],[stockroom],[rs_type],[uncount_qty],[coint_qty],[item_no]
                                                                ,[box_no],[box_qty],[tot_net_wt],[tot_gross_wt],[cube_feet]
                                                                ,[rec_unit],[pur_price],[rec_qty],[customs_decleartion_price]
                                                                ,[customs_decleartion_amt],[clear_Customs_price],[currency_id]
                                                                ,[combine],[pkd_status],[filter_creator],[filter_dept],[creator]
                                                                ,[create_date],[modifier],[modify_date],[vendor_id]
                                                                from [purc_pkd]
                                                                where [site]=@site and [pak_nbr]=@pak_nbr
                                                                ";
                                    #region 表身


                                    command1.Parameters.Add("@timestamp", SqlDbType.VarChar).Value = strtimestamp;
                                    command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = pkdDT["site"];
                                    command1.Parameters.Add("@pak_nbr", SqlDbType.NVarChar).Value = pkdDT["pak_nbr"];

                                    #endregion
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();

                                }
                                if(1==2)
                                for (int i = 0; i < Ds.Tables["purc_pkd_for_acr"].Rows.Count; i++)
                                {
                                    string strtimestamp = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                                    #region 表頭
                                    command1.CommandText = @"INSERT INTO [dbo].[purc_pkd_for_acr]
                                                                   (
			                                                        [timestamp],[site],[pak_nbr],[pak_seq],[CheckCreateDate],[cus_item_no],[rec_nbr]
			                                                        ,[rec_seq],[stockroom],[rs_type],[uncount_qty],[coint_qty],[item_no],[box_no],[box_qty]
			                                                        ,[tot_net_wt],[tot_gross_wt],[cube_feet],[rec_unit],[pur_price],[rec_qty],[customs_decleartion_price]
			                                                        ,[customs_decleartion_amt],[clear_Customs_price],[currency_id],[combine],[pkd_status],[filter_creator]
			                                                        ,[filter_dept],[creator],[create_date],[modifier],[modify_date],[vendor_id]
			                                                        )
                                                             VALUES
                                                                   (
			                                                        @timestamp,@site,@pak_nbr,@pak_seq,@CheckCreateDate,@cus_item_no,@rec_nbr
			                                                        ,@rec_seq,@stockroom,@rs_type,@uncount_qty,@coint_qty,@item_no,@box_no,@box_qty
			                                                        ,@tot_net_wt,@tot_gross_wt,@cube_feet,@rec_unit,@pur_price,@rec_qty,@customs_decleartion_price
			                                                        ,@customs_decleartion_amt,@clear_Customs_price,@currency_id,@combine,@pkd_status,@filter_creator
			                                                        ,@filter_dept,@creator,@create_date,@modifier,@modify_date,@vendor_id
                                                                    )";



                                    command1.Parameters.Add("@create_timestamp", SqlDbType.VarChar).Value = strtimestamp;
                                    command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["site"];
                                    command1.Parameters.Add("@pak_nbr", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["pak_nbr"];
                                    command1.Parameters.Add("@pak_seq", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["pak_seq"];
                                    command1.Parameters.Add("@CheckCreateDate", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["CheckCreateDate"];
                                    command1.Parameters.Add("@cus_item_no", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["cus_item_no"];
                                    command1.Parameters.Add("@rec_nbr", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["rec_nbr"];
                                    command1.Parameters.Add("@rec_seq", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["rec_seq"];
                                    command1.Parameters.Add("@stockroom", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["stockroom"];
                                    command1.Parameters.Add("@rs_type", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["rs_type"];
                                    command1.Parameters.Add("@uncount_qty", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["uncount_qty"];
                                    command1.Parameters.Add("@coint_qty", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["coint_qty"];
                                    command1.Parameters.Add("@item_no", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["item_no"];
                                    command1.Parameters.Add("@box_no", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["box_no"];
                                    command1.Parameters.Add("@box_qty", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["box_qty"];
                                    command1.Parameters.Add("@tot_net_wt", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["tot_net_wt"];
                                    command1.Parameters.Add("@tot_gross_wt", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["tot_gross_wt"];
                                    command1.Parameters.Add("@cube_feet", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["cube_feet"];
                                    command1.Parameters.Add("@rec_unit", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["rec_unit"];
                                    command1.Parameters.Add("@pur_price", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["pur_price"];
                                    command1.Parameters.Add("@rec_qty", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["rec_qty"];
                                    command1.Parameters.Add("@customs_decleartion_price", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["customs_decleartion_price"];
                                    command1.Parameters.Add("@customs_decleartion_amt", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["customs_decleartion_amt"];
                                    command1.Parameters.Add("@clear_Customs_price", SqlDbType.Int).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["clear_Customs_price"];
                                    command1.Parameters.Add("@currency_id", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["currency_id"];
                                    command1.Parameters.Add("@combine", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["combine"];
                                    command1.Parameters.Add("@pkd_status", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["pkd_status"];
                                    command1.Parameters.Add("@filter_creator", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["filter_creator"];
                                    command1.Parameters.Add("@filter_dept", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["filter_dept"];
                                    command1.Parameters.Add("@creator", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["creator"];
                                    command1.Parameters.Add("@create_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["create_date"];
                                    command1.Parameters.Add("@modifier", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["modifier"];
                                    command1.Parameters.Add("@modify_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["modify_date"];
                                    command1.Parameters.Add("@vendor_id", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkd_for_acr"].Rows[i]["vendor_id"];
                                    #endregion
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();


                                    for (int j = 0; j < Ds.Tables["purc_pkm_for_acr"].Rows.Count; j++)
                                    {
                                        command1.CommandText = @"INSERT INTO [dbo].[purc_pkm_for_acr]
                                                                (
                                                                    [timestamp],[site],[pak_nbr],[pak_date],[sono],[carrier_id]
                                                                    ,[pick_port],[port_of_destination],[owner],[sender],[addressee],[vessel],[voyage],[cabinet_no]
                                                                    ,[cabinet_type],[dta_date],[etd_date],[etc_date],[arrival_date],[pkm_status],[tot_box_qty]
                                                                    ,[tot_net_wt],[tot_gross_wt],[tot_cube_feet],[filter_creator],[filter_dept],[creator],[create_date]
                                                                    ,[modifier],[modify_date],[so_nbr],[decl_no],[bol_no],[ship_cost],[ins_amt],[pur_kind],[vendor_id]
                                                                )
                                                                VALUES
                                                                (
			                                                        @timestamp,@site,@pak_nbr,@pak_date,@sono,@carrier_id
                                                                    ,@pick_port,@port_of_destination,@owner,@sender,@addressee,@vessel,@voyage,@cabinet_no
                                                                    ,@cabinet_type,@dta_date,@etd_date,@etc_date,@arrival_date,@pkm_status,@tot_box_qty
                                                                    ,@tot_net_wt,@tot_gross_wt,@tot_cube_feet,@filter_creator,@filter_dept,@creator,@create_date
                                                                    ,@modifier,@modify_date,@so_nbr,@decl_no,@bol_no,@ship_cost,@ins_amt,@pur_kind,@vendor_id
                                                                )";
                                        #region 表身


                                        command1.Parameters.Add("@create_timestamp", SqlDbType.VarChar).Value = strtimestamp;
                                        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["site"];
                                        command1.Parameters.Add("@pak_nbr", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["pak_nbr"];
                                        command1.Parameters.Add("@pak_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["pak_date"];
                                        command1.Parameters.Add("@sono", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["sono"];
                                        command1.Parameters.Add("@carrier_id", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["carrier_id"];
                                        command1.Parameters.Add("@pick_port", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["pick_port"];
                                        command1.Parameters.Add("@port_of_destination", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["port_of_destination"];
                                        command1.Parameters.Add("@owner", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["owner"];
                                        command1.Parameters.Add("@sender", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["sender"];
                                        command1.Parameters.Add("@addressee", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["addressee"];
                                        command1.Parameters.Add("@vessel", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["vessel"];
                                        command1.Parameters.Add("@voyage", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["voyage"];
                                        command1.Parameters.Add("@cabinet_no", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["cabinet_no"];
                                        command1.Parameters.Add("@cabinet_type", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["cabinet_type"];
                                        command1.Parameters.Add("@dta_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["dta_date"];
                                        command1.Parameters.Add("@etd_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["etd_date"];
                                        command1.Parameters.Add("@etc_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["etc_date"];
                                        command1.Parameters.Add("@arrival_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["arrival_date"];
                                        command1.Parameters.Add("@pkm_status", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["pkm_status"];
                                        command1.Parameters.Add("@tot_box_qty", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["tot_box_qty"];
                                        command1.Parameters.Add("@tot_net_wt", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["tot_net_wt"];
                                        command1.Parameters.Add("@tot_gross_wt", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["tot_gross_wt"];
                                        command1.Parameters.Add("@tot_cube_feet", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["tot_cube_feet"];
                                        command1.Parameters.Add("@filter_creator", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["filter_creator"];
                                        command1.Parameters.Add("@filter_dept", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["filter_dept"];
                                        command1.Parameters.Add("@creator", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["creator"];
                                        command1.Parameters.Add("@create_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["create_date"];
                                        command1.Parameters.Add("@modifier", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["modifier"];
                                        command1.Parameters.Add("@modify_date", SqlDbType.DateTime).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["modify_date"];
                                        command1.Parameters.Add("@so_nbr", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["so_nbr"];
                                        command1.Parameters.Add("@decl_no", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["decl_no"];
                                        command1.Parameters.Add("@bol_no", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["bol_no"];
                                        command1.Parameters.Add("@ship_cost", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["ship_cost"];
                                        command1.Parameters.Add("@ins_amt", SqlDbType.Int).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["ins_amt"];
                                        command1.Parameters.Add("@pur_kind", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["pur_kind"];
                                        command1.Parameters.Add("@vendor_id", SqlDbType.NVarChar).Value = Ds.Tables["purc_pkm_for_acr"].Rows[j]["vendor_id"];
                                        #endregion
                                        command1.ExecuteNonQuery();
                                        command1.Parameters.Clear();
                                    }


                                }
                                transaction1.Commit();
                                DBInit2();//Search Data
                                DBInit();

                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Insert Error", "TAX002.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Insert Error2", "TAX002.aspx");
                                }
                                finally
                                {
                                    transaction1.Rollback();
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
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有結轉資料');</script>");
                }
                    
            }
        }

        protected void ConvertGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConvertGV.PageIndex = e.NewPageIndex;
            DBInit();
        }

        protected void PackageGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PackageGV.PageIndex = e.NewPageIndex;
            DBInit();
        }

        protected void DeleteBT_Click(object sender, EventArgs e)
        {
            if (Ds.Tables["purc_pkd_acr"].Rows.Count>0)
            {
                //已被對應到應付單據
                purc_pkd_acrGV.DataSource = Ds.Tables["purc_pkd_acr"];
                purc_pkd_acrGV.DataBind();
                POPPanel_ModalPopupExtender.Show();
            }
            else
            {
                //未被對應到應付單據
                if (Ds.Tables["SelectedPurc_pkm"].Rows.Count > 0)
                {
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand command1 = conn1.CreateCommand();
                        SqlTransaction transaction1;
                        conn1.Open();
                        transaction1 = conn1.BeginTransaction("createOrder");

                        command1.Connection = conn1;
                        command1.Transaction = transaction1;
                        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();

                        try
                        {
                            string strwhere = "";
                            for (int i = 0; i < Ds.Tables["SelectedPurc_pkm"].Rows.Count; i++)
                            {
                                if (i > 0)
                                    strwhere += " , ";
                                strwhere += " '" + Ds.Tables["SelectedPurc_pkm"].Rows[i]["uid"] + "' ";

                            }
                            command1.CommandText = @"UPDATE [dbo].[purc_pkm_for_acr]
                                                       SET 
                                                          [CheckFlag] = 'CA'
                                                          ,[CheckModifyDate] =getdate()
      
                                                     WHERE uid in (" + strwhere + ") ";

                            command1.ExecuteNonQuery();
                            command1.Parameters.Clear();
                            command1.CommandText = @"UPDATE [dbo].[purc_pkd_for_acr]
                                                       SET 
                                                          [CheckFlag] = 'CA'
                                                          ,[CheckModifyDate] =getdate()
      
                                                     WHERE acr_uid in (" + strwhere + ") ";

                            command1.ExecuteNonQuery();
                            transaction1.Commit();
                            DBInit2();//Search Data
                            DBInit();

                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Delete Error", "TAX001.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Delete Error2", "TAX001.aspx");
                            }
                            finally
                            {
                                transaction1.Rollback();
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
            }
        }
        
    }
}