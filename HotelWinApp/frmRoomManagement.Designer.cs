namespace HotelWinApp
{
    partial class frmRoomManagement
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
            this.dvgRoom = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnModifyService = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomTypeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgRoom
            // 
            this.dvgRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoom.Location = new System.Drawing.Point(14, 149);
            this.dvgRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dvgRoom.MultiSelect = false;
            this.dvgRoom.Name = "dvgRoom";
            this.dvgRoom.ReadOnly = true;
            this.dvgRoom.RowHeadersWidth = 51;
            this.dvgRoom.RowTemplate.Height = 25;
            this.dvgRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgRoom.Size = new System.Drawing.Size(744, 259);
            this.dvgRoom.TabIndex = 0;
            this.dvgRoom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgRoom_CellClick);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(14, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(131, 48);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Rooms";
            // 
            // btnModifyService
            // 
            this.btnModifyService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModifyService.Location = new System.Drawing.Point(398, 11);
            this.btnModifyService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyService.Name = "btnModifyService";
            this.btnModifyService.Size = new System.Drawing.Size(197, 64);
            this.btnModifyService.TabIndex = 2;
            this.btnModifyService.Text = "Modify Service";
            this.btnModifyService.UseVisualStyleBackColor = true;
            this.btnModifyService.Click += new System.EventHandler(this.btnModifyService_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReturn.Location = new System.Drawing.Point(625, 11);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(133, 64);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtRoomID
            // 
            this.txtRoomID.Enabled = false;
            this.txtRoomID.Location = new System.Drawing.Point(141, 103);
            this.txtRoomID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(114, 27);
            this.txtRoomID.TabIndex = 4;
            // 
            // txtRoomType
            // 
            this.txtRoomType.Enabled = false;
            this.txtRoomType.Location = new System.Drawing.Point(409, 103);
            this.txtRoomType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(114, 27);
            this.txtRoomType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Room Type ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Room ID";
            // 
            // txtRoomTypeName
            // 
            this.txtRoomTypeName.Enabled = false;
            this.txtRoomTypeName.Location = new System.Drawing.Point(643, 103);
            this.txtRoomTypeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomTypeName.Name = "txtRoomTypeName";
            this.txtRoomTypeName.Size = new System.Drawing.Size(114, 27);
            this.txtRoomTypeName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Room Type";
            // 
            // frmRoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoomTypeName);
            this.Controls.Add(this.txtRoomType);
            this.Controls.Add(this.txtRoomID);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnModifyService);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dvgRoom);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRoomManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rooms Management";
            this.Load += new System.EventHandler(this.frmRoomManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgRoom;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnModifyService;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomTypeName;
        private System.Windows.Forms.Label label3;
    }
}