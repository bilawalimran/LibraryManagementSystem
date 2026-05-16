using App.Core.Models;
using App.WindowsApp.Forms;
using LibraryManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class MemberView : UserControl
    {
        private readonly MemberService memberService = new MemberService();

        public MemberView()
        {
            InitializeComponent();
            LoadMembers();
        }

        private void LoadMembers()
        {
            try
            {
                IEnumerable<Member> members = memberService.GetAllMembers();
                string keyword = textBoxSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    members = members.Where(member =>
                        member.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                dataGridViewMembers.Rows.Clear();

                foreach (Member member in members)
                {
                    dataGridViewMembers.Rows.Add(
                        member.Id,
                        member.Name,
                        member.Phone,
                        member.Email,
                        member.Address);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load members", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedMemberId()
        {
            if (dataGridViewMembers.CurrentRow == null)
            {
                return null;
            }

            return Convert.ToInt32(dataGridViewMembers.CurrentRow.Cells["Id"].Value);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using MemberForm form = new MemberForm();

            if (form.ShowDialog() == DialogResult.OK && form.Member != null)
            {
                memberService.AddMember(form.Member);
                LoadMembers();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int? memberId = GetSelectedMemberId();

            if (!memberId.HasValue)
            {
                MessageBox.Show("Please select a member to edit.", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Member member = memberService.GetMemberById(memberId.Value);
            using MemberForm form = new MemberForm(member);

            if (form.ShowDialog() == DialogResult.OK && form.Member != null)
            {
                memberService.UpdateMember(form.Member);
                LoadMembers();
            }
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            int? memberId = GetSelectedMemberId();

            if (!memberId.HasValue)
            {
                MessageBox.Show("Please select a member to view.", "View Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Member member = memberService.GetMemberById(memberId.Value);
            using MemberForm form = new MemberForm(member, true);
            form.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int? memberId = GetSelectedMemberId();

            if (!memberId.HasValue)
            {
                MessageBox.Show("Please select a member to delete.", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete the selected member?",
                "Delete Member",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                memberService.DeleteMember(memberId.Value);
                LoadMembers();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMembers();
        }
    }
}
