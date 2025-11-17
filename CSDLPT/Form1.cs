using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CSDLPT
{
    public partial class Form1 : Form
    {
        private DataTable _resultTable = new DataTable();
        // Cache dữ liệu để tránh load lại nhiều lần
        private Dictionary<string, List<string>> _cacheData = new Dictionary<string, List<string>>();
        private bool _isLoading = false;

        public Form1()
        {
            InitializeComponent();
        }

        // ----- UI 10 CÂU HỎI -----
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var items = new[]
            {
                "1. Cầu thủ theo câu lạc bộ (@clb)",
                "2. Số trận tham gia của cầu thủ (@hoten)",
                "3. Số trận hòa tại sân (@sandau)",
                "4. Cầu thủ vua phá lưới",
                "5. Mã trận có trọng tài @trongtai và cầu thủ @hoten",
                "6. Hai cầu thủ có cùng CLB? (@hoten1, @hoten2)",
                "7. Cầu thủ có tham gia nhưng tổng bàn = 0",
                "8. Cầu thủ tham gia từ 3 trận trở lên",
                "9. Tổng bàn thắng của đội (@tendb)",
                "10. Cầu thủ chưa tham gia trận nào"
            };
            cboQuery.Items.Clear();
            cboQuery.Items.AddRange(items);
            if (cboQuery.Items.Count > 0) cboQuery.SelectedIndex = 0;
            // nạp tên đội cho CRUD
            LoadTeams(cboTeam);
            // Load danh sách cầu thủ cho tab quản lý
            RefreshPlayers();
        }

        private void cboQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParam1.Visible = cboParam1.Visible = false;
            lblParam2.Visible = cboParam2.Visible = false;
            lblParam3.Visible = cboParam3.Visible = false;
            cboParam1.Items.Clear();
            cboParam2.Items.Clear();
            cboParam3.Items.Clear();

            switch (cboQuery.SelectedIndex)
            {
                case 0: lblParam1.Text = "@clb"; lblParam1.Visible = cboParam1.Visible = true; LoadClubs(cboParam1); break;
                case 1: lblParam1.Text = "@hoten"; lblParam1.Visible = cboParam1.Visible = true; LoadPlayers(cboParam1); break;
                case 2: lblParam1.Text = "@sandau"; lblParam1.Visible = cboParam1.Visible = true; LoadStadiums(cboParam1); break;
                case 3: break;
                case 4:
                    lblParam1.Text = "@hoten"; lblParam1.Visible = cboParam1.Visible = true; LoadPlayers(cboParam1);
                    lblParam2.Text = "@trongtai"; lblParam2.Visible = cboParam2.Visible = true; LoadReferees(cboParam2);
                    break;
                case 5:
                    lblParam1.Text = "@hoten1"; lblParam1.Visible = cboParam1.Visible = true; LoadPlayers(cboParam1);
                    lblParam2.Text = "@hoten2"; lblParam2.Visible = cboParam2.Visible = true; LoadPlayers(cboParam2);
                    break;
                case 6: break;
                case 7: break;
                case 8: lblParam1.Text = "@tendb"; lblParam1.Visible = cboParam1.Visible = true; LoadTeams(cboParam1); break;
                case 9: break;
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (_isLoading) return;
            _isLoading = true;
            btnRun.Enabled = false;
            btnRun.Text = "Đang chạy...";
            lblLoading.Visible = true;
            lblLoading.Text = "Đang tải dữ liệu...";
            dgvResult.DataSource = null;
            Application.DoEvents();
            
            // Lấy giá trị từ UI thread trước khi vào background thread
            int queryIndex = cboQuery.SelectedIndex;
            string connString = DBUtils.ConnectionString;
            string param1 = cboParam1.SelectedItem?.ToString() ?? string.Empty;
            string param2 = cboParam2.SelectedItem?.ToString() ?? string.Empty;
            string param3 = cboParam3.SelectedItem?.ToString() ?? string.Empty;
            
            try
            {
                DataTable dt = await Task.Run(() =>
                {
                    using (var conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        using (var cmd = BuildQueryCommand(conn, queryIndex, param1, param2, param3))
                        {
                            cmd.CommandTimeout = 30; // 30 giây timeout
                            using (var da = new SqlDataAdapter(cmd))
                            {
                                var table = new DataTable();
                                da.Fill(table);
                                return table;
                            }
                        }
                    }
                });
                
                // Update UI trên main thread
                _resultTable = dt;
                dgvResult.SuspendLayout();
                dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvResult.DataSource = null;
                Application.DoEvents();
                dgvResult.DataSource = _resultTable;
                dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvResult.ResumeLayout();
                lblLoading.Text = $"Đã tải {dt.Rows.Count} dòng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLoading.Text = "Lỗi: " + ex.Message;
            }
            finally
            {
                _isLoading = false;
                btnRun.Enabled = true;
                btnRun.Text = "Chạy";
                await Task.Delay(2000); // Hiển thị thông báo 2 giây
                lblLoading.Visible = false;
            }
        }

        private SqlCommand BuildQueryCommand(SqlConnection conn, int index, string param1 = "", string param2 = "", string param3 = "")
        {
            var cmd = conn.CreateCommand();
            cmd.CommandTimeout = 30; // Timeout 30 giây
            switch (index)
            {
                case 0:
                    cmd.CommandText = @"SELECT ct.mact, ct.hoten
FROM cauthu ct JOIN doibong db ON db.madb = ct.madb
WHERE db.clb = @clb";
                    cmd.Parameters.AddWithValue("@clb", param1);
                    break;
                case 1:
                    cmd.CommandText = @"SELECT ct.mact, ct.hoten, COUNT(DISTINCT tg.matd) AS so_tran_tham_gia
FROM cauthu ct LEFT JOIN thamgia tg ON tg.mact = ct.mact
WHERE ct.hoten = @hoten
GROUP BY ct.mact, ct.hoten";
                    cmd.Parameters.AddWithValue("@hoten", param1);
                    break;
                case 2:
                    cmd.CommandText = @"WITH team_goals AS (
    SELECT td.matd, ct.madb, SUM(tg.sotrai) AS goals
    FROM trandau td
    JOIN thamgia tg ON tg.matd = td.matd
    JOIN cauthu ct  ON ct.mact = tg.mact
    WHERE td.sandau = @sandau
    GROUP BY td.matd, ct.madb
), match_goals AS (
    SELECT matd, MIN(goals) AS min_goals, MAX(goals) AS max_goals, COUNT(*) AS so_doi
    FROM team_goals
    GROUP BY matd
)
SELECT COUNT(*) AS so_tran_hoa
FROM match_goals
WHERE so_doi >= 2 AND min_goals = max_goals";
                    cmd.Parameters.AddWithValue("@sandau", param1);
                    break;
                case 3:
                    cmd.CommandText = @"WITH total_goals AS (
    SELECT ct.mact, ct.hoten, SUM(ISNULL(tg.sotrai,0)) AS tong_ban
    FROM cauthu ct
    LEFT JOIN thamgia tg ON tg.mact = ct.mact
    GROUP BY ct.mact, ct.hoten
), mx AS (
    SELECT MAX(tong_ban) AS max_goals FROM total_goals
)
SELECT t.mact, t.hoten
FROM total_goals t
CROSS JOIN mx
WHERE t.tong_ban = mx.max_goals";
                    break;
                case 4:
                    cmd.CommandText = @"SELECT DISTINCT td.matd
FROM trandau td
JOIN thamgia tg ON tg.matd = td.matd
JOIN cauthu ct  ON ct.mact = tg.mact
WHERE td.trongtai = @trongtai AND ct.hoten = @hoten";
                    cmd.Parameters.AddWithValue("@hoten", param1);
                    cmd.Parameters.AddWithValue("@trongtai", param2);
                    break;
                case 5:
                    cmd.CommandText = @"SELECT CASE WHEN COUNT(*) > 0 THEN N'Cùng câu lạc bộ' ELSE N'Khác câu lạc bộ' END AS ket_qua
FROM (
    SELECT ct1.madb AS db1, ct2.madb AS db2
    FROM cauthu ct1 CROSS JOIN cauthu ct2
    WHERE ct1.hoten = @hoten1 AND ct2.hoten = @hoten2
) x
WHERE x.db1 = x.db2";
                    cmd.Parameters.AddWithValue("@hoten1", param1);
                    cmd.Parameters.AddWithValue("@hoten2", param2);
                    break;
                case 6:
                    cmd.CommandText = @"WITH sums AS (
    SELECT ct.mact, ct.hoten, SUM(ISNULL(tg.sotrai,0)) AS tong_ban, COUNT(tg.matd) AS so_tran
    FROM cauthu ct JOIN thamgia tg ON tg.mact = ct.mact
    GROUP BY ct.mact, ct.hoten
)
SELECT mact, hoten FROM sums WHERE so_tran > 0 AND tong_ban = 0";
                    break;
                case 7:
                    cmd.CommandText = @"SELECT ct.mact, ct.hoten
FROM cauthu ct
WHERE (SELECT COUNT(DISTINCT tg.matd) FROM thamgia tg WHERE tg.mact = ct.mact) >= 3";
                    break;
                case 8:
                    cmd.CommandText = @"SELECT db.tendb, SUM(ISNULL(tg.sotrai,0)) AS tong_ban_doi
FROM thamgia tg JOIN cauthu ct ON ct.mact = tg.mact
JOIN doibong db ON db.madb = ct.madb
WHERE db.tendb = @tendb
GROUP BY db.tendb";
                    cmd.Parameters.AddWithValue("@tendb", param1);
                    break;
                case 9:
                    cmd.CommandText = @"SELECT ct.mact, ct.hoten
FROM cauthu ct
WHERE NOT EXISTS (SELECT 1 FROM thamgia tg WHERE tg.mact = ct.mact)";
                    break;
                default:
                    cmd.CommandText = "SELECT 1 WHERE 1=0";
                    break;
            }
            return cmd;
        }

        private void LoadPlayers(ComboBox combo)
        {
            const string cacheKey = "players";
            if (_cacheData.ContainsKey(cacheKey))
            {
                combo.Items.Clear();
                combo.Items.AddRange(_cacheData[cacheKey].ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
                return;
            }
            
            try
            {
                var list = new List<string>();
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT hoten FROM cauthu ORDER BY hoten";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader.GetString(0));
                    }
                }
                _cacheData[cacheKey] = list;
                combo.Items.Clear();
                combo.Items.AddRange(list.ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadClubs(ComboBox combo)
        {
            const string cacheKey = "clubs";
            if (_cacheData.ContainsKey(cacheKey))
            {
                combo.Items.Clear();
                combo.Items.AddRange(_cacheData[cacheKey].ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
                return;
            }
            
            try
            {
                var list = new List<string>();
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT clb FROM doibong ORDER BY clb";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader.GetString(0));
                    }
                }
                _cacheData[cacheKey] = list;
                combo.Items.Clear();
                combo.Items.AddRange(list.ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadStadiums(ComboBox combo)
        {
            const string cacheKey = "stadiums";
            if (_cacheData.ContainsKey(cacheKey))
            {
                combo.Items.Clear();
                combo.Items.AddRange(_cacheData[cacheKey].ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
                return;
            }
            
            try
            {
                var list = new List<string>();
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT sandau FROM trandau ORDER BY sandau";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader.GetString(0));
                    }
                }
                _cacheData[cacheKey] = list;
                combo.Items.Clear();
                combo.Items.AddRange(list.ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadReferees(ComboBox combo)
        {
            const string cacheKey = "referees";
            if (_cacheData.ContainsKey(cacheKey))
            {
                combo.Items.Clear();
                combo.Items.AddRange(_cacheData[cacheKey].ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
                return;
            }
            
            try
            {
                var list = new List<string>();
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT trongtai FROM trandau ORDER BY trongtai";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader.GetString(0));
                    }
                }
                _cacheData[cacheKey] = list;
                combo.Items.Clear();
                combo.Items.AddRange(list.ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadTeams(ComboBox combo)
        {
            const string cacheKey = "teams";
            if (_cacheData.ContainsKey(cacheKey))
            {
                combo.Items.Clear();
                combo.Items.AddRange(_cacheData[cacheKey].ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
                return;
            }
            
            try
            {
                var list = new List<string>();
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT tendb FROM doibong ORDER BY tendb";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader.GetString(0));
                    }
                }
                _cacheData[cacheKey] = list;
                combo.Items.Clear();
                combo.Items.AddRange(list.ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO cauthu(mact, hoten, madb)
SELECT @mact, @hoten, db.madb FROM doibong db WHERE db.tendb = @tendb";
                    cmd.Parameters.AddWithValue("@mact", (txtMaCT.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@hoten", (txtHoTen.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@tendb", (cboTeam.SelectedItem ?? string.Empty).ToString());
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Đã thêm" : "Không tìm thấy đội");
                }
          
                _cacheData.Remove("players");
                RefreshPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE cauthu SET hoten=@hoten, madb = (SELECT madb FROM doibong WHERE tendb=@tendb)
WHERE mact=@mact";
                    cmd.Parameters.AddWithValue("@mact", (txtMaCT.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@hoten", (txtHoTen.Text ?? string.Empty).Trim());
                    cmd.Parameters.AddWithValue("@tendb", (cboTeam.SelectedItem ?? string.Empty).ToString());
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Đã cập nhật" : "Không tìm thấy cầu thủ");
                }
                // Xóa cache để load lại
                _cacheData.Remove("players");
                RefreshPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa cầu thủ này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
                
            try
            {
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM thamgia WHERE mact=@mact; DELETE FROM cauthu WHERE mact=@mact";
                    cmd.Parameters.AddWithValue("@mact", (txtMaCT.Text ?? string.Empty).Trim());
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Đã xóa" : "Không tìm thấy cầu thủ");
                }
                // Xóa cache để load lại
                _cacheData.Remove("players");
                RefreshPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void RefreshPlayers()
        {
            try
            {
                dgvPlayers.SuspendLayout();
                dgvPlayers.DataSource = null;
                Application.DoEvents();
                
                using (var conn = new SqlConnection(DBUtils.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT mact, hoten, madb FROM cauthu ORDER BY mact";
                        cmd.CommandTimeout = 10;
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                            dgvPlayers.DataSource = dt;
                            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
                dgvPlayers.ResumeLayout();
                // Xóa cache để load lại dữ liệu mới
                _cacheData.Remove("players");
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPlayers();
            MessageBox.Show("Đã tải lại dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPlayers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlayers.SelectedRows.Count > 0)
            {
                var row = dgvPlayers.SelectedRows[0];
                txtMaCT.Text = row.Cells["mact"].Value?.ToString() ?? string.Empty;
                txtHoTen.Text = row.Cells["hoten"].Value?.ToString() ?? string.Empty;
                string madb = row.Cells["madb"].Value?.ToString() ?? string.Empty;
                // Tìm tên đội từ mã đội
                try
                {
                    using (var conn = new SqlConnection(DBUtils.ConnectionString))
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT tendb FROM doibong WHERE madb = @madb";
                        cmd.Parameters.AddWithValue("@madb", madb);
                        conn.Open();
                        var tendb = cmd.ExecuteScalar()?.ToString();
                        if (!string.IsNullOrEmpty(tendb))
                        {
                            int idx = cboTeam.FindStringExact(tendb);
                            if (idx >= 0) cboTeam.SelectedIndex = idx;
                        }
                    }
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            using (var login = new FormLogin())
            {
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(DBUtils.ConnectionString))
                {
                   Form1 newform = new Form1();
                    newform.ShowDialog();
                    this.Close();
                }
            }
        }

        // removed legacy handlers (load/update/transfer) in favor of 10 query UI
    }
}

