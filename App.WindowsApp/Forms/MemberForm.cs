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
        private Member? _member;
        private readonly IMemberService _service;

        public Member? Member { get; private set; }

        public MemberForm() : this(MemberFormModeEnum.Add, null, new MemberService())
        {
        }

        public MemberForm(Member? member, MemberFormModeEnum formMode = MemberFormModeEnum.Add)
            : this(formMode, member, new MemberService())
        {
        }

        public MemberForm(MemberFormModeEnum mode, Member? member, IMemberService service)
        {
            InitializeComponent();

            _mode = mode;
            _member = member;
            _service = service;

            if (_mode == MemberFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
            }
            else if (_mode == MemberFormModeEnum.View)
            {
                buttonSave.Visible = false;
            }

            if (_mode == MemberFormModeEnum.Edit || _mode == MemberFormModeEnum.View)
            {
                if (_member != null)
                {
                    LoadMember(_member);
                }
            }
            else
            {
                textBoxMemberId.Text = new Member().Id;
            }

            ApplyMode();
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
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_mode == MemberFormModeEnum.View)
            {
                Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Please enter member name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == MemberFormModeEnum.Add)
            {
                Member newMember = new Member
                {
                    Id = string.IsNullOrWhiteSpace(textBoxMemberId.Text)
                        ? new Member().Id
                        : textBoxMemberId.Text.Trim(),
                    Name = textBoxTitle.Text.Trim(),
                    Email = textBoxAuthor.Text.Trim(),
                    Phone = textBoxPhone.Text.Trim(),
                    Address = textBoxAddress.Text.Trim()
                };

                _service.AddMember(newMember);
                Member = newMember;
            }
            else if (_mode == MemberFormModeEnum.Edit && _member != null)
            {
                _member.Name = textBoxTitle.Text.Trim();
                _member.Email = textBoxAuthor.Text.Trim();
                _member.Phone = textBoxPhone.Text.Trim();
                _member.Address = textBoxAddress.Text.Trim();

                _service.UpdateMember(_member);
                Member = _member;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
