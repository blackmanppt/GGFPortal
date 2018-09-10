using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GGFPortal.ReferenceCode
{
    public class ExcelColumn
    {
    }
    public class Column1
    {

        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public string VNName { get; set; }

        public int ColumnType { get; set; }
        public string ChineseName { get; set; }

        public List<Column1> VNExcel;
        public List<Column1> VNExcel2;

        public int IntAdd(ref int x)
        {
            return x++;
        }

        public DataTable ExcelTable;
        public void VNDT( string Team=null)
        {
            ExcelTable = new DataTable();
            ExcelTable.Columns.Add("SheetName");
            ExcelTable.Columns.Add("Date");
            ExcelTable.Columns.Add("Dept");
            ExcelTable.Columns.Add("Customer");
            ExcelTable.Columns.Add("StyleNo");
            ExcelTable.Columns.Add("OrderQty");
            ExcelTable.Columns.Add("TeamProductivity");
            ExcelTable.Columns.Add("OrderShipDate");
            ExcelTable.Columns.Add("OnlineDate");
            ExcelTable.Columns.Add("StandardProductivity");
            ExcelTable.Columns.Add("Person");
            ExcelTable.Columns.Add("Time");
            ExcelTable.Columns.Add("TotalTime");
            ExcelTable.Columns.Add("Percent");
            ExcelTable.Columns.Add("GoalProductivity");
            ExcelTable.Columns.Add("DayProductivity");
            ExcelTable.Columns.Add("PreProductivity");
            ExcelTable.Columns.Add("TotalProductivity");
            ExcelTable.Columns.Add("Difference");
            ExcelTable.Columns.Add("Efficiency");
            ExcelTable.Columns.Add("TotalEfficiency");
            ExcelTable.Columns.Add("ReturnPercent");
            ExcelTable.Columns.Add("Rmark1");
            ExcelTable.Columns.Add("Rmark2");
            ExcelTable.Columns.Add("DayCost1");
            ExcelTable.Columns.Add("DayCost2");
            ExcelTable.Columns.Add("DayCost3");
            ExcelTable.Columns.Add("DayCost4");
            ExcelTable.Columns.Add("DayCost5");
            ExcelTable.Columns.Add("DayCost6");
            ExcelTable.Columns.Add("DayCost7");
            if (!string.IsNullOrEmpty(Team))
            {
                ExcelTable.Columns.Add("QCQty");
                ExcelTable.Columns.Add("ErrorQty");
                //ExcelTable.Columns.Add("ErrorUnreturnQty");
                ExcelTable.Columns.Add("OnlineDay");
                ExcelTable.Columns.Add("ErrorRate");
            }
            
        }
        public void VNPackage()
        {
            // Type 1：int , Type 2：String , Type 3：日期 , Type 4：float, Type 6：不需要資料 String, Type 7：不需要資料 int , Type 8：float 不需要資料, Type 9:
            int x = 1;
            VNExcel = new List<Column1>();
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "SheetName", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Date", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Dept", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Customer", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StyleNo", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderQty", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TeamProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderShipDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StandardProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Person", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Time", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalTime", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Percent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "GoalProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "PreProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Difference", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Efficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalEfficiency", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ReturnPercent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark1", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark2", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost1", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost2", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost3", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost4", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost5", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost6", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost7", ColumnType = 8 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorUnreturnQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
        }
        public void VNCut()
        {
            // Type 1：int , Type 2：String , Type 3：日期 , Type 4：float, Type 6：不需要資料 String, Type 7：不需要資料 int , Type 8：float 不需要資料, Type 9:
            int x = 1;
            VNExcel = new List<Column1>();
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "SheetName", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Date", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Dept", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Customer", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StyleNo", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderQty", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TeamProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderShipDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StandardProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Person", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Time", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalTime", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Percent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "GoalProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "PreProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Difference", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Efficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalEfficiency", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ReturnPercent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark1", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark2", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost1", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost2", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost3", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost4", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost5", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost6", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost7", ColumnType = 8 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorUnreturnQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
        }
        public void VNIron()
        {
            //整燙
            // Type 1：int , Type 2：String , Type 3：日期 , Type 4：float, Type 6：不需要資料 String, Type 7：不需要資料 int , Type 8：float 不需要資料, Type 9:
            int x = 1;
            VNExcel = new List<Column1>();
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "SheetName", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Date", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Dept", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Customer", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StyleNo", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderQty", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TeamProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderShipDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StandardProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Person", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Time", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalTime", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Percent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "GoalProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "PreProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Difference", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Efficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalEfficiency", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ReturnPercent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark1", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark2", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost1", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost2", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost3", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost4", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost5", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost6", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost7", ColumnType = 8 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorUnreturnQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
        }
        public void VNQC()
        {
            //QC
            // Type 1：int , Type 2：String , Type 3：日期 , Type 4：float, Type 6：不需要資料 String, Type 7：不需要資料 int , Type 8：float 不需要資料, Type 9:
            int x = 1;
            VNExcel = new List<Column1>();
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "SheetName", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Date", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Dept", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Customer", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StyleNo", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderQty", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TeamProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderShipDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StandardProductivity", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Person", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Time", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalTime", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Percent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "GoalProductivity", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "PreProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Difference", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Efficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalEfficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ReturnPercent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark1", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark2", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost1", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost2", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost3", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost4", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost5", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost6", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost7", ColumnType = 8 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorUnreturnQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
        }
        public void VNStitch()
        {
            int x = 1;
            VNExcel = new List<Column1>();
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "SheetName", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Date", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Dept", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Customer", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StyleNo", ColumnType = 2 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderQty", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TeamProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OrderShipDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDate", ColumnType = 3 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "StandardProductivity", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Person", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Time", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalTime", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Percent", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "GoalProductivity", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayProductivity", ColumnType = 1 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "PreProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalProductivity", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Difference", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Efficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "TotalEfficiency", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ReturnPercent", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark1", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "Rmark2", ColumnType = 6 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost1", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost2", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost3", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost4", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost5", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost6", ColumnType = 8 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "DayCost7", ColumnType = 4 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            //VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorUnreturnQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorRate", ColumnType = 8 });
        }
        public void VNStitchmain()
        {
            VNStitch();
            VNDT("Stitch");
            VNChinese("Stitch");
            VNNameHead("Stitch");
        }
        public void VNPackagemain()
        {
            VNPackage();
            VNDT();
            VNChinese();
            VNNameHead();
        }
        public void VNCutmain()
        {
            VNCut();
            VNDT();
            VNChinese();
            VNNameHead();
        }
        public void VNIronmain()
        {
            VNIron();
            VNDT();
            VNChinese();
            VNNameHead();
        }
        public void VNQCmain()
        {
            VNQC();
            VNDT();
            VNChinese();
            VNNameHead();
        }
        public void VNChinese(string Team = null)
        {
            int x = 0;
            VNExcel[IntAdd(ref x)].ChineseName = "SheetName";
            VNExcel[IntAdd(ref x)].ChineseName = "Date";
            VNExcel[IntAdd(ref x)].ChineseName = "部門";
            VNExcel[IntAdd(ref x)].ChineseName = "客戶";
            VNExcel[IntAdd(ref x)].ChineseName = "款號";
            VNExcel[IntAdd(ref x)].ChineseName = "訂單量";
            VNExcel[IntAdd(ref x)].ChineseName = "組生產量";
            VNExcel[IntAdd(ref x)].ChineseName = "訂單交期";
            VNExcel[IntAdd(ref x)].ChineseName = "上線日期";
            VNExcel[IntAdd(ref x)].ChineseName = "標準產量";
            VNExcel[IntAdd(ref x)].ChineseName = "實際工作人數";
            VNExcel[IntAdd(ref x)].ChineseName = "工時";
            VNExcel[IntAdd(ref x)].ChineseName = "總時數";
            VNExcel[IntAdd(ref x)].ChineseName = "百分比";
            VNExcel[IntAdd(ref x)].ChineseName = "今日目標產量";
            VNExcel[IntAdd(ref x)].ChineseName = "今日產量";
            VNExcel[IntAdd(ref x)].ChineseName = "前天累積產量";
            VNExcel[IntAdd(ref x)].ChineseName = "累積產量";
            VNExcel[IntAdd(ref x)].ChineseName = "差異量";
            VNExcel[IntAdd(ref x)].ChineseName = "組各別效率";
            VNExcel[IntAdd(ref x)].ChineseName = "組效率";
            VNExcel[IntAdd(ref x)].ChineseName = "返修率";
            VNExcel[IntAdd(ref x)].ChineseName = "責任歸屬及上線天數";
            VNExcel[IntAdd(ref x)].ChineseName = "顏色";
            VNExcel[IntAdd(ref x)].ChineseName = "今日各組成本";
            VNExcel[IntAdd(ref x)].ChineseName = "今日生產成本";
            VNExcel[IntAdd(ref x)].ChineseName = "工繳收入";
            VNExcel[IntAdd(ref x)].ChineseName = "今日工繳收入";
            VNExcel[IntAdd(ref x)].ChineseName = "今日生產損益";
            VNExcel[IntAdd(ref x)].ChineseName = "CM損益";
            VNExcel[IntAdd(ref x)].ChineseName = "累積損益";
            if (!string.IsNullOrEmpty(Team))
            { 
                VNExcel[IntAdd(ref x)].ChineseName = "QC檢驗數量";
                VNExcel[IntAdd(ref x)].ChineseName = "瑕疵數可返修";
                //VNExcel[IntAdd(ref x)].ChineseName = "瑕疵數不可返修";
                VNExcel[IntAdd(ref x)].ChineseName = "上線天數";
                VNExcel[IntAdd(ref x)].ChineseName = "新舊瑕疵率判定";
            }
        }
        public void VNNameHead(string Team = null)
        {
            int x = 0;
            VNExcel[IntAdd(ref x)].VNName = "SheetName";
            VNExcel[IntAdd(ref x)].VNName = "Date";
            VNExcel[IntAdd(ref x)].VNName = "部門 Bộ Phận";
            VNExcel[IntAdd(ref x)].VNName = "客户 Khách Hàng";
            VNExcel[IntAdd(ref x)].VNName = "款號 Mã Hàng";
            VNExcel[IntAdd(ref x)].VNName = "訂單數量 SL đơn hàng";
            VNExcel[IntAdd(ref x)].VNName = "组生产量 sản lượng tổ";
            VNExcel[IntAdd(ref x)].VNName = "訂單交期 Ngày giao hàng";
            VNExcel[IntAdd(ref x)].VNName = "上線日期 Ngày lên chuyền";
            VNExcel[IntAdd(ref x)].VNName = "1/人8H標準產量 M.tiêu 1ng/8H";
            VNExcel[IntAdd(ref x)].VNName = "實際工作人數 Số cn  làm";
            VNExcel[IntAdd(ref x)].VNName = "工時 Thời gian làm việc";
            VNExcel[IntAdd(ref x)].VNName = "總工時 tổng thời gian làm việc của cả tổ";
            VNExcel[IntAdd(ref x)].VNName = "百分比 phần trăm";
            VNExcel[IntAdd(ref x)].VNName = "今日目標產量 SL Mụ tiêu ngày";
            VNExcel[IntAdd(ref x)].VNName = "今日產量 Sản Lượng Ngày";
            VNExcel[IntAdd(ref x)].VNName = "前天累積產量 Tích luỹ trước 1 ngày";
            VNExcel[IntAdd(ref x)].VNName = "累積產量 Sản lượng tích luỹ";
            VNExcel[IntAdd(ref x)].VNName = "差異量 Sản lượng  tích luỹ";
            VNExcel[IntAdd(ref x)].VNName = "組各別效率 hiệu quả của 1 mã hàng trong tổ";
            VNExcel[IntAdd(ref x)].VNName = "組效率 Tỉ Lệ Hiệu Suất %";
            VNExcel[IntAdd(ref x)].VNName = "返修率 Tỉ lệ hàng sửa";
            VNExcel[IntAdd(ref x)].VNName = "责任归属及上线天数 (文字備註)";
            VNExcel[IntAdd(ref x)].VNName = "顏色";
            VNExcel[IntAdd(ref x)].VNName = "今日各組成本 giá thành các tổ";
            VNExcel[IntAdd(ref x)].VNName = "今日生產成本/DZ giá thành SP/DZ";
            VNExcel[IntAdd(ref x)].VNName = "工繳收入/DZ Đơn giá bán/DZ";
            VNExcel[IntAdd(ref x)].VNName = "今日工繳收入 /DZ Doanh thu";
            VNExcel[IntAdd(ref x)].VNName = "今日生產損益 USD USD Lãi,lỗ";
            VNExcel[IntAdd(ref x)].VNName = "(CM-COST)/CM 損 益 % lãi lỗ";
            VNExcel[IntAdd(ref x)].VNName = "累積損益";
            if (!string.IsNullOrEmpty(Team))
            {
                VNExcel[IntAdd(ref x)].VNName = "QC檢驗數量 Tổng hàng kiểm";
                VNExcel[IntAdd(ref x)].VNName = "瑕疵數可返修hàng lỗi có thể sửa được";
                //VNExcel[IntAdd(ref x)].VNName = "瑕疵數不可返修hàng lỗi không thể sửa được";
                VNExcel[IntAdd(ref x)].VNName = "上線天數 Số ngày lên ";
                VNExcel[IntAdd(ref x)].VNName = "新舊瑕疵率判定";
            }
        }

    }
    public class AMZForcast
    {
        //public int ColumnID { get; set; }
        //public string ColumnName { get; set; }
        //public string VNName { get; set; }
        //public int ColumnType { get; set; }
        //public string ChineseName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string 款號 { get; set; }
        public int 訂單單位 { get; set; }
        public int 可用庫存 { get; set; }
        //public int Week1 { get; set; }

        public DataTable ForcastDataTable { get; set; }
        public void ForcastDT()
        {
            ForcastDataTable = new DataTable();
            ForcastDataTable.Columns.Add("尺寸");
            ForcastDataTable.Columns.Add("顏色");
            ForcastDataTable.Columns.Add("款號");
            ForcastDataTable.Columns.Add("訂單單位");
            ForcastDataTable.Columns.Add("可用庫存");
            ForcastDataTable.Columns.Add("Week1");
            ForcastDataTable.Columns.Add("Week2");
            ForcastDataTable.Columns.Add("Week3");
            ForcastDataTable.Columns.Add("Week4");
            ForcastDataTable.Columns.Add("Week5");
            ForcastDataTable.Columns.Add("Week6");
            ForcastDataTable.Columns.Add("Week7");
            ForcastDataTable.Columns.Add("Week8");
            ForcastDataTable.Columns.Add("Week9");
            ForcastDataTable.Columns.Add("Week10");
            ForcastDataTable.Columns.Add("Week11");
            ForcastDataTable.Columns.Add("Week12");
            ForcastDataTable.Columns.Add("Week13");
            ForcastDataTable.Columns.Add("Week14");
            ForcastDataTable.Columns.Add("Week15");
            ForcastDataTable.Columns.Add("Week16");
            ForcastDataTable.Columns.Add("Week17");
            ForcastDataTable.Columns.Add("Week18");
            ForcastDataTable.Columns.Add("Week19");
            ForcastDataTable.Columns.Add("Week20");
            ForcastDataTable.Columns.Add("Week21");
            ForcastDataTable.Columns.Add("Week22");
            ForcastDataTable.Columns.Add("Week23");
            ForcastDataTable.Columns.Add("Week24");
            ForcastDataTable.Columns.Add("Week25");
            ForcastDataTable.Columns.Add("Week26");
        }

    }


}