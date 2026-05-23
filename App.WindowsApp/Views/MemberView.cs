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
        private IMemberService service;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public MemberView() : this(new MemberService())
        {
        }

        public MemberView(IMemberService _service)
        {
            service = _service;
            InitializeComponent();
            ConfigureGridBinding();
            ApplyStyles();
            RefreshGrid();
        }

        private void ConfigureGridBinding()
        {
            dataGridViewMembers.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(Member.Id);
            MemberName.DataPropertyName = nameof(Member.Name);
            Phone.DataPropertyName = nameof(Member.Phone);
            Email.DataPropertyName = nameof(Member.Email);
            Address.DataPropertyName = nameof(Member.Address);
            dataGridViewMembers.DataSource = _dgvBindingSource;
        }

        private void ApplyStyles()
        {
            Color accentColor = Color.SeaGreen;

            BackColor = Color.White;
            panelFilters.BackColor = Color.Honeydew;
            panelFilters.Padding = new Padding(8);

            toolStripMembers.BackColor = Color.WhiteSmoke;
            toolStripMembers.GripStyle = ToolStripGripStyle.Hidden;
            toolStripMembers.Padding = new Padding(6, 4, 6, 4);
            toolStripMembers.RenderMode = ToolStripRenderMode.System;

            foreach (ToolStripItem item in toolStripMembers.Items)
            {
                item.Margin = new Padding(2, 0, 2, 0);
                item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }

            dataGridViewMembers.BackgroundColor = Color.White;
            dataGridViewMembers.BorderStyle = BorderStyle.None;
            dataGridViewMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewMembers.GridColor = Color.Gainsboro;
            dataGridViewMembers.EnableHeadersVisualStyles = false;
            dataGridViewMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.BackColor = accentColor;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.SelectionBackColor = accentColor;
            dataGridViewMembers.ColumnHeadersHeight = 34;
            dataGridViewMembers.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dataGridViewMembers.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(accentColor, 0.65F);
            dataGridViewMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 250, 240);
            dataGridViewMembers.RowTemplate.Height = 28;
        }

        private void RefreshGrid()
        {
            try
            {
                IEnumerable<Member> members = service.GetAllMembers();
                string keyword = textBoxSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    members = members.Where(member =>
                        member.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        member.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                _dgvBindingSource.DataSource = members.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load members", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Member? GetSelectedMember()
        {
            return _dgvBindingSource.Current as Member;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using MemberForm form = new MemberForm(MemberFormModeEnum.Add, null, service);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            Member? selectedMember = GetSelectedMember();
            if (selectedMember == null)
            {
                MessageBox.Show("Please select a member to edit.", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using MemberForm form = new MemberForm(MemberFormModeEnum.Edit, selectedMember, service);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            Member? selectedMember = GetSelectedMember();
            if (selectedMember == null)
            {
                MessageBox.Show("Please select a member to view.", "View Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using MemberForm form = new MemberForm(MemberFormModeEnum.View, selectedMember, service);
            form.ShowDialog();
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
