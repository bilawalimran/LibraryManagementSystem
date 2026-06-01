using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;

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

            if (member != null)
            {
                Member = member;
                textBoxMemberId.Text = member.Id;
                textBoxTitle.Text = member.Name;
                textBoxAuthor.Text = member.Email;
                textBoxPhone.Text = member.Phone;
                textBoxAddress.Text = member.Address;
            }
            else if (mode == MemberFormModeEnum.Add)
            {
                textBoxMemberId.Text = new Member().Id;
            }

            bool isViewMode = mode == MemberFormModeEnum.View;

            labelMemberDetails.Text = mode switch
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
            buttonSave.Text = mode == MemberFormModeEnum.Edit ? "Update" : "Save";
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
                Member newMember = new Member();
                newMember.Id = string.IsNullOrWhiteSpace(textBoxMemberId.Text) ? newMember.Id : textBoxMemberId.Text.Trim();
                newMember.Name = textBoxTitle.Text.Trim();
                newMember.Email = textBoxAuthor.Text.Trim();
                newMember.Phone = textBoxPhone.Text.Trim();
                newMember.Address = textBoxAddress.Text.Trim();

                _service.AddMember(newMember);
                Member = newMember;
            }
            else if (_mode == MemberFormModeEnum.Edit && _member != null)
            {
                _member.Id = string.IsNullOrWhiteSpace(textBoxMemberId.Text) ? _member.Id : textBoxMemberId.Text.Trim();
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