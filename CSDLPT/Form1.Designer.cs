namespace CSDLPT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.cboQuery = new System.Windows.Forms.ComboBox();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.cboParam1 = new System.Windows.Forms.ComboBox();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.cboParam2 = new System.Windows.Forms.ComboBox();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.cboParam3 = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLoading = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.grpCRUD = new System.Windows.Forms.GroupBox();
            this.lblMaCT = new System.Windows.Forms.Label();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.cboTeam = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.grpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tabManage.SuspendLayout();
            this.grpCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabQuery);
            this.tabControl.Controls.Add(this.tabManage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(880, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.grpQuery);
            this.tabQuery.Controls.Add(this.dgvResult);
            this.tabQuery.Location = new System.Drawing.Point(4, 24);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(872, 422);
            this.tabQuery.TabIndex = 0;
            this.tabQuery.Text = "Truy vấn dữ liệu";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.lblQuery);
            this.grpQuery.Controls.Add(this.cboQuery);
            this.grpQuery.Controls.Add(this.lblParam1);
            this.grpQuery.Controls.Add(this.cboParam1);
            this.grpQuery.Controls.Add(this.lblParam2);
            this.grpQuery.Controls.Add(this.cboParam2);
            this.grpQuery.Controls.Add(this.lblParam3);
            this.grpQuery.Controls.Add(this.cboParam3);
            this.grpQuery.Controls.Add(this.btnRun);
            this.grpQuery.Controls.Add(this.button1);
            this.grpQuery.Controls.Add(this.lblLoading);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpQuery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQuery.Location = new System.Drawing.Point(3, 3);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(866, 110);
            this.grpQuery.TabIndex = 0;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "Chọn câu hỏi và tham số";
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.Location = new System.Drawing.Point(16, 28);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(51, 15);
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "Câu hỏi:";
            // 
            // cboQuery
            // 
            this.cboQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuery.FormattingEnabled = true;
            this.cboQuery.Location = new System.Drawing.Point(80, 25);
            this.cboQuery.Name = "cboQuery";
            this.cboQuery.Size = new System.Drawing.Size(480, 23);
            this.cboQuery.TabIndex = 1;
            this.cboQuery.SelectedIndexChanged += new System.EventHandler(this.cboQuery_SelectedIndexChanged);
            // 
            // lblParam1
            // 
            this.lblParam1.AutoSize = true;
            this.lblParam1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam1.Location = new System.Drawing.Point(16, 58);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(0, 15);
            this.lblParam1.TabIndex = 2;
            // 
            // cboParam1
            // 
            this.cboParam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParam1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParam1.FormattingEnabled = true;
            this.cboParam1.Location = new System.Drawing.Point(80, 55);
            this.cboParam1.Name = "cboParam1";
            this.cboParam1.Size = new System.Drawing.Size(200, 23);
            this.cboParam1.TabIndex = 3;
            // 
            // lblParam2
            // 
            this.lblParam2.AutoSize = true;
            this.lblParam2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam2.Location = new System.Drawing.Point(296, 58);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(0, 15);
            this.lblParam2.TabIndex = 4;
            // 
            // cboParam2
            // 
            this.cboParam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParam2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParam2.FormattingEnabled = true;
            this.cboParam2.Location = new System.Drawing.Point(360, 55);
            this.cboParam2.Name = "cboParam2";
            this.cboParam2.Size = new System.Drawing.Size(200, 23);
            this.cboParam2.TabIndex = 5;
            // 
            // lblParam3
            // 
            this.lblParam3.AutoSize = true;
            this.lblParam3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam3.Location = new System.Drawing.Point(16, 88);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(0, 15);
            this.lblParam3.TabIndex = 6;
            // 
            // cboParam3
            // 
            this.cboParam3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParam3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParam3.FormattingEnabled = true;
            this.cboParam3.Location = new System.Drawing.Point(80, 85);
            this.cboParam3.Name = "cboParam3";
            this.cboParam3.Size = new System.Drawing.Size(200, 23);
            this.cboParam3.TabIndex = 7;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(576, 25);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 32);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Chạy";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(576, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Đổi CLB";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.Blue;
            this.lblLoading.Location = new System.Drawing.Point(680, 28);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(0, 15);
            this.lblLoading.TabIndex = 10;
            this.lblLoading.Visible = false;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(3, 119);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(863, 300);
            this.dgvResult.TabIndex = 1;
            // 
            // tabManage
            // 
            this.tabManage.Controls.Add(this.grpCRUD);
            this.tabManage.Controls.Add(this.dgvPlayers);
            this.tabManage.Location = new System.Drawing.Point(4, 24);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(872, 422);
            this.tabManage.TabIndex = 1;
            this.tabManage.Text = "Quản lý cầu thủ";
            this.tabManage.UseVisualStyleBackColor = true;
            // 
            // grpCRUD
            // 
            this.grpCRUD.Controls.Add(this.lblMaCT);
            this.grpCRUD.Controls.Add(this.txtMaCT);
            this.grpCRUD.Controls.Add(this.lblHoTen);
            this.grpCRUD.Controls.Add(this.txtHoTen);
            this.grpCRUD.Controls.Add(this.lblTeam);
            this.grpCRUD.Controls.Add(this.cboTeam);
            this.grpCRUD.Controls.Add(this.btnAdd);
            this.grpCRUD.Controls.Add(this.btnEdit);
            this.grpCRUD.Controls.Add(this.btnDelete);
            this.grpCRUD.Controls.Add(this.btnRefresh);
            this.grpCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCRUD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCRUD.Location = new System.Drawing.Point(3, 3);
            this.grpCRUD.Name = "grpCRUD";
            this.grpCRUD.Size = new System.Drawing.Size(866, 80);
            this.grpCRUD.TabIndex = 0;
            this.grpCRUD.TabStop = false;
            this.grpCRUD.Text = "Thông tin cầu thủ";
            // 
            // lblMaCT
            // 
            this.lblMaCT.AutoSize = true;
            this.lblMaCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaCT.Location = new System.Drawing.Point(16, 28);
            this.lblMaCT.Name = "lblMaCT";
            this.lblMaCT.Size = new System.Drawing.Size(45, 15);
            this.lblMaCT.TabIndex = 0;
            this.lblMaCT.Text = "Mã CT:";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCT.Location = new System.Drawing.Point(70, 25);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(100, 23);
            this.txtMaCT.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(176, 28);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(240, 25);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 23);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(466, 28);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(49, 15);
            this.lblTeam.TabIndex = 4;
            this.lblTeam.Text = "Tên đội:";
            // 
            // cboTeam
            // 
            this.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTeam.FormattingEnabled = true;
            this.cboTeam.Location = new System.Drawing.Point(521, 25);
            this.cboTeam.Name = "cboTeam";
            this.cboTeam.Size = new System.Drawing.Size(160, 23);
            this.cboTeam.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(693, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(693, 53);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 28);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(779, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(780, 52);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 28);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Tải lại";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(3, 89);
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(863, 330);
            this.dgvPlayers.TabIndex = 1;
            this.dgvPlayers.SelectionChanged += new System.EventHandler(this.dgvPlayers_SelectionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý bóng đá";
            this.tabControl.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.tabManage.ResumeLayout(false);
            this.grpCRUD.ResumeLayout(false);
            this.grpCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.ComboBox cboQuery;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.ComboBox cboParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.ComboBox cboParam2;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.ComboBox cboParam3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.GroupBox grpCRUD;
        private System.Windows.Forms.Label lblMaCT;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ComboBox cboTeam;
         private System.Windows.Forms.Button btnAdd;
         private System.Windows.Forms.Button btnEdit;
         private System.Windows.Forms.Button btnDelete;
         private System.Windows.Forms.Button btnRefresh;
         private System.Windows.Forms.DataGridView dgvPlayers;
         private System.Windows.Forms.Label lblLoading;
     }
 }
