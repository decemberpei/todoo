
using System;

namespace Todoo
{
    partial class Todoo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Todoo));
            this.todo_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // todo_text
            // 
            this.todo_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todo_text.Location = new System.Drawing.Point(12, 12);
            this.todo_text.Multiline = true;
            this.todo_text.Name = "todo_text";
            this.todo_text.Size = new System.Drawing.Size(616, 622);
            this.todo_text.TabIndex = 0;
            this.todo_text.WordWrap = false;
            // 
            // Todoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 646);
            this.Controls.Add(this.todo_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(46, 22, 46, 22);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Todoo";
            this.Text = "Todoo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox todo_text;
    }
}

