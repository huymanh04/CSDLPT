using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace CSDLPT
{
	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();
			cbBranch.Items.Clear();
			cbBranch.Items.Add("CLB1");
			cbBranch.Items.Add("CLB2");
			cbBranch.Items.Add("");
			cbBranch.SelectedIndex = 0;
			// nạp danh sách server từ file
			LoadServersFromFile(); 

        }

		private void btnLogin_Click(object sender, EventArgs e)
		{
			var branch = cbBranch.SelectedItem?.ToString() ?? string.Empty;
			var username = txtUsername.Text.Trim();
			var password = txtPassword.Text;

			

			// Máy chủ lấy từ file cấu hình (servers.txt) nếu có
			string serverInstance = (cbServer)?.SelectedItem?.ToString() ?? Environment.MachineName;
			string databaseName = branch == "CLB1" ? DBUtils.DbNameCLB1 : DBUtils.DbNameCLB2;

			string connectionString = $"Data Source={serverInstance};Initial Catalog={databaseName};User ID={username};Password={password};TrustServerCertificate=True;";
			if (username == string.Empty)
			{
                 connectionString =
					 $"Data Source={serverInstance};Initial Catalog=PhanTanBongDa;Integrated Security=True;TrustServerCertificate=True;";

            }
            try
			{
				using (var conn = new SqlConnection(connectionString))
				{
					conn.Open();
				}
				DBUtils.ConnectionString = connectionString;
				DBUtils.SelectedBranch = branch;
				this.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Kết nối thất bại: " + ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoadServersFromFile()
		{
			try
				{
				var cb = cbServer;
				if (cb == null) return;
				cb.Items.Clear();
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string path = Path.Combine(baseDir, "servers.txt");
				if (File.Exists(path))
				{
					foreach (var line in File.ReadAllLines(path))
					{
						var s = (line ?? string.Empty).Trim();
						if (s.Length == 0 || s.StartsWith("#")) continue;
						cb.Items.Add(s);
					}
				}
				if (cb.Items.Count == 0)
				{
					cb.Items.Add(Environment.MachineName);
				}
				cb.SelectedIndex = 0;
			}
			catch
			{
				var cb = this.Controls["cbServer"] as ComboBox;
				if (cb == null) return;
				cb.Items.Clear();
				cb.Items.Add(Environment.MachineName);
				cb.SelectedIndex = 0;
			}
		}
	}
}


