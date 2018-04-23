// Developer Express Code Central Example:
// How to implement CRUD operations using XtraGrid and LinqServeModeSource
// 
// This example demonstrates how to implement create, update and delete operations
// using XtraGrid and LinqServeModeSource.
// This example works with the standard
// SQL Northwind database.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4498

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using DevExpress.Data.Linq;
namespace LinqServerModeSource
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = nwdContext.Customers;
            gridControl.DataSource = linqServerModeSource1;
            
        }
        NorthwindDataContext nwdContext = new NorthwindDataContext();     
        Customer customerToEdit;        
        EditForm f1;
        private void button1_Click(object sender, EventArgs e)
        {
            customerToEdit = CreateCustomer();
            EditCustomer(customerToEdit, "NewCustomer", CloseNewCustomerHandler);
        }
        private Customer CreateCustomer()
        {
            string idString;
            var newCustomer = new Customer();
            while (true)
            {
                idString = GenerateCustomerID();
                if (!String.IsNullOrEmpty(idString))
                {
                    newCustomer.CustomerID = idString;
                    break;
                }
            }             
            return newCustomer;
        }

        private string GenerateCustomerID()
        {
            const int IDLength = 5;
            var result = String.Empty;
            var rnd = new Random();
            bool collisionFlag = false;
            for (var i = 0; i < IDLength; i++)
            {
                result += Convert.ToChar(rnd.Next(65, 90));
            }
            for (int i = 0; i <gridView1.DataRowCount; i++)
            {
                if (result == gridView1.GetRowCellValue(i, gridView1.Columns["CustomerID"]).ToString())
                {
                    collisionFlag = true;
                    break;
                }
            }
            if (collisionFlag)
            {
                return String.Empty;
            }               
            else
                return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var query = nwdContext.Customers.Where<Customer>(customer => customer.CustomerID == GetCustomerIDByRowHandle(gridView1.FocusedRowHandle));
            customerToEdit = query.ToList()[0];           
            EditCustomer(customerToEdit, "EditInfo", CloseEditCustomerHandler);            
        }
        private void EditCustomer(Customer customer, string windowTitle, FormClosingEventHandler closedDelegate)
        {
            f1 = new EditForm(customer) { Text = windowTitle };
            f1.FormClosing += closedDelegate;
            f1.ShowDialog();
        }
        private string GetCustomerIDByRowHandle(int rowHandle)
        {
            return (string)gridView1.GetRowCellValue(rowHandle, "CustomerID");
        }
        private void CloseEditCustomerHandler(object sender, EventArgs e)
        {
            if (((EditForm)sender).DialogResult == DialogResult.OK)
            {
                try
                {                   
                    nwdContext.SubmitChanges();
                    nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers);
                    gridView1.RefreshRow(gridView1.FocusedRowHandle);
                }
                catch (Exception ex)
                {
                    HandleExcepton(ex);
                }
            }
            customerToEdit = null;
        }
        private void CloseNewCustomerHandler(object sender, FormClosingEventArgs e)
        {

            if (((EditForm)sender).DialogResult == DialogResult.OK)
            {
                try
                {
                    nwdContext.Customers.InsertOnSubmit(customerToEdit);
                    nwdContext.SubmitChanges();
                    gridControl.BeginInvoke(new MethodInvoker(delegate
                    {
                        nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers);
                        gridView1.LayoutChanged();
                    }));           
                }
                catch (Exception ex)
                {
                    HandleExcepton(ex);
                }
                linqServerModeSource1.Reload();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (customerToEdit.CustomerID == gridView1.GetRowCellValue(i, gridView1.Columns["CustomerID"]).ToString())
                    {
                        gridView1.FocusedRowHandle = i;
                        break;
                    }
                }
            }
            customerToEdit = null;          
        }
        private void HandleExcepton(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer(gridView1.FocusedRowHandle);

        }        
        private void DeleteCustomer(int focusedRowHandle)
        {
            if (focusedRowHandle < 0)
                return;
            if (MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            var query = nwdContext.Customers.Where<Customer>(customer => customer.CustomerID == GetCustomerIDByRowHandle(focusedRowHandle));
            nwdContext.Customers.DeleteOnSubmit(query.ToList()[0]);
            try
            {
                nwdContext.SubmitChanges();
                nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers);              
            }
            catch (Exception ex)
            {
                HandleExcepton(ex);                 
            }
            linqServerModeSource1.Reload();
            gridView1.FocusedRowHandle = focusedRowHandle;
            customerToEdit = null;
        }
      
    }
}