using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace cloudy
{
    class SelectData
    {
        Microsoft.Office.Interop.Word.Application wordApp;
        Microsoft.Office.Interop.Word.Document wordDoc;

        string filePath;

        public void WriteData(List<Weather> selectXY, List<Weather> rainData)
        {
            try
            {
                filePath = Environment.CurrentDirectory.ToString();
                wordApp = new Microsoft.Office.Interop.Word.Application();

                wordDoc = wordApp.Documents.Add(filePath + "\\Шаблон_Пошуку.dotx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + char.ConvertFromUtf32(13) +
                    "Помістіть файл Шаблон_Пошуку.dotx" + char.ConvertFromUtf32(13) +
                    "у каталог із ехе-файлом програми і повторіть збереження", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                ReplaceText(MainWindow.selectedCity, "[X]");
                ReplaceText(Convert.ToString(AverageTemp(selectXY)), "[T]");
                ReplaceText(MainWindow.selectedMonth, "[Y]");
                ReplaceText(Convert.ToString(AveragePres(selectXY)), "[P]");

                ReplaceText(rainData);

                wordDoc.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + char.ConvertFromUtf32(13) +
                    "Помилка збереження відібраних даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReplaceText(string textToReplace, string replacedText)
        {
            Object missing = Type.Missing;
            Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
            Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            Microsoft.Office.Interop.Word.Range content;
            content = wordDoc.Range(wordDoc.Content.Start, wordDoc.Content.End);

            Microsoft.Office.Interop.Word.Find find = wordApp.Selection.Find;

            find.Text = replacedText;
            find.Replacement.Text = textToReplace;

            find.Execute(
                FindText: Type.Missing,
                MatchCase: false,
                MatchWholeWord: false,
                MatchWildcards: false,
                MatchAllWordForms: false,
                Forward: true,
                Wrap: wrap,
                Format: false,
                ReplaceWith: missing,
                Replace: replace
             );

        }

        private void ReplaceText(List<Weather> rainData)
        {
            if (rainData == null)
            {
                return;
            }
            for (int i = 0; i < rainData.Count; i++)
            {
                wordDoc.Tables[2].Rows.Add();
                wordDoc.Tables[2].Cell(2 + i, 1).Range.Text = Convert.ToString(i + 1);
                wordDoc.Tables[2].Cell(2 + i, 2).Range.Text = Convert.ToString(rainData[i].day) + " " + rainData[i].month;
            }

            wordDoc.Tables[1].Cell(1, 2).Range.Text = Convert.ToString(rainData.Count);
        }

        private double AverageTemp(List<Weather> weathers)
        {
            if(weathers == null)
            {
                return 0;
            }
            double result = 0;
            for(int i = 0; i < weathers.Count;i++)
            {
                result += weathers[i].temperature;
            }
            return result / weathers.Count;
        }

        private double AveragePres(List<Weather> weathers)
        {
            if (weathers == null)
            {
                return 0;
            }
            double result = 0;
            for (int i = 0; i < weathers.Count; i++)
            {
                result += weathers[i].pressure;
            }
            return result / weathers.Count;
        }

        ~SelectData()
        {
            try
            {
                if (wordDoc != null)
                {
                    wordDoc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges);
                }
                if (wordApp != null)
                {
                    wordApp.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
