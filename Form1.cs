using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TagLauncher {

    public partial class Form1 {
        public Form1() {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static Form1 defaultInstance;

        public static Form1 Default {
            get {
                if (defaultInstance == null) {
                    defaultInstance = new Form1();
                    defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e) {
            defaultInstance = null;
        }

        #endregion
        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern long ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        [DllImport("user32.dll", EntryPoint = "RegisterHotKey", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll", EntryPoint = "UnregisterHotKey", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnRegisterHotKey(IntPtr hwnd, int id);
        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int ExitWindowsEx(int uFlags, int dwReserved);

        public const int WM_HOTKEY = 0x312;
        public const int MOD_ALT = 0x1;
        public const int MOD_CONTROL = 0x2;
        public const int MOD_SHIFT = 0x4;
        public const System.Int32 GWL_WNDPROC = (-4);

        public void Button2_Click(object sender, EventArgs e) {
            if (ListBox1.Items.Count == 0 | ListBox1.SelectedIndex == -1) {
                return;
            }
            ListBox2.Items.RemoveAt(ListBox1.SelectedIndex);
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);
        }

        public void Button1_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog1.Title = "添加文件";
                OpenFileDialog1.ShowDialog();
                if (File.Exists(OpenFileDialog1.FileName)) {
                    if (CheckFileInList(OpenFileDialog1.FileName)) {
                        return;
                    }
                    StringBuilder s = new StringBuilder(OpenFileDialog1.FileName);
                    ListBox2.Items.Add(s.ToString());
                    ListBox1.Items.Add(s.ToString().Substring(s.ToString().LastIndexOf("\\") + 1));
                }
            } catch (Exception) {

            }
        }

        private bool CheckFileInList(string FilePath) {
            bool mFlag = false;
            for (int i = 0; i <= ListBox1.Items.Count - 1; i++) {
                if (FilePath == (string)ListBox2.Items[i]) {
                    mFlag = true;
                    break;
                }
            }
            return mFlag;
        }

        public void Button3_Click(object sender, EventArgs e) {
            if (ListBox1.Items.Count == 0 | ListBox1.SelectedIndex == -1) {
                return;
            }
            try {
                OpenFileDialog1.Title = "更改文件";
                OpenFileDialog1.ShowDialog();
                if (File.Exists(OpenFileDialog1.FileName)) {
                    if (CheckFileInList(OpenFileDialog1.FileName)) {
                        return;
                    }
                    StringBuilder s = new StringBuilder(OpenFileDialog1.FileName);
                    ListBox2.Items[ListBox1.SelectedIndex] = s.ToString();
                    ListBox1.Items[ListBox1.SelectedIndex] = s.ToString().Substring(s.ToString().LastIndexOf("\\") + 1);
                }
            } catch (Exception) {

            }
        }

        public void ListBox1_DoubleClick(object sender, EventArgs e) {
            if (ListBox1.SelectedIndex == -1 | ListBox1.Items.Count == 0) {
                return;
            }
            if (File.Exists(System.Convert.ToString(ListBox2.Items[ListBox1.SelectedIndex]))) {
                ShellExecute(this.Handle, "open", System.Convert.ToString(ListBox2.Items[ListBox1.SelectedIndex]), "", "", 5);
            }
            if (this.WindowState == FormWindowState.Normal) {
                this.WindowState = FormWindowState.Minimized;
                this.TopMost = false;
            }
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_HOTKEY) {
                if (this.WindowState == FormWindowState.Minimized) {
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    this.Left = System.Convert.ToInt32((double)Screen.PrimaryScreen.Bounds.Width / 2 - (double)this.Size.Width / 2);
                    this.Top = System.Convert.ToInt32((double)Screen.PrimaryScreen.Bounds.Height / 2 - (double)this.Size.Height / 2);
                    this.Activate();
                    TextBox1.Focus();
                } else if (this.WindowState == FormWindowState.Normal) {
                    this.WindowState = FormWindowState.Minimized;
                    this.TopMost = false;
                }
            }
            base.WndProc(ref m);
        }

        public void Form1_Load(object sender, EventArgs e) {
            bool flag;
            System.Threading.Mutex hMutex = new System.Threading.Mutex(true, Application.ProductName, out flag);
            hMutex.WaitOne(0, false);
            if (!flag) {
                Environment.Exit(0);
            } else {
                this.WindowState = FormWindowState.Normal;
                this.TopMost = true;
                this.Left = Convert.ToInt32((double)Screen.PrimaryScreen.Bounds.Width / 2 - (double)this.Size.Width / 2);
                this.Top = Convert.ToInt32((double)Screen.PrimaryScreen.Bounds.Height / 2 - (double)this.Size.Height / 2);
                this.Activate();
                TextBox1.Focus();
            }
            ListBox3.Left = ListBox1.Location.X;
            ListBox3.Top = ListBox1.Location.Y;
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            if (File.Exists(Application.StartupPath + "\\data.dat")) {
                ListBox2.Items.AddRange(File.ReadAllText(Application.StartupPath + "\\data.dat").Split("\r\n".ToCharArray()));
                if (ListBox2.Items.Count > 0) {
                    for (int i = ListBox2.Items.Count - 1; i >= 0; i--) {
                        if (!File.Exists(System.Convert.ToString(ListBox2.Items[i]))) {
                            ListBox2.Items.RemoveAt(i);
                        }
                    }
                }
                if (ListBox2.Items.Count > 0) {
                    for (int i = 0; i <= ListBox2.Items.Count - 1; i++) {
                        ListBox1.Items.Add(ListBox2.Items[i].ToString().Substring(System.Convert.ToInt32(ListBox2.Items[i].ToString().LastIndexOf("\\") + 1)));
                    }
                }
            }
            RegisterHotKey(this.Handle, 1, MOD_ALT, (System.Int32)Keys.Space);
        }

        public void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            UnRegisterHotKey(Handle, 1);
        }

        public void TextBox1_TextChanged(object sender, EventArgs e) {
            string t = TextBox1.Text.Trim();
            if (t.Length == 0) {
                ListBox3.Visible = false;
                ListBox3.Items.Clear();
                ListBox1.Visible = true;
                Panel1.Visible = false;
            } else {
                ListBox1.Visible = false;
                if (t.Substring(0, 1) == "#") {
                    ListBox3.Visible = false;
                    Panel1.Visible = true;
                    TextBox2.Text = "";
                    if (t.Length > 1) {
                        string r = t.Substring(1);
                        TextBox2.Text = eVal(r);
                    }
                } else if (t.Substring(0, 1) == "~") {
                    Panel1.Visible = true;
                    ListBox3.Visible = false;
                    if (t.Length > 1) {
                        if ((t.Substring(1).ToLower() == "poweroff") || (t.Substring(1).ToLower() == "关机")) {
                            TextBox2.Text = "关闭电脑。";
                        } else if ((t.Substring(1).ToLower() == "reboot") || (t.Substring(1).ToLower() == "重启")) {
                            TextBox2.Text = "重启电脑。";
                        } else if ((t.Substring(1).ToLower() == "sleep") || (t.Substring(1).ToLower() == "睡眠")) {
                            TextBox2.Text = "使电脑进入睡眠模式。";
                        } else if ((t.Substring(1).ToLower() == "help") || (t.Substring(1).ToLower() == "帮助")) {
                            TextBox2.Text = "~poweroff/~关机：关闭电脑。" + "\r\n" + "~reboot/~重启：重启电脑。" + "\r\n" + "~sleep/~睡眠：使电脑进入睡眠模式。" + "\r\n" + "\r\n" + "#exp：计算表达式exp的值。例如 #3+4 。";
                        } else {
                            TextBox2.Text = "这是无效的指令。";
                        }
                    }
                } else {
                    ListBox3.Visible = true;
                    Panel1.Visible = false;
                    ListBox3.Items.Clear();
                    for (int i = 0; i <= ListBox1.Items.Count - 1; i++) {
                        if (Regex.IsMatch(System.Convert.ToString(ListBox1.Items[i].ToString()), t)) {
                            ListBox3.Items.Add(ListBox1.Items[i].ToString());
                        }
                    }
                    if (ListBox3.Items.Count > 0) {
                        ListBox3.SelectedIndex = 0;
                    }
                }
            }
        }

        public string eVal(string Expression) {
            try {
                CSharpCodeProvider csCodeProvider = new CSharpCodeProvider();
                CompilerParameters csParams = new CompilerParameters();
                StringBuilder source = new StringBuilder("public class MainClass{ " +
                                 "public static object Eval(){ " +
                                     "return (EXP); " +
                                 "}" +
                             "}").Replace("EXP", Expression);
                csParams.CompilerOptions = "/t:library";
                csParams.GenerateInMemory = true;
                var csResults = csCodeProvider.CompileAssemblyFromSource(csParams, source.ToString());
                if (csResults.Errors.Count > 0) {
                    return "此表达式有误。";
                } else {
                    var ass = csResults.CompiledAssembly;
                    var type = ass.GetType("MainClass");
                    var result = type.InvokeMember("Eval", BindingFlags.InvokeMethod, null, null, null);
                    return Expression + "\r\n>>" + result.ToString();
                }
            } catch (Exception) {
                return "此表达式有误。";
            }
        }

        public void TextBox1_KeyDown(object sender, KeyEventArgs e) {
            if ((int)e.KeyCode == 13 | (int)e.KeyCode == 108) {
                if (Panel1.Visible) {
                    switch (TextBox2.Text) {
                        case "关闭电脑。":
                            ExitWindowsEx(4, 0);
                            ExitWindowsEx(1, 0);
                            break;
                        case "重启电脑。":
                            ExitWindowsEx(4, 0);
                            ExitWindowsEx(2, 0);
                            break;
                        case "使电脑进入睡眠模式。":
                            Interaction.Shell("rundll32.exe powrprof.dll SetSuspendState");
                            break;
                    }
                } else if (ListBox3.Visible) {
                    if (ListBox3.SelectedIndex != -1) {
                        ListBox3_DoubleClick(sender, e);
                    }
                }
                TextBox1.Clear();
                Panel1.Visible = false;
                ListBox3.Visible = false;
                ListBox1.Visible = true;
                this.WindowState = FormWindowState.Minimized;
                this.TopMost = false;
            } else if (ListBox3.Visible && ListBox3.Items.Count > 0 & ListBox3.SelectedIndex != -1) {
                if (e.KeyCode == Keys.Up & ListBox3.SelectedIndex > 0) {
                    ListBox3.SelectedIndex--;
                } else if (e.KeyCode == Keys.Down & ListBox3.SelectedIndex < ListBox3.Items.Count - 1) {
                    ListBox3.SelectedIndex++;
                }
            }
        }

        public void ListBox3_DoubleClick(object sender, EventArgs e) {
            if (ListBox3.Items.Count == 0 | ListBox3.SelectedIndex == -1) {
                return;
            }
            for (int i = 0; i <= ListBox1.Items.Count - 1; i++) {
                if (ListBox3.SelectedItem == ListBox1.Items[i]) {
                    ListBox1.SelectedIndex = i;
                    ListBox3.Visible = false;
                    TextBox1.Clear();
                    ListBox1_DoubleClick(sender, e);
                }
            }
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (File.Exists(Application.StartupPath + "\\data.dat")) {
                File.Delete(Application.StartupPath + "\\data.dat");
            }
            if (ListBox2.Items.Count > 0) {
                StringBuilder s = new StringBuilder();
                for (int i = 0; i <= ListBox2.Items.Count - 1; i++) {
                    s.Append(ListBox2.Items[i].ToString()).Append("\r\n");
                }
                File.WriteAllText(Application.StartupPath + "\\data.dat", s.ToString());
            }
        }

        public void ListBox1_DragDrop(object sender, DragEventArgs e) {
            string nFile = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!File.Exists(nFile)) {
                return;
            }
            if (CheckFileInList(nFile)) {
                return;
            }
            ListBox2.Items.Add(nFile);
            ListBox1.Items.Add(nFile.Substring(nFile.ToString().LastIndexOf("\\") + 1));
        }

        public void ListBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e) {

        }
    }

}
