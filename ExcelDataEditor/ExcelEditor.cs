﻿using System;
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
        public static void CreateFile(string name, string path)
        {
            if (name.Length <= 0) name = DateTime.Now.ToString();
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
                throw ex;
            }
            finally
            {
                workbook.Close();
                application.Quit(); // 작업 종료
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application); // Close(), Quit()으로 종료되지 않은 프로세스까지 종료
            }
        }
        public static void EditAreaFile(string path)
        {
            try
            {
                application = new Application();
                application.Visible = false;
                workbook = application.Workbooks.Open(path);
                worksheet = (Worksheet)workbook.Worksheets.Item[1];

                Range r1 = worksheet.Cells[10, 1];
                r1.Value = DateTime.Now.ToString();
                Range r2 = worksheet.Range["A11", "F15"];
                worksheet.Range["A12", "F16"].Value = r2.Value; // 복사 붙여넣기
                worksheet.Range["A11", "F11"].Clear(); // 더 좋은 옮기기 방법이 없을까?

                workbook.Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                workbook.Close();
                application.Quit(); // 작업 종료
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application); // Close(), Quit()으로 종료되지 않은 프로세스까지 종료
            }
        }

        public static string MoveAreaFile(string path)
        {
            string word = "A11";
            int num1 = word[0];
            int num2 = word[1] + word[2];
            string result = num1.ToString() + num2.ToString();
            return result;

        }

        protected static Workbook workbook;
        protected static Worksheet worksheet;
        protected static Application application;
    }
}
