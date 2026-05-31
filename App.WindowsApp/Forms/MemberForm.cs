using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class MemberForm : Form
    {
        private readonly MemberFormModeEnum _mode;
        private readonly IMemberService _service;
        private Member? _member;

        public Member? Member { get; private set; }

        public MemberForm() : this(MemberFormModeEnum.Add, null, new MemberService())
        {
        }

        public MemberForm(MemberFormModeEnum mode, Member? member, IMemberService service)
        {
            InitializeComponent();

            _mode = mode;
            _member = member;
            _service = service;

            LoadInitialData();
            ApplyMode();
        }

        private void LoadInitialData()
        {
            if (_member != null)
            {
                LoadMember(_member);
                return;
            }

            if (_mode == MemberFormModeEnum.Add)
            {
                textBoxMemberId.Text = new Member().Id;
            }
        }

        private void LoadMember(Member member)
        {
            Member = member;
            textBoxMemberId.Text = member.Id;
            textBoxTitle.Text = member.Name;
            textBoxAuthor.Text = member.Email;
            textBoxPhone.Text = member.Phone;
            textBoxAddress.Text = member.Address;
        }

        private void ApplyMode()
        {
            bool isViewMode = _mode == MemberFormModeEnum.View;

            labelMemberDetails.Text = _mode switch
            {
                MemberFormModeEnum.Add => "Add Member",
                MemberFormModeEnum.Edit => "Edit Member",
                MemberFormModeEnum.View => "View Member",
                _ => "Member Details"
            };

            textBoxTitle.ReadOnly = isViewMode;
            textBoxAuthor.ReadOnly = isViewMode;
            textBoxPhone.ReadOnly = isViewMode;
            textBoxAddress.ReadOnly = isViewMode;
            buttonSave.Visible = !isViewMode;
            buttonSave.Text = _mode == MemberFormModeEnum.Edit ? "Update" : "Save";
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_mode == MemberFormModeEnum.View)
            {
                Close();
                return;
            }

            if (!ValidateForm())
            {
                return;
            }

            SaveMember();
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm()
        {
            if (!string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                return true;
            }

            MessageBox.Show("Please enter member name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void SaveMember()
        {
            if (_mode == MemberFormModeEnum.Add)
            {
                Member newMember = ReadMemberFromForm(new Member());
                _service.AddMember(newMember);
                Member = newMember;
                return;
            }

            if (_mode == MemberFormModeEnum.Edit && _member != null)
            {
                Member = ReadMemberFromForm(_member);
                _service.UpdateMember(_member);
            }
        }

        private Member ReadMemberFromForm(Member member)
        {
            member.Id = string.IsNullOrWhiteSpace(textBoxMemberId.Text)
                ? member.Id
                : textBoxMemberId.Text.Trim();
            member.Name = textBoxTitle.Text.Trim();
            member.Email = textBoxAuthor.Text.Trim();
            member.Phone = textBoxPhone.Text.Trim();
            member.Address = textBoxAddress.Text.Trim();

            return member;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
