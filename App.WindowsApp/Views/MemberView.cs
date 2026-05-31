using App.Core.Interfaces;
using App.Core.Models;
using App.WindowsApp.Forms;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class MemberView : UserControl
    {
        private readonly IMemberService service;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public MemberView() : this(new MemberService())
        {
        }

        public MemberView(IMemberService _service)
        {
            service = _service;
            InitializeComponent();
            RefreshGrid();
            dataGridViewMembers.DataSource = _dgvBindingSource;
        }

        private void RefreshGrid()
        {
            try
            {
                _dgvBindingSource.DataSource = GetFilteredMembers().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load members", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<Member> GetFilteredMembers()
        {
            IEnumerable<Member> members = service.GetAllMembers();
            string keyword = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return members;
            }

            return members.Where(member =>
                member.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                member.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                member.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                member.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        private Member? GetSelectedMember()
        {
            return _dgvBindingSource.Current as Member;
        }

        private void ShowMemberForm(MemberFormModeEnum mode, Member? member = null, bool refreshAfterClose = true)
        {
            using MemberForm form = new MemberForm(mode, member, service);
            form.ShowDialog();

            if (refreshAfterClose)
            {
                RefreshGrid();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            ShowMemberForm(MemberFormModeEnum.Add);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            Member? selectedMember = GetSelectedMember();
            if (selectedMember == null)
            {
                MessageBox.Show("Please select a member to edit.", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowMemberForm(MemberFormModeEnum.Edit, selectedMember);
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            Member? selectedMember = GetSelectedMember();
            if (selectedMember == null)
            {
                MessageBox.Show("Please select a member to view.", "View Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowMemberForm(MemberFormModeEnum.View, selectedMember, refreshAfterClose: false);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            Member? selectedMember = GetSelectedMember();
            if (selectedMember == null)
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
                service.DeleteMember(selectedMember.Id);
                RefreshGrid();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
