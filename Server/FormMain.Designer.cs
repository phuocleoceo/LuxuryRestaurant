
namespace Server
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lbMSG = new System.Windows.Forms.ListBox();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.grbMSG = new System.Windows.Forms.GroupBox();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialogLR = new System.Windows.Forms.PrintDialog();
            this.printDocumentLR = new System.Drawing.Printing.PrintDocument();
            this.grbTable.SuspendLayout();
            this.grbMSG.SuspendLayout();
            this.grbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(350, 5);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(189, 21);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "<< Server started at ... >>";
            // 
            // lbMSG
            // 
            this.lbMSG.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMSG.FormattingEnabled = true;
            this.lbMSG.HorizontalScrollbar = true;
            this.lbMSG.ItemHeight = 21;
            this.lbMSG.Location = new System.Drawing.Point(6, 24);
            this.lbMSG.Name = "lbMSG";
            this.lbMSG.Size = new System.Drawing.Size(240, 361);
            this.lbMSG.TabIndex = 1;
            // 
            // pnlTable
            // 
            this.pnlTable.Location = new System.Drawing.Point(6, 28);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(245, 369);
            this.pnlTable.TabIndex = 2;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.pnlTable);
            this.grbTable.Location = new System.Drawing.Point(28, 55);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(263, 403);
            this.grbTable.TabIndex = 3;
            this.grbTable.TabStop = false;
            this.grbTable.Text = "Danh sách bàn :";
            // 
            // grbMSG
            // 
            this.grbMSG.Controls.Add(this.lbMSG);
            this.grbMSG.Location = new System.Drawing.Point(701, 55);
            this.grbMSG.Name = "grbMSG";
            this.grbMSG.Size = new System.Drawing.Size(252, 403);
            this.grbMSG.TabIndex = 4;
            this.grbMSG.TabStop = false;
            this.grbMSG.Text = "Thông điệp :";
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.lblTableName);
            this.grbOrder.Controls.Add(this.lblTotal);
            this.grbOrder.Controls.Add(this.label4);
            this.grbOrder.Controls.Add(this.pnlOrder);
            this.grbOrder.Controls.Add(this.label3);
            this.grbOrder.Controls.Add(this.label2);
            this.grbOrder.Controls.Add(this.label1);
            this.grbOrder.Location = new System.Drawing.Point(336, 55);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(322, 397);
            this.grbOrder.TabIndex = 5;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Danh mục Order";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(127, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(36, 21);
            this.lblTableName.TabIndex = 6;
            this.lblTableName.Text = "Bàn";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(181, 370);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 21);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "xxx VNĐ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng tiền :";
            // 
            // pnlOrder
            // 
            this.pnlOrder.Location = new System.Drawing.Point(26, 60);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(260, 296);
            this.pnlOrder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Món ăn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 0;
            // 
            // btnPurchase
            // 
            this.btnPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPurchase.BackColor = System.Drawing.Color.White;
            this.btnPurchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPurchase.BackgroundImage")));
            this.btnPurchase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchase.Enabled = false;
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPurchase.Location = new System.Drawing.Point(568, 39);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(5);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(42, 40);
            this.btnPurchase.TabIndex = 51;
            this.btnPurchase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.Location = new System.Drawing.Point(620, 39);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(41, 40);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialogLR
            // 
            this.printDialogLR.UseEXDialog = true;
            // 
            // printDocumentLR
            // 
            this.printDocumentLR.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentLR_PrintPage);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 475);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.grbMSG);
            this.Controls.Add(this.grbTable);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Luxury Restaurant";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grbTable.ResumeLayout(false);
            this.grbMSG.ResumeLayout(false);
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListBox lbMSG;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.GroupBox grbMSG;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.PrintDialog printDialogLR;
        private System.Drawing.Printing.PrintDocument printDocumentLR;
    }
}

