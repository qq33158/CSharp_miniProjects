
namespace WindowsToolStrip
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCls = new System.Windows.Forms.ToolStripButton();
            this.tsbBullet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.form = new System.Windows.Forms.ToolStripLabel();
            this.cboSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFontColor = new System.Windows.Forms.ToolStripSplitButton();
            this.黑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.紅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.綠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.藍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.複製ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.剪下ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼上ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開檔OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSize1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSize2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cboFontColor = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.tsbCls,
            this.tsbBullet,
            this.toolStripSeparator2,
            this.form,
            this.cboSize,
            this.toolStripSeparator1,
            this.tsbFontColor});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(423, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(51, 22);
            this.tsbOpen.Text = "開檔";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "存檔";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCls
            // 
            this.tsbCls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCls.Image = ((System.Drawing.Image)(resources.GetObject("tsbCls.Image")));
            this.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCls.Name = "tsbCls";
            this.tsbCls.Size = new System.Drawing.Size(35, 22);
            this.tsbCls.Text = "清除";
            this.tsbCls.Click += new System.EventHandler(this.tsbCls_Click);
            // 
            // tsbBullet
            // 
            this.tsbBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBullet.Image = ((System.Drawing.Image)(resources.GetObject("tsbBullet.Image")));
            this.tsbBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBullet.Name = "tsbBullet";
            this.tsbBullet.Size = new System.Drawing.Size(59, 22);
            this.tsbBullet.Text = "項目符號";
            this.tsbBullet.Click += new System.EventHandler(this.tsbBullet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // form
            // 
            this.form.Name = "form";
            this.form.Size = new System.Drawing.Size(55, 22);
            this.form.Text = "字型大小";
            // 
            // cboSize
            // 
            this.cboSize.Items.AddRange(new object[] {
            "9",
            "10",
            "12",
            "14",
            "16"});
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(75, 25);
            this.cboSize.Text = "9";
            this.cboSize.SelectedIndexChanged += new System.EventHandler(this.cboSize_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFontColor
            // 
            this.tsbFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFontColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.黑ToolStripMenuItem,
            this.紅ToolStripMenuItem,
            this.綠ToolStripMenuItem,
            this.藍ToolStripMenuItem});
            this.tsbFontColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbFontColor.Image")));
            this.tsbFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFontColor.Name = "tsbFontColor";
            this.tsbFontColor.Size = new System.Drawing.Size(71, 22);
            this.tsbFontColor.Text = "字型顏色";
            // 
            // 黑ToolStripMenuItem
            // 
            this.黑ToolStripMenuItem.Name = "黑ToolStripMenuItem";
            this.黑ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.黑ToolStripMenuItem.Text = "黑";
            this.黑ToolStripMenuItem.Click += new System.EventHandler(this.黑ToolStripMenuItem_Click);
            // 
            // 紅ToolStripMenuItem
            // 
            this.紅ToolStripMenuItem.Name = "紅ToolStripMenuItem";
            this.紅ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.紅ToolStripMenuItem.Text = "紅";
            this.紅ToolStripMenuItem.Click += new System.EventHandler(this.紅ToolStripMenuItem_Click);
            // 
            // 綠ToolStripMenuItem
            // 
            this.綠ToolStripMenuItem.Name = "綠ToolStripMenuItem";
            this.綠ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.綠ToolStripMenuItem.Text = "綠";
            this.綠ToolStripMenuItem.Click += new System.EventHandler(this.綠ToolStripMenuItem_Click);
            // 
            // 藍ToolStripMenuItem
            // 
            this.藍ToolStripMenuItem.Name = "藍ToolStripMenuItem";
            this.藍ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.藍ToolStripMenuItem.Text = "藍";
            this.藍ToolStripMenuItem.Click += new System.EventHandler(this.藍ToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Location = new System.Drawing.Point(16, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(215, 115);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.複製ToolStripMenuItem1,
            this.剪下ToolStripMenuItem,
            this.貼上ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 70);
            // 
            // 複製ToolStripMenuItem1
            // 
            this.複製ToolStripMenuItem1.Name = "複製ToolStripMenuItem1";
            this.複製ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.複製ToolStripMenuItem1.Text = "複製";
            this.複製ToolStripMenuItem1.Click += new System.EventHandler(this.複製ToolStripMenuItem1_Click);
            // 
            // 剪下ToolStripMenuItem
            // 
            this.剪下ToolStripMenuItem.Name = "剪下ToolStripMenuItem";
            this.剪下ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.剪下ToolStripMenuItem.Text = "剪下";
            this.剪下ToolStripMenuItem.Click += new System.EventHandler(this.剪下ToolStripMenuItem_Click);
            // 
            // 貼上ToolStripMenuItem
            // 
            this.貼上ToolStripMenuItem.Name = "貼上ToolStripMenuItem";
            this.貼上ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.貼上ToolStripMenuItem.Text = "貼上";
            this.貼上ToolStripMenuItem.Click += new System.EventHandler(this.貼上ToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.richTextBox1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(426, 231);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(426, 256);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.toolStripMenuItem,
            this.cboSize1,
            this.cboSize2,
            this.toolStripMenuItem1,
            this.cboFontColor});
            this.menuStrip1.Location = new System.Drawing.Point(16, 145);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.存檔ToolStripMenuItem,
            this.開檔OToolStripMenuItem,
            this.清除ToolStripMenuItem,
            this.結束ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 存檔ToolStripMenuItem
            // 
            this.存檔ToolStripMenuItem.Name = "存檔ToolStripMenuItem";
            this.存檔ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.存檔ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.存檔ToolStripMenuItem.Text = "存檔(&S)";
            // 
            // 開檔OToolStripMenuItem
            // 
            this.開檔OToolStripMenuItem.Name = "開檔OToolStripMenuItem";
            this.開檔OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開檔OToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.開檔OToolStripMenuItem.Text = "開檔(&O)";
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.清除ToolStripMenuItem.Text = "清除";
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(67, 23);
            this.toolStripMenuItem.Text = "項目符號";
            // 
            // cboSize1
            // 
            this.cboSize1.Name = "cboSize1";
            this.cboSize1.Size = new System.Drawing.Size(67, 23);
            this.cboSize1.Text = "字型大小";
            // 
            // cboSize2
            // 
            this.cboSize2.AutoCompleteCustomSource.AddRange(new string[] {
            "9",
            "12",
            "14",
            "16"});
            this.cboSize2.Items.AddRange(new object[] {
            "9",
            "12",
            "14",
            "16"});
            this.cboSize2.Name = "cboSize2";
            this.cboSize2.Size = new System.Drawing.Size(75, 23);
            this.cboSize2.Text = "9";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 23);
            this.toolStripMenuItem1.Text = "字型顏色";
            // 
            // cboFontColor
            // 
            this.cboFontColor.Items.AddRange(new object[] {
            "黑",
            "紅",
            "綠",
            "藍"});
            this.cboFontColor.Name = "cboFontColor";
            this.cboFontColor.Size = new System.Drawing.Size(75, 23);
            this.cboFontColor.Text = "黑";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 256);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCls;
        private System.Windows.Forms.ToolStripButton tsbBullet;
        private System.Windows.Forms.ToolStripLabel form;
        private System.Windows.Forms.ToolStripComboBox cboSize;
        private System.Windows.Forms.ToolStripSplitButton tsbFontColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 黑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 紅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 綠ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 藍ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 存檔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開檔OToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 複製ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 剪下ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼上ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cboSize1;
        private System.Windows.Forms.ToolStripComboBox cboSize2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox cboFontColor;
    }
}

