using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace Compressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = listBox1.Items.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            richTextBox1.Clear();
            richTextBox1.Focus();
            var stopwatch = new Stopwatch();


            if (listBox1.Items.Count > 0)
            {
                for (int NumberOfListBox = 0; NumberOfListBox < listBox1.Items.Count; NumberOfListBox++)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    Process p = new Process();
                    Process p2 = new Process();
                    p.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
                    p2.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
                    string FilePath = "";
                    int length = int.Parse(textBox1.Text);
                    int width = int.Parse(textBox2.Text);
                    string bitarte = textBox3.Text;
                    int fps = int.Parse(textBox4.Text);
                    string OutputFile = textBox5.Text;

                    FilePath = listBox1.Items[NumberOfListBox].ToString();
                    string ParentFolder = Directory.GetParent(FilePath).FullName;
                    string addressfiles = Path.Combine(ParentFolder, Path.GetFileName(FilePath));
                    string filename = Path.GetFileName(addressfiles);
                    string filenamewithoutextension = Path.GetFileNameWithoutExtension(addressfiles);
                    string extentionfile = Path.GetExtension(addressfiles);
                    string addressfileswithoutextension = Path.Combine(ParentFolder + "\\" + filenamewithoutextension);

                    string pathnew = Path.Combine(ParentFolder + "\\New Converted File\\");
                    System.IO.Directory.CreateDirectory(pathnew);


                    if (checkBox20.Checked)
                        p.StartInfo.Arguments = ("/C ffmpeg -i " + "\"" + addressfiles + "\"");
                    else
                        p.StartInfo.Arguments = ("/C ffmpeg-bar -i " + "\"" + addressfiles + "\"");

                    if (checkBox4.Checked && checkBox8.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v libx264 -map_metadata 0 ");
                    }
                    if (checkBox4.Checked && checkBox9.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v libx265 -map_metadata 0 ");
                    }
                    if (checkBox4.Checked && checkBox10.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v libvpx-vp9 -map_metadata 0 ");
                    }

                    if (checkBox2.Checked && checkBox8.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v h264_nvenc -map_metadata 0 ");
                    }
                    //if (checkBox2.Checked && checkBox9.Checked)
                    //{
                    //    p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v hevc_nvenc -map_metadata 0 ");
                    //}
                    if (checkBox2.Checked && checkBox9.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v hevc_nvenc -map_metadata 0 ");
                    }
                    if (checkBox2.Checked && checkBox10.Checked)
                    {
                        MessageBox.Show("Is not avilabel");
                        return;
                    }

                    if (checkBox11.Checked && checkBox8.Checked)
                    {
                        p.StartInfo.Arguments = ("/C ffmpeg -hwaccel cuda -hwaccel_output_format cuda -i " + "\"" + addressfiles + "\"" + " -c:v h264_nvenc -map_metadata 0 ");
                    }
                    if (checkBox11.Checked && checkBox9.Checked)
                    {
                        p.StartInfo.Arguments = ("/C ffmpeg -hwaccel cuda -hwaccel_output_format cuda -i " + "\"" + addressfiles + "\"" + " -c:v hevc_nvenc -map_metadata 0 ");
                    }
                    if (checkBox11.Checked && checkBox10.Checked)
                    {
                        MessageBox.Show("Is not avilabel");
                        return;
                    }

                    if (checkBox6.Checked && checkBox8.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v h264_amf -map_metadata 0 ");
                    }
                    if (checkBox6.Checked && checkBox9.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -c:v hevc_amf -map_metadata 0 ");
                    }
                    if (checkBox6.Checked && checkBox10.Checked)
                    {
                        MessageBox.Show("Is not avilabel");
                        return;
                    }

                    if (checkBox13.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + (" -r " + fps + " ");
                    }
                    if (checkBox14.Checked)
                    {
                        if (checkBox5.Checked)
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf scale=" + "\"" + length + ":" + width + ",transpose = 1" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                        else
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf " + "\"" + "transpose = 1" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                    }
                    if (checkBox15.Checked)
                    {
                        if (checkBox5.Checked)
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf scale=" + "\"" + length + ":" + width + ",transpose = 2" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                        else
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf " + "\"" + "transpose = 2" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                    }
                    if (checkBox16.Checked)
                    {
                        if (checkBox5.Checked)
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf scale=" + "\"" + length + ":" + width + ",transpose = 2,transpose = 2" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                        else
                        {
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf " + "\"" + "transpose = 2,transpose = 2" + "\" ");
                            if (checkBox13.Checked)
                            {
                                p.StartInfo.Arguments = p.StartInfo.Arguments + ("-r " + fps + " ");
                            }
                        }
                    }
                    if (checkBox5.Checked)
                    {
                        if (checkBox16.Checked == false && checkBox15.Checked == false && checkBox14.Checked == false)
                            p.StartInfo.Arguments = p.StartInfo.Arguments + ("-vf scale=" + "\"" + length + ":" + width + "\" ");
                    }
                    if (checkBox31.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + ("-preset " + comboBox1.SelectedItem.ToString() + " -crf " + textBox12.Text.ToString() + " ");
                    }

                    if (checkBox19.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + ("-filter:v " + "\"" + "setpts =" + 1 / double.Parse(textBox6.Text) + "*PTS" + "\" -an ");
                    }


                    if (checkBox7.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + ("-b:v " + bitarte + " ");
                    }
                    if (checkBox12.Checked)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + ("-an ");
                    }
                    if (checkBox17.Checked)
                    {
                        //p.StartInfo.Arguments = p.StartInfo.Arguments + (" -vf -r "+fps+ " " + "\"" + pathnew + "\\" + OutputFile + "\"");
                        p.StartInfo.Arguments = ("/C ffmpeg -i " + "\"" + addressfiles + "\"" + " -vf fps=" + fps + " " + "\"" + pathnew + OutputFile + "\"");
                        //p.StartInfo.Arguments = ($@"/C ffmpeg -i """+addressfiles +$@""" -vf fps=" + fps + " " + "\"" + pathnew + OutputFile+ "\"");
                    }
                    if (checkBox18.Checked)
                    {
                        p.StartInfo.Arguments = ("/C ffmpeg -r " + fps + " -i " + "\"" + ParentFolder + "\\" + OutputFile + "\"" + " -c:v libx264 -vf " + "\"format=yuv420p" + "\" " + "\"" + addressfileswithoutextension + ".mp4" + "\"");
                    }

                    if (checkBox25.Checked)
                    {
                        p.StartInfo.Arguments = ("/C ffmpeg -i " + "\"" + addressfiles + "\"" + " -ss " + textBox9.Text + " -to " + textBox11.Text + " -c:v copy ");
                    }

                    string NewFileName = Path.Combine(pathnew + filenamewithoutextension + ".mp4");

                    if (checkBox17.Checked == false && checkBox18.Checked == false)
                    {
                        p.StartInfo.Arguments = p.StartInfo.Arguments + ("\"" + NewFileName);
                    }
                    string extImage = extentionfile;
                    if (checkBox21.Checked)
                    {

                        if (checkBox22.Checked)
                        {
                            extImage = ".JPG";
                        }
                        NewFileName = Path.Combine(pathnew + filenamewithoutextension + extImage);
                        if (checkBox23.Checked == false)
                        {
                            if (checkBox35.Checked == false)
                                p.StartInfo.Arguments = ("/C ffmpeg -hide_banner -i " + "\"" + addressfiles + "\"" + " \"" + Path.Combine(pathnew + filenamewithoutextension + extImage));
                            else
                                p.StartInfo.Arguments = ("/C ffmpeg -hide_banner -i " + "\"" + addressfiles + "\"" + " -qscale:v 1 " + " \"" + Path.Combine(pathnew + filenamewithoutextension + extImage));
                        }
                        else
                        {
                            if (checkBox35.Checked == false)
                                p.StartInfo.Arguments = ("/C ffmpeg -hide_banner -i " + "\"" + addressfiles + "\"" + " -vf scale=" + "\"" + textBox8.Text + ":-1" + "\"" + " \"" + Path.Combine(pathnew + filenamewithoutextension + extImage));
                            else
                                p.StartInfo.Arguments = ("/C ffmpeg -hide_banner -i " + "\"" + addressfiles + "\"" + " -qscale:v 1 " + " -vf scale=" + "\"" + textBox8.Text + ":-1" + "\"" + " \"" + Path.Combine(pathnew + filenamewithoutextension + extImage));
                        }
                        if (checkBox32.Checked)
                        {
                            p2.StartInfo.Arguments = ("/C exiftool -overwrite_original -tagsfromfile " + "\"" + addressfiles + "\"" + " -all:all " + " \"" + Path.Combine(pathnew + filenamewithoutextension + extImage) + "\"");
                        }
                    }

                    if (checkBox26.Checked)
                    {
                        if (checkBox27.Checked)
                        {
                            NewFileName = Path.Combine(pathnew + filenamewithoutextension + ".mp3");
                            p.StartInfo.Arguments = ("/C ffmpeg -i " + "\"" + addressfiles + "\"" + " -map 0:a:0 -b:a " + textBox10.Text + "k " + " \"" + Path.Combine(pathnew + filenamewithoutextension + ".mp3"));
                        }
                    }
                    if (checkBox29.Checked)
                    {
                        if (checkBox27.Checked)
                        {
                            p.StartInfo.Arguments = ("/C ffmpeg -i " + "\"" + addressfiles + "\"" + " -f srt -i " + "\"" + addressfileswithoutextension + ".srt" + "\"" + " -map 0:0 -map 0:1 -map 1:0 -c:v copy -c:a copy -c:s mov_text " + "\"" + NewFileName);
                        }
                    }
                    p.StartInfo.UseShellExecute = false;
                    if (checkBox24.Checked == false)
                        p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    if (checkBox30.Checked == true)
                    {
                        richTextBox1.AppendText(p.StartInfo.Arguments);
                        break;
                    }
                    if (checkBox33.Checked && checkBox28.Checked)
                    {
                        p2.StartInfo.UseShellExecute = false;
                        p2.StartInfo.CreateNoWindow = true;
                        p2.StartInfo.RedirectStandardOutput = true;
                        p2.StartInfo.RedirectStandardInput = true;
                        p2.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                        p2.StartInfo.Arguments = ("/C exiftool -overwrite_original -tagsfromfile " + "\"" + addressfiles + "\"" + " -all:all " + " \"" + Path.Combine(pathnew + filenamewithoutextension + ".mp4") + "\"");
                        p2.Start();
                        p2.WaitForExit();
                    }
                    if (checkBox32.Checked && checkBox21.Checked)
                    {
                        p2.StartInfo.UseShellExecute = false;
                        p2.StartInfo.CreateNoWindow = true;
                        p2.StartInfo.RedirectStandardOutput = true;
                        p2.StartInfo.RedirectStandardInput = true;
                        p2.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                        p2.Start();
                    }
                    if (checkBox34.Checked==false)
                    {
                        Thread t = new Thread(() =>
                        {
                            p.Start();
                            p.WaitForExit();
                        });
                        t.Start();
                        t.Join();
                        if (checkBox32.Checked || checkBox33.Checked)
                        {
                            p2.Start();
                            p2.WaitForExit();
                        }
                    }
                    if (checkBox34.Checked)
                        RunProcessInThread(p.StartInfo.Arguments, p2.StartInfo.Arguments);

                    progressBar1.PerformStep();
                    stopwatch.Stop();
                    label2.Text = (NumberOfListBox + 1).ToString();
                    richTextBox1.AppendText(((NumberOfListBox + 1).ToString() + "- Done " + Convert.ToString(NumberOfListBox + 1) + "/" + listBox1.Items.Count.ToString() + ", in " + stopwatch.ElapsedMilliseconds.ToString() + "ms :" + addressfiles + "\r\n"));
                    if (checkBox3.Checked)
                    {
                        File.Delete(addressfiles);
                    }
                    if (checkBox1.Checked)
                    {
                        p.WaitForExit();
                        Process.Start("shutdown", "/s /t 0");
                    }
                }
            }
        }

        private void RunProcessInThread(string arguments, string arguments2)
        {
            // Create a new thread to run the process
            Thread thread = new Thread(() =>
            {
                try
                {
                    // Create a new process and start it
                    Process p = new Process();
                    string processPath = "C:\\Windows\\system32\\cmd.exe";
                    string processPath2 = "C:\\Windows\\system32\\cmd.exe";
                    p.StartInfo.FileName = processPath;
                    p.StartInfo.Arguments = arguments;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    p.Start();
                    // Wait for the process to exit
                    p.WaitForExit();
                    Process p2 = new Process();
                    p2.StartInfo.FileName = processPath2;
                    p2.StartInfo.Arguments = arguments2;
                    p2.StartInfo.UseShellExecute = false;
                    p2.StartInfo.CreateNoWindow = true;
                    p2.StartInfo.RedirectStandardOutput = true;
                    p2.StartInfo.RedirectStandardInput = true;
                    p2.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    p2.Start();
                    p2.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error running the process: {ex.Message}");
                }
            });

            // Start the thread
            thread.Start();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                listBox1.Items.Add(file);
            label1.Text = listBox1.Items.Count.ToString();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox2.Checked = false;
                checkBox11.Checked = false;
                checkBox6.Checked = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox4.Checked = false;
                checkBox11.Checked = false;
                checkBox6.Checked = false;
            }
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                checkBox4.Checked = false;
                checkBox2.Checked = false;
                checkBox6.Checked = false;
            }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox4.Checked = false;
                checkBox11.Checked = false;
                checkBox2.Checked = false;
            }
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                checkBox8.Checked = false;
                checkBox10.Checked = false;
            }
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void listBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                textBox4.Visible = true;
            }
            else
            {
                textBox4.Visible = false;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                textBox6.Visible = true;
                label8.Visible = true;
            }
            else
            {
                textBox6.Visible = false;
                label8.Visible = false;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked)
            {
                textBox9.Visible = true;
                label11.Visible = true;
                textBox11.Visible = true;
            }
            else
            {
                textBox9.Visible = false;
                label11.Visible = false;
                textBox11.Visible = false;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                checkBox22.Visible = true;
                checkBox23.Visible = true;
                textBox8.Visible = true;
                checkBox28.Checked = false;
                checkBox26.Checked = false;
                checkBox32.Visible = true;
                checkBox35.Visible = true;
                checkBox34.Visible = true;

            }
            else
            {
                checkBox22.Visible = false;
                checkBox23.Visible = false;
                textBox8.Visible = false;
                checkBox32.Visible = false;
                checkBox35.Visible = false;
                checkBox34.Visible = false;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked)
            {
                checkBox27.Visible = true;
                label10.Visible = true;
                textBox10.Visible = true;
                checkBox21.Checked = false;
                checkBox28.Checked = false;
            }
            else
            {
                checkBox27.Visible = false;
                label10.Visible = false;
                textBox10.Visible = false;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                textBox8.Visible = true;
            }
            else
            {
                textBox8.Visible = false;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
            {
                checkBox20.Visible = true;
            }
            else
            {
                checkBox20.Visible = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                checkBox15.Checked = false;
                checkBox16.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                checkBox14.Checked = false;
                checkBox16.Checked = false;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                checkBox14.Checked = false;
                checkBox15.Checked = false;
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked)
            {
                checkBox21.Checked = false;
                checkBox26.Checked = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                checkBox13.Checked = true;
                checkBox4.Checked = false;
                checkBox18.Checked = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                checkBox13.Checked = true;
                checkBox4.Checked = false;
                checkBox17.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(("1-Drag and drop file to the box" + "\r\n"));
            richTextBox1.AppendText(("2-choose format of files that you want convert" + "\r\n"));
            richTextBox1.AppendText(("3-click convert button" + "\r\n"));
            richTextBox1.AppendText(("this app is based on FFMPEG and is not for commercial goals" + "\r\n"));
            richTextBox1.AppendText(("*************************************************" + "\r\n"));
            richTextBox1.AppendText(("Video:" + "\r\n" + "CPU: for cpu intel converting" + "\r\n" + "Nvidia: for cpu as same as gpu converting" + "\r\n" + "Just CUDA: for only GPU convrting" + "\r\n" + "AMD: for AMD proccessor converting" + "\r\n"));
            richTextBox1.AppendText(("Video to image seq.: convert a video file to fps images in second" + "\r\n"));
            richTextBox1.AppendText(("Image seq. to video: convert collection of images to video file with fps in second" + "\r\n"));
            richTextBox1.AppendText(("*************************************************" + "\r\n"));
            richTextBox1.AppendText(("For Image convert, select Image" + "\r\n"));
            richTextBox1.AppendText(("*************************************************" + "\r\n"));
            richTextBox1.AppendText(("For Sound convert, select Audio" + "\r\n"));
            richTextBox1.AppendText(("*************************************************" + "\r\n"));
            richTextBox1.AppendText(("If farsi in name of file is existed, for using Exiftool, you must change number, click F2E No." + "\r\n"));
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int NumberOfListBox = 0; NumberOfListBox < listBox1.Items.Count; NumberOfListBox++)
            {
                string FilePath = listBox1.Items[NumberOfListBox].ToString();
                //string filePath = Directory.GetParent(FilePath).FullName;
                //ChangePersianNumbersInFilenames(ParentFolder);
                string fileName = Path.GetFileName(FilePath);
                string englishNumberFileName = ReplacePersianWithEnglishNumbers(fileName);
                string newFilePath = Path.Combine(Path.GetDirectoryName(FilePath), englishNumberFileName);
                File.Move(FilePath, newFilePath);
                Console.WriteLine($"Renamed: {FilePath} to {newFilePath}");
            }

        }
        static string ReplacePersianWithEnglishNumbers(string input)
        {
            // Define a mapping for Persian and English numbers
            string persianNumbers = "۰۱۲۳۴۵۶۷۸۹";
            string englishNumbers = "0123456789";
            // Create a translation dictionary
            var translation = new Dictionary<char, char>();
            for (int i = 0; i < persianNumbers.Length; i++)
            {
                translation[persianNumbers[i]] = englishNumbers[i];
            }
            // Use a regular expression to replace Persian numbers with English numbers
            string pattern = "[" + string.Join("", persianNumbers) + "]";
            string converted = Regex.Replace(input, pattern, m => translation[m.Value[0]].ToString());
            return converted;
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked)
                checkBox32.Checked = true;
            if (checkBox33.Checked == false)
                checkBox32.Checked =false;
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked)
                checkBox33.Checked = true;
            if (checkBox32.Checked == false)
                checkBox33.Checked = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/RE-MO-SH?tab=repositories");
        }
    }
    public class ProcessRunner
    {
        public void RunProcessInThread(string arguments, string arguments2)
        {
            // Create a new thread to run the process
            Thread thread = new Thread(() =>
            {
                try
                {
                    // Create a new process and start it
                    Process process = new Process();
                   string processPath = "C:\\Windows\\system32\\cmd.exe";
                    string processPath2 = "C:\\Windows\\system32\\cmd.exe";
                    process.StartInfo.FileName = processPath;
                    process.StartInfo.Arguments = arguments;
                    process.Start();

                    // Wait for the process to exit
                    process.WaitForExit();
                    Process process2 = new Process();
                    process2.StartInfo.FileName = processPath2;
                    process2.StartInfo.Arguments = arguments2;
                    process2.Start();
                    process2.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error running the process: {ex.Message}");
                }
            });

            // Start the thread
            thread.Start();
        }
    }
}