
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;


using TagLauncher;

namespace TagLauncher
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class Form1 : System.Windows.Forms.Form
	{
		
		//Form 重写 Dispose，以清理组件列表。
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Windows 窗体设计器所必需的
		private System.ComponentModel.Container components = null;
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ListBox2 = new System.Windows.Forms.ListBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ListBox3 = new System.Windows.Forms.ListBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox1
            // 
            this.ListBox1.AllowDrop = true;
            this.ListBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 17;
            this.ListBox1.Location = new System.Drawing.Point(12, 41);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(254, 293);
            this.ListBox1.TabIndex = 0;
            this.ListBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox1_DragDrop);
            this.ListBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox1_DragEnter);
            this.ListBox1.DoubleClick += new System.EventHandler(this.ListBox1_DoubleClick);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button1.Location = new System.Drawing.Point(12, 9);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(72, 26);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "添加";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button2.Location = new System.Drawing.Point(104, 9);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(72, 26);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "移除";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button3.Location = new System.Drawing.Point(194, 9);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(72, 26);
            this.Button3.TabIndex = 3;
            this.Button3.Text = "更改";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Filter = "所有文件|*.*";
            this.OpenFileDialog1.Title = "添加";
            // 
            // ListBox2
            // 
            this.ListBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox2.FormattingEnabled = true;
            this.ListBox2.ItemHeight = 17;
            this.ListBox2.Location = new System.Drawing.Point(165, 215);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(84, 106);
            this.ListBox2.TabIndex = 4;
            this.ListBox2.Visible = false;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox1.Location = new System.Drawing.Point(95, 344);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(171, 23);
            this.TextBox1.TabIndex = 5;
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(13, 347);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 17);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "查找或指令：";
            // 
            // ListBox3
            // 
            this.ListBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox3.FormattingEnabled = true;
            this.ListBox3.ItemHeight = 17;
            this.ListBox3.Location = new System.Drawing.Point(12, 28);
            this.ListBox3.Name = "ListBox3";
            this.ListBox3.Size = new System.Drawing.Size(254, 293);
            this.ListBox3.TabIndex = 7;
            this.ListBox3.Visible = false;
            this.ListBox3.DoubleClick += new System.EventHandler(this.ListBox3_DoubleClick);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TextBox2);
            this.Panel1.Location = new System.Drawing.Point(12, 9);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(254, 325);
            this.Panel1.TabIndex = 8;
            this.Panel1.Visible = false;
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox2.Enabled = false;
            this.TextBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox2.Location = new System.Drawing.Point(4, 3);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(247, 319);
            this.TextBox2.TabIndex = 0;
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 375);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.ListBox3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.ListBox2);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		internal ListBox ListBox1;
		internal Button Button1;
		internal Button Button2;
		internal Button Button3;
		internal OpenFileDialog OpenFileDialog1;
		internal ListBox ListBox2;
		internal TextBox TextBox1;
		internal Label Label1;
		internal ListBox ListBox3;
		internal Panel Panel1;
		internal TextBox TextBox2;
	}
	
}
