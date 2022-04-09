using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFDR
{
    public partial class OfdrForm : Form
    {
        public OfdrForm()
        {
            InitializeComponent();
        }

        private void BtnSelectOF(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            pathBoxOF.Text = openFileDialog.FileName;
            openFileDialog.FileName = null;
        }

        private void BtnSelectAF(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            pathBoxAF.Text = openFileDialog.FileName;
            openFileDialog.FileName = null;
        }

        private void BtnWork(object sender, EventArgs e)
        {
            if (pathBoxOF.Text.Length != 0 && pathBoxAF.Text.Length != 0)
            {
                richTextBoxPreview.Text = null;
                string[] ofAf = new string[2];
                ReadFile(ref pathBoxOF, ref ofAf[0]);
                ReadFile(ref pathBoxAF, ref ofAf[1]);
                Work(ref ofAf);
            }
            else
            {
                MessageBox.Show("You haven't select file paths properly!", "Lack Of Paths", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadFile(ref TextBox pathBox, ref string elem)
        {
            using (FileStream fs = new FileStream(pathBox.Text, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    elem = sr.ReadToEnd();
                }
            }
            elem = elem.Trim();
        }

        private void Work(ref string[] ofAf)
        {
            try
            {
                string[] linesOf = ofAf[0].Split(Environment.NewLine);
                string[] linesAf = ofAf[1].Split(Environment.NewLine);

                for (int index = 0; index < linesOf.Length; index++)
                {
                    linesOf[index] = linesOf[index].Insert(16, ",");
                    linesOf[index] = linesOf[index].Insert(32, ",");
                    linesOf[index] = linesOf[index].Insert(45, ",");
                    linesOf[index] = linesOf[index].Insert(47, ",");
                }

                for (int index = 0; index < linesAf.Length; index++)
                {
                    linesAf[index] = linesAf[index].Insert(1, ",");
                }

                for (int index0 = 0; index0 < linesOf.Length; index0++)
                {
                    string editedOf = "";

                    for (int index1 = 0; index1 < linesOf[index0].Length; index1++)
                    {
                        if (linesOf[index0][index1] != ' ' || index1 > 47)
                        {
                            editedOf += linesOf[index0][index1];
                        }
                    }

                    linesOf[index0] = editedOf;
                }

                for (int index0 = 0; index0 < linesAf.Length; index0++)
                {
                    string editedAf = "";

                    for (int index1 = 0; index1 < linesAf[index0].Length; index1++)
                    {
                        if (linesAf[index0][index1] != ' ')
                        {
                            editedAf += linesAf[index0][index1];
                        }
                    }

                    linesAf[index0] = editedAf;
                }

                using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ofdrScores.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (uint index0 = 0; index0 < linesOf.Length; index0++)
                        {
                            string[] ElemsOf = linesOf[index0].Split(',');

                            for (uint index1 = 0; index1 < linesAf.Length; index1++)
                            {
                                string[] ElemsAf = linesAf[index1].Split(',');

                                if (ElemsAf[0] == ElemsOf[3])
                                {
                                    uint trueCount = 0;
                                    uint falseCount = 0;
                                    uint emptyCount = 0;

                                    for (int index2 = 0; index2 < ElemsAf[1].Length; index2++)
                                    {
                                        if (ElemsAf[1][index2] == '*')
                                        {
                                            trueCount++;
                                        }
                                        else if (ElemsOf[4][index2] == ElemsAf[1][index2])
                                        {
                                            trueCount++;
                                        }
                                        else if (ElemsOf[4][index2] == ' ')
                                        {
                                            emptyCount++;
                                        }
                                        else
                                        {
                                            falseCount++;
                                        }
                                    }
                                    uint score = (uint)(trueCount * (100 / ElemsAf[1].Length));
                                    sw.WriteLine($"{ElemsOf[2]},{ElemsOf[0]},{ElemsOf[1]},{trueCount},{falseCount},{emptyCount},{score}");
                                    richTextBoxPreview.Text += $"{ElemsOf[2]},{ElemsOf[0]},{ElemsOf[1]},{trueCount},{falseCount},{emptyCount},{score}\r";
                                }
                            }
                        }
                        MessageBox.Show("The file has been saved at desktop as \"ofdrScores.txt\".", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Improper files have been selected!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
