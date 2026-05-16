using App.Core.Models;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class MemberForm : Form
    {
        private readonly bool isReadOnly;

        public Member? Member { get; private set; }

        public MemberForm() : this(null, false)
        {
        }

        public MemberForm(Member? member, bool isReadOnly = false)
        {
            InitializeComponent();

            this.isReadOnly = isReadOnly;

            if (member != null)
            {
                LoadMember(member);
            }

            ApplyReadOnlyMode();
        }

        private void LoadMember(Member member)
        {
            Member = member;
            textBoxMemberId.Text = member.Id.ToString();
            textBoxTitle.Text = member.Name;
            textBoxAuthor.Text = member.Email;
            textBoxPhone.Text = member.Phone;
            textBoxAddress.Text = member.Address;
        }

        private void ApplyReadOnlyMode()
        {
            textBoxTitle.ReadOnly = isReadOnly;
            textBoxAuthor.ReadOnly = isReadOnly;
            textBoxPhone.ReadOnly = isReadOnly;
            textBoxAddress.ReadOnly = isReadOnly;
            buttonSave.Visible = !isReadOnly;
            buttonCancel.Text = isReadOnly ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Please enter member name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Member = new Member
            {
                Id = int.TryParse(textBoxMemberId.Text, out int id) ? id : 0,
                Name = textBoxTitle.Text.Trim(),
                Email = textBoxAuthor.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Address = textBoxAddress.Text.Trim()
            };

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
