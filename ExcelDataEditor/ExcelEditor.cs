using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelDataEditor
{
    internal class ExcelEditor
    {
        public static void Createfile(string name, string path)
        {
            if (name.Length <= 0) name = DateTime.Now.ToString();
            if (path == "") path = "C:\\Users\\SW2137\\Desktop";
            string filename = path + "\\" + name + ".xlsx";
            try
            {
                application = new Application(); 
                application.Visible = false;
                workbook = application.Workbooks.Add(); 

                workbook.SaveAs(filename);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                workbook.Close();
                application.Quit(); // 작업 종료
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application); // Close(), Quit()으로 종료되지 않은 프로세스까지 종료
            }
        }
        public static void Editfile(string path)
        {
            string filename = path;
            try
            {
                application = new Application();
                application.Visible = false;
                workbook = application.Workbooks.Open(path);
                worksheet = (Worksheet)workbook.Worksheets.Item[1];

                Range r1 = worksheet.Cells[10, 1];
                r1.Value = DateTime.Now.ToString();

                workbook.SaveAs(filename);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                workbook.Close();
                application.Quit(); // 작업 종료
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application); // Close(), Quit()으로 종료되지 않은 프로세스까지 종료
            }
        }
        protected static Workbook workbook;
        protected static Worksheet worksheet;
        protected static Application application;
    }
}
