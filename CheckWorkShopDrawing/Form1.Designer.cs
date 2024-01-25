
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
            this.adgv_ResultTable = new ADGV.AdvancedDataGridView();
            this.col_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DrawingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DrawingMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TypeMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_missingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.adgv_ResultTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CheckDrawing
            // 
            this.btn_CheckDrawing.BackColor = System.Drawing.Color.Gray;
            this.btn_CheckDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckDrawing.ForeColor = System.Drawing.Color.White;
            this.btn_CheckDrawing.Location = new System.Drawing.Point(415, 437);
            this.btn_CheckDrawing.Name = "btn_CheckDrawing";
            this.btn_CheckDrawing.Size = new System.Drawing.Size(115, 32);
            this.btn_CheckDrawing.TabIndex = 0;
            this.btn_CheckDrawing.Text = "Check Drawing";
            this.btn_CheckDrawing.UseVisualStyleBackColor = false;
            this.btn_CheckDrawing.Click += new System.EventHandler(this.btn_CheckDrawing_Click);
            // 
            // adgv_ResultTable
            // 
            this.adgv_ResultTable.AutoGenerateContextFilters = true;
            this.adgv_ResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv_ResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_No,
            this.col_DrawingType,
            this.col_DrawingMark,
            this.col_TypeMissing,
            this.col_missingID});
            this.adgv_ResultTable.DateWithTime = false;
            this.adgv_ResultTable.Location = new System.Drawing.Point(12, 12);
            this.adgv_ResultTable.Name = "adgv_ResultTable";
            this.adgv_ResultTable.ReadOnly = true;
            this.adgv_ResultTable.Size = new System.Drawing.Size(544, 419);
            this.adgv_ResultTable.TabIndex = 2;
            this.adgv_ResultTable.TimeFilter = false;
            this.adgv_ResultTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_ResultTable_CellDoubleClick);
            // 
            // col_No
            // 
            this.col_No.HeaderText = "No";
            this.col_No.MinimumWidth = 22;
            this.col_No.Name = "col_No";
            this.col_No.ReadOnly = true;
            this.col_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col_No.Width = 75;
            // 
            // col_DrawingType
            // 
            this.col_DrawingType.HeaderText = "Drg Type";
            this.col_DrawingType.MinimumWidth = 22;
            this.col_DrawingType.Name = "col_DrawingType";
            this.col_DrawingType.ReadOnly = true;
            this.col_DrawingType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_DrawingMark
            // 
            this.col_DrawingMark.HeaderText = "Drg Mark";
            this.col_DrawingMark.MinimumWidth = 22;
            this.col_DrawingMark.Name = "col_DrawingMark";
            this.col_DrawingMark.ReadOnly = true;
            this.col_DrawingMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_TypeMissing
            // 
            this.col_TypeMissing.HeaderText = "Type Missing";
            this.col_TypeMissing.MinimumWidth = 22;
            this.col_TypeMissing.Name = "col_TypeMissing";
            this.col_TypeMissing.ReadOnly = true;
            this.col_TypeMissing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_missingID
            // 
            this.col_missingID.HeaderText = "Object ID";
            this.col_missingID.MinimumWidth = 22;
            this.col_missingID.Name = "col_missingID";
            this.col_missingID.ReadOnly = true;
            this.col_missingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 476);
            this.Controls.Add(this.adgv_ResultTable);
            this.Controls.Add(this.btn_CheckDrawing);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Check Work Shop Drawing";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adgv_ResultTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckDrawing;
        private ADGV.AdvancedDataGridView adgv_ResultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DrawingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DrawingMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TypeMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_missingID;
    }
}

