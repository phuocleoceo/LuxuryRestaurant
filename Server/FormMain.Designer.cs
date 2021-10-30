
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lbMSG = new System.Windows.Forms.ListBox();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.grbMSG = new System.Windows.Forms.GroupBox();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTable.SuspendLayout();
            this.grbMSG.SuspendLayout();
            this.grbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.Location = new System.Drawing.Point(295, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(189, 21);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "<< Server started at ... >>";
            // 
            // lbMSG
            // 
            this.lbMSG.FormattingEnabled = true;
            this.lbMSG.ItemHeight = 21;
            this.lbMSG.Location = new System.Drawing.Point(6, 30);
            this.lbMSG.Name = "lbMSG";
            this.lbMSG.Size = new System.Drawing.Size(216, 361);
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
            this.grbTable.Location = new System.Drawing.Point(26, 55);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(263, 403);
            this.grbTable.TabIndex = 3;
            this.grbTable.TabStop = false;
            this.grbTable.Text = "Danh sách bàn :";
            // 
            // grbMSG
            // 
            this.grbMSG.Controls.Add(this.lbMSG);
            this.grbMSG.Location = new System.Drawing.Point(758, 55);
            this.grbMSG.Name = "grbMSG";
            this.grbMSG.Size = new System.Drawing.Size(222, 403);
            this.grbMSG.TabIndex = 4;
            this.grbMSG.TabStop = false;
            this.grbMSG.Text = "Thông điệp :";
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.lblTotal);
            this.grbOrder.Controls.Add(this.label4);
            this.grbOrder.Controls.Add(this.pnlOrder);
            this.grbOrder.Controls.Add(this.label3);
            this.grbOrder.Controls.Add(this.label2);
            this.grbOrder.Controls.Add(this.label1);
            this.grbOrder.Location = new System.Drawing.Point(339, 55);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(322, 397);
            this.grbOrder.TabIndex = 5;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Danh mục Order";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 475);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.grbMSG);
            this.Controls.Add(this.grbTable);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormMain";
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
    }
}

