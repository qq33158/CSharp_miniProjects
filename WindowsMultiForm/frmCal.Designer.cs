
namespace WindowsMultiForm
{
    partial class frmCal
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
            this.rdbYear = new System.Windows.Forms.RadioButton();
            this.rbdMonth = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbYear
            // 
            this.rdbYear.AutoSize = true;
            this.rdbYear.Location = new System.Drawing.Point(77, 60);
            this.rdbYear.Name = "rdbYear";
            this.rdbYear.Size = new System.Drawing.Size(71, 16);
            this.rdbYear.TabIndex = 0;
            this.rdbYear.TabStop = true;
            this.rdbYear.Text = "每年計息";
            this.rdbYear.UseVisualStyleBackColor = true;
            // 
            // rbdMonth
            // 
            this.rbdMonth.AutoSize = true;
            this.rbdMonth.Location = new System.Drawing.Point(77, 107);
            this.rbdMonth.Name = "rbdMonth";
            this.rbdMonth.Size = new System.Drawing.Size(71, 16);
            this.rbdMonth.TabIndex = 1;
            this.rbdMonth.TabStop = true;
            this.rbdMonth.Text = "每月計息";
            this.rbdMonth.UseVisualStyleBackColor = true;
            // 
            // frmCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 183);
            this.Controls.Add(this.rbdMonth);
            this.Controls.Add(this.rdbYear);
            this.Name = "frmCal";
            this.Text = "選擇計息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbYear;
        private System.Windows.Forms.RadioButton rbdMonth;
    }
}

