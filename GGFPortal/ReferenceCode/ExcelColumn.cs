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

        public int ColumnType { get; set; }
        public string ChineseName { get; set; }

        public List<Column1> VNExcel;
        public List<Column1> VNExcel2;

        public int IntAdd(ref int x)
        {
            return x++;
        }

        public DataTable ExcelTable;
        public void VNDT()
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
            ExcelTable.Columns.Add("QCQty");
            ExcelTable.Columns.Add("ErrorQty");
            ExcelTable.Columns.Add("OnlineDay");
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
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
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
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
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
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
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
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "QCQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "ErrorQty", ColumnType = 7 });
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
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
            VNExcel.Add(new Column1() { ColumnID = IntAdd(ref x), ColumnName = "OnlineDay", ColumnType = 7 });
        }
        public void VNStitchmain()
        {
            VNStitch();
            VNDT();
            VNChinese();
        }
        public void VNPackagemain()
        {
            VNPackage();
            VNDT();
            VNChinese();
        }
        public void VNCutmain()
        {
            VNCut();
            VNDT();
            VNChinese();
        }
        public void VNIronmain()
        {
            VNIron();
            VNDT();
            VNChinese();
        }
        public void VNQCmain()
        {
            VNQC();
            VNDT();
            VNChinese();
        }
        public void VNChinese()
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
            VNExcel[IntAdd(ref x)].ChineseName = "QC檢驗數量";
            VNExcel[IntAdd(ref x)].ChineseName = "瑕疵數";
            VNExcel[IntAdd(ref x)].ChineseName = "上線天數";

        }
    }
    

}