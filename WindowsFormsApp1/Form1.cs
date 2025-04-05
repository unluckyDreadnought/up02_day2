using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string[][] curTblDesc = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadTablesCombo()
        {
            string[] tblNames = Db.GetTableNames();
            if (tblNames == null) return;
            tables.Items.AddRange(tblNames);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTablesCombo();
            numericUpDown1.Value = Configs.timeout;
        }

        private (string, string) GetCorrectEscapeValue(int columnIndx, string value)
        {
            string description = null;
            string escaped = null;
            string[] fieldInfo = curTblDesc[columnIndx];
            if (fieldInfo[1].Contains("int"))
            {
                // auto_increment
                if (fieldInfo[5] != "")
                {
                    escaped = (value != null && value != "") ? value : "null";
                }
                // default value
                else if (fieldInfo[4] != null)
                {
                    escaped = (value != null && value != "") ? value : fieldInfo[4];
                }
                else
                {
                    if (fieldInfo[2] == "NO") escaped = (value != null && value != "") ? value : null;
                    else escaped = (value != null && value != "") ? value : "null";
                }
            }
            else if (fieldInfo[1].Contains("varchar") || fieldInfo.Contains("text"))
            {
                if (fieldInfo[4] != null)
                {
                    escaped = (value != null && value != "") ? $"'{value}'" : $"'{fieldInfo[4]}'";
                }
                else
                {
                    if (fieldInfo[2] == "NO") escaped = (value != null && value != "") ? $"'{value}'" : null;
                    else escaped = (value != null && value != "") ? value : "null";
                }
            }
            else if (fieldInfo[1].Contains("date"))
            {
                try
                {
                    if (fieldInfo[2] == "NO") escaped = (value != null && value != "") ? $"'{DateTime.Parse(value).ToString("yyyy.MM.dd")}'" : null;
                    else escaped = (value != null && value != "") ? $"'{DateTime.Parse(value).ToString("yyyy.MM.dd")}'" : "null";
                }
                catch (Exception)
                {
                    description = $"Переданное значение не является датой (П: {columnIndx})";
                    return (null, description);
                }
            }
            else if (fieldInfo[1].Contains("double") || fieldInfo[1].Contains("float"))
            {
                if (fieldInfo[2] == "NO") escaped = (value != null && value != "") ? $"{value.Replace(',', '.')}" : null;
                else escaped = (value != null && value != "") ? $"{value.Replace(',', '.')}" : "null";
            }
            else if (fieldInfo[1].Contains("blob"))
            {
                //if (fieldInfo[2] == "NO") escaped = (value != null && value != "") ? $"{value}" : null;
                //else escaped = (value != null && value != "") ? $"{value}" : "null";
                escaped = "null";
            }

            if (escaped == null)
            {
                description = $"Поле не может иметь пустое значение (П: {columnIndx})";
                return (null, description);
            }

            return (escaped, description);
        }

        private void import_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (tables.SelectedIndex == -1) return;
            curTblDesc = Db.GetTableDescription(tables.SelectedItem.ToString());
            ;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV (разделитель - точка с запятой)|*.csv";
            openFile.Multiselect = false;
            openFile.CheckFileExists = true;
            if (openFile.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Файл с импортируемыми данными не выбран или выбран некорректно", "Импортирование данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Encoding.GetEncoding("windows-1251")
            string[] lines = File.ReadAllText(openFile.FileName).Replace("\"", "").Split('\n');
            if (curTblDesc.Length != lines[0].Split(';', ',').Length) 
            { 
                MessageBox.Show($"Количество полей источника данных не совпадает с числом полей таблицы \"{tables.SelectedItem.ToString()}\"", "Импортирование данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rowImportResults.Items.Clear();
            lines = lines.Skip(1).ToArray();
            int total = 0;
            int lineIndx = 0;
            while (lineIndx < lines.Length)
            {
                string[] srcData = lines[lineIndx].Split(';', ',');

                string[] toSave = new string[srcData.Length];
                bool isError = false;
                string escaped = null, errMsg = null;

                int colIndx = 0;
                while (!isError && colIndx < srcData.Length)
                {
                    if (srcData.Length > curTblDesc.Length)
                    {
                        isError = true;
                        errMsg = "Количество полей превышало ожидаемое";
                        break;
                    }
                    (escaped, errMsg) = GetCorrectEscapeValue(colIndx, srcData[colIndx]);
                    isError = errMsg != null;

                    if (isError) break;
                    else toSave[colIndx] = escaped;

                    colIndx++;
                }

                if (!isError)
                {
                    int n = Db.ImportData(tables.SelectedItem.ToString(), toSave);
                    if (n < 0) {
                        string notSuccessed = errMsg != null ? errMsg : "не удалось импротировать данные";
                        rowImportResults.Items.Add($"[С: {lineIndx}] {notSuccessed}");
                    }
                    else
                    {
                        total += n;
                        rowImportResults.Items.Add($"[С: {lineIndx}] импортировано");
                    }
                }
                lineIndx++;
            }

            label1.Text = $"Импортировано {total} записей";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repair_Click(object sender, EventArgs e)
        {
            string res = Db.RepairDb();
            if (res == null) {
                MessageBox.Show("Не удалось подключиться к БД", "Ошибка подкючения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (res.Length == 0)
            {
                MessageBox.Show("Структура БД успешно восстановлена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTablesCombo();
            }
            else
            {
                MessageBox.Show(res, "Ошибка выполнения запроса", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Configs.timeout = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
