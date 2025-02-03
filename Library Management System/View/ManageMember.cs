using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class ManageMember : Form
    {
        MemberManager memberControl = new MemberManager();

        public ManageMember()
        {
            InitializeComponent();
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadMembers();
        }

        private void LoadMembers()
        {
            List<Member> members = memberControl.GetAllMembers();
            dgvMembers.DataSource = members;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.ClearSelection();
        }

        private void ClearTextFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtPassword.Clear();
        }
        private void ManageMember_Load(object sender, EventArgs e)
        {

        }

        

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mainform = new Menu();
            mainform.Show();


            // Hide the ManageBooks form
            this.Hide();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
           string.IsNullOrWhiteSpace(txtAddress.Text) ||
           string.IsNullOrWhiteSpace(txtContact.Text) ||
           string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields (Name, Address, Telephone, Password).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Member member = new Member(0, txtName.Text, txtAddress.Text, txtContact.Text, txtPassword.Text);
            memberControl.AddMember(member);

            LoadMembers();
            ClearTextFields();
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvMembers.SelectedRows.Count > 0)
            {
                // Get the selected member from the DataGridView
                  Member selectedMember = (Member)dgvMembers.SelectedRows[0].DataBoundItem;

                // Ensure that all textboxes are filled with updated data
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtContact.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields (Name, Address, Telephone, Password).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if any field is empty
                }

                // Update the member's data
                selectedMember.Name = txtName.Text;
                selectedMember.Address = txtAddress.Text;
                selectedMember.Telephone = txtContact.Text;
                selectedMember.Password = txtPassword.Text;

                // Call the method to update the database
                memberControl.UpdateMember(selectedMember);

                // Refresh the DataGridView to show the updated data
                LoadMembers();

                // Clear textboxes after updating
                ClearTextFields();
            }
            else
            {
                MessageBox.Show("Please select a member to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

             
               
        

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                Member selectedMember = (Member)dgvMembers.SelectedRows[0].DataBoundItem;
                memberControl.DeleteMember(selectedMember.Id);

                LoadMembers();
                ClearTextFields();
            }
            else
            {
                MessageBox.Show("Please select a member to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a row is selected
            if (dgvMembers.SelectedRows.Count > 0)
            {
                // Get the selected member from the DataGridView
                Member selectedMember = (Member)dgvMembers.SelectedRows[0].DataBoundItem;

                // Populate textboxes with the selected member's details
                txtName.Text = selectedMember.Name;
                txtAddress.Text = selectedMember.Address;
                txtContact.Text = selectedMember.Telephone;
                txtPassword.Text = selectedMember.Password;
            }
        }
    }
    
}


