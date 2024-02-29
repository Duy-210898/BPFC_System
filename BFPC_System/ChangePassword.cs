﻿using BPFC_System;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BPFC_System
{
    public partial class frmChangePassword : XtraForm
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        public frmChangePassword()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Xử lý sự kiện khi nút "Đổi mật khẩu" được nhấn
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string usernameToChangePassword = txtUsername.Text;
            string currentPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Kiểm tra ô nhập liệu có rỗng không
            if (string.IsNullOrWhiteSpace(usernameToChangePassword) ||
                string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin để đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra mật khẩu cũ
            DatabaseManager dbManager = new DatabaseManager(connectionString);
            if (!dbManager.CheckLogin(usernameToChangePassword, dbManager.ComputeHash(currentPassword)))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của mật khẩu mới
            if (!dbManager.IsNewPasswordValid(newPassword))
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện cập nhật mật khẩu mới trong cơ sở dữ liệu
            if (dbManager.ChangePassword(usernameToChangePassword, currentPassword, newPassword))
            {
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trường nhập liệu và cập nhật giao diện nếu cần
                txtUsername.Clear();
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}