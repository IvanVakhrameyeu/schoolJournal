using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
namespace Wpf_журнал_учащихся_школы
{
    class WorkWithWord
    {
        static public void writeClass(DataSet ds, string nameFile)
        {
            Word._Application wordApplication = new Word.Application();
            Word._Document wordDocument = null;
            wordApplication.Visible = true;

            var templatePathObj = Environment.CurrentDirectory + "\\" + nameFile + ".docx";

            try
            {
                wordDocument = wordApplication.Documents.Add(templatePathObj);
            }
            catch
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(false);
                    wordDocument = null;
                }
                wordApplication.Quit();
                wordApplication = null;
                throw;
            }
            wordApplication.Selection.Find.Execute("{Table}");            
            Word.Range wordRange = wordApplication.Selection.Range;

            var wordTable = wordDocument.Tables.Add(wordRange,
                ds.Tables[0].Rows.Count + 1, ds.Tables[0].Columns.Count);
            
            wordTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;

            wordTable.Cell(1, 1).Range.Text = "Класс";
            wordTable.Cell(1, 2).Range.Text = "Ф.И.О";
            wordTable.Cell(1, 3).Range.Text = "Предмет";
            wordTable.Cell(1, 4).Range.Text = "Дата оценки";
            wordTable.Cell(1, 5).Range.Text = "Оценка";
            wordTable.Cell(1, 6).Range.Text = "Пропуск";

            for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (var k = 1; k < ds.Tables[0].Columns.Count+1; k++)
                {
                    if (k == 5)
                    {
                        if ((ds?.Tables[0].Rows[j][k - 1].ToString() ?? "")!="")
                        {
                            wordTable.Cell(j + 2, k).Range.Text = (Convert.ToInt32(ds.Tables[0].Rows[j][k - 1])).ToString();
                        }
                        else
                        {
                            wordTable.Cell(j + 2, k).Range.Text = "";
                        }
                    }
                    else
                    {
                        if (k == 4)
                        {
                            wordTable.Cell(j + 2, k).Range.Text = Convert.ToDateTime(ds.Tables[0].Rows[j][k - 1]).ToString("d");
                        }
                        else
                        {
                            wordTable.Cell(j + 2, k).Range.Text = ds.Tables[0].Rows[j][k - 1].ToString();
                        }
                    }
                }
            }
        }

    }
}
