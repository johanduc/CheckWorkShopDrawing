
namespace CheckWorkShopDrawing
{
    partial class Form1
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
            this.btn_CheckDrawing = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ts_ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ts_Label = new System.Windows.Forms.ToolStripLabel();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CheckDrawing
            // 
            this.btn_CheckDrawing.Location = new System.Drawing.Point(21, 12);
            this.btn_CheckDrawing.Name = "btn_CheckDrawing";
            this.btn_CheckDrawing.Size = new System.Drawing.Size(136, 73);
            this.btn_CheckDrawing.TabIndex = 0;
            this.btn_CheckDrawing.Text = "Check Drawing";
            this.btn_CheckDrawing.UseVisualStyleBackColor = true;
            this.btn_CheckDrawing.Click += new System.EventHandler(this.btn_CheckDrawing_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ProgressBar,
            this.ts_Label});
            this.toolStrip.Location = new System.Drawing.Point(0, 298);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(501, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ts_ProgressBar
            // 
            this.ts_ProgressBar.Name = "ts_ProgressBar";
            this.ts_ProgressBar.Size = new System.Drawing.Size(100, 22);
            // 
            // ts_Label
            // 
            this.ts_Label.Name = "ts_Label";
            this.ts_Label.Size = new System.Drawing.Size(39, 22);
            this.ts_Label.Text = "Status";
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(181, 12);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.Size = new System.Drawing.Size(295, 241);
            this.advancedDataGridView1.TabIndex = 2;
            this.advancedDataGridView1.TimeFilter = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(501, 323);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btn_CheckDrawing);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Check Work Shop Drawing";
            this.TopMost = true;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckDrawing;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripProgressBar ts_ProgressBar;
        private System.Windows.Forms.ToolStripLabel ts_Label;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
    }
}

