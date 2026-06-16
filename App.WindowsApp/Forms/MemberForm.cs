using App.Core.Interfaces;
using App.Core.Models;
using System.Text.RegularExpressions;

namespace App.WindowsApp.Forms
{
    public partial class MemberForm : Form
    {
        private MemberFormModeEnum _mode;
        private Member? _member;
        private IMemberService _service;

        public MemberForm(MemberFormModeEnum mode, Member? member, IMemberService service)
        {
            InitializeComponent();

            _mode = mode;
            _member = member;
            _service = service;

            if (mode == MemberFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
                this.Text = "Edit Member";
                labelMemberDetails.Text = "Edit Member";
            }
            else if (mode == MemberFormModeEnum.View)
            {
                buttonSave.Visible = false;
                this.Text = "View Member";
                labelMemberDetails.Text = "View Member";
            }
            else
            {
                this.Text = "Add Member";
                labelMemberDetails.Text = "Add Member";
                labelId.Visible = false;
                textBoxMemberId.Visible = false;
            }

            if (mode == MemberFormModeEnum.Edit || mode == MemberFormModeEnum.View)
            {
                textBoxMemberId.Text = member.Id;
                textBoxName.Text = member.Name;
                textBoxEmail.Text = member.Email;
                textBoxPhone.Text = member.Phone;
                textBoxAddress.Text = member.Address;
            }

            if (mode == MemberFormModeEnum.View)
            {
                textBoxName.ReadOnly = true;
                textBoxEmail.ReadOnly = true;
                textBoxPhone.ReadOnly = true;
                textBoxAddress.ReadOnly = true;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                string email = textBoxEmail.Text.Trim();
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.\nExample: name@example.com",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEmail.Focus();
                    return false;
                }
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                if (_mode == MemberFormModeEnum.Add)
                {
                    Member newMember = new Member();
                    newMember.Name = textBoxName.Text.Trim();
                    newMember.Email = textBoxEmail.Text.Trim();
                    newMember.Phone = textBoxPhone.Text.Trim();
                    newMember.Address = textBoxAddress.Text.Trim();

                    _service.AddMember(newMember);
                    textBoxMemberId.Text = newMember.Id;
                    MessageBox.Show("Member added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == MemberFormModeEnum.Edit && _member != null)
                {
                    _member.Name = textBoxName.Text.Trim();
                    _member.Email = textBoxEmail.Text.Trim();
                    _member.Phone = textBoxPhone.Text.Trim();
                    _member.Address = textBoxAddress.Text.Trim();

                    _service.UpdateMember(_member);
                    MessageBox.Show("Member updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}