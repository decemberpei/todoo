using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Todoo
{
    public partial class Todoo : Form
    {
        private int mLineCount = 0;
        private string mMaxLine = "";

        private string mTodoFile = "todo.txt";

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public Todoo()
        {
            InitializeComponent();
            this.Load += Todoo_Load;
            this.FormClosing += Todoo_FormClosing;
            todo_text.TextChanged += Todoo_text_TextChanged;
            this.MouseDoubleClick += Todoo_MouseDoubleClick;

            if (!File.Exists(mTodoFile))
            {
                File.WriteAllText(mTodoFile, "===\r\n" +
                    "double click here to edit todo list." +
                    "\r\n===" +
                    "\r\n\r\n***\r\nclose this window, \r\n" +
                    "then right click task bar icon to quit.\r\n***");
            }
        }

        private void Todoo_text_TextChanged(object sender, EventArgs e)
        {
            bool request_layout = false;
            int line_count = this.todo_text.Lines.Length;
            if (mLineCount < line_count)
            {
                mLineCount = line_count;
                request_layout = true;
            }

            string[] line_contents = this.todo_text.Lines;
            if(line_contents.Length <= 0)
            {
                auto_resize();
                return;
            }
            string max_line = line_contents[0];
            for (int i = 0; i < line_contents.Length; i++)
            {
                int li = Encoding.Default.GetByteCount(line_contents[i]);
                int lm = Encoding.Default.GetByteCount(max_line);
                max_line = li > lm ? line_contents[i] : max_line;
            }
            if (mMaxLine != max_line)
            {
                mMaxLine = max_line;
                request_layout = true;
            }
            if (request_layout)
            {
                auto_resize();
            }
        }

        private void Todoo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            todo_text.Enabled = true;
            todo_text.Focus();
            todo_text.SelectionStart = todo_text.Text.Length;
        }

        private void Todoo_Load(object sender, EventArgs e)
        {
            todo_text.Lines  = File.ReadAllLines("todo.txt");
            todo_text.SelectionStart = 0;
            todo_text.SelectionLength = 0;
            todo_text.Enabled = false;
            //if (GetForegroundWindow() != Handle)
            //{
                this.TopMost = true;
            //}
            auto_resize();
        }

        private void Todoo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                Application.Exit();
                return;
            }
            File.WriteAllLines("todo.txt", todo_text.Lines);
            todo_text.Enabled = false;
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void auto_resize()
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(mMaxLine, todo_text.Font);
            todo_text.Width = (int)size.Width + 32;
            todo_text.Height = (int)size.Height * mLineCount + 16;
            if(todo_text.Width < 360) { todo_text.Width = 360; }
            if (todo_text.Height < 240) { todo_text.Height = 240; }
            this.Width = todo_text.Width + 2;
            this.Height = (this.Height - this.ClientRectangle.Height) + todo_text.Height + 8;
            this.PerformLayout();
        }
    }
}
