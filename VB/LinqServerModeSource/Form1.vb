' Developer Express Code Central Example:
' How to implement CRUD operations using XtraGrid and LinqServeModeSource
' 
' This example demonstrates how to implement create, update and delete operations
' using XtraGrid and LinqServeModeSource.
' This example works with the standard
' SQL Northwind database.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4498

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports System.Data.Linq
Imports System.Linq
Imports DevExpress.Data.Linq
Namespace LinqServerModeSource
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			linqServerModeSource1.QueryableSource = nwdContext.Customers
			gridControl.DataSource = linqServerModeSource1

		End Sub
		Private nwdContext As New NorthwindDataContext()
		Private customerToEdit As Customer
		Private f1 As EditForm
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			customerToEdit = CreateCustomer()
			EditCustomer(customerToEdit, "NewCustomer", AddressOf CloseNewCustomerHandler)
		End Sub
		Private Function CreateCustomer() As Customer
			Dim idString As String
			Dim newCustomer = New Customer()
			Do
				idString = GenerateCustomerID()
				If (Not String.IsNullOrEmpty(idString)) Then
					newCustomer.CustomerID = idString
					Exit Do
				End If
			Loop
			Return newCustomer
		End Function

		Private Function GenerateCustomerID() As String
			Const IDLength As Integer = 5
			Dim result = String.Empty
			Dim rnd = New Random()
			Dim collisionFlag As Boolean = False
			For i = 0 To IDLength - 1
				result += Convert.ToChar(rnd.Next(65, 90))
			Next i
			For i As Integer = 0 To gridView1.DataRowCount - 1
				If result Is gridView1.GetRowCellValue(i, gridView1.Columns("CustomerID")).ToString() Then
					collisionFlag = True
					Exit For
				End If
			Next i
			If collisionFlag Then
				Return String.Empty
			Else
				Return result
			End If
		End Function
		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			Dim keyString As String = GetCustomerIDByRowHandle(gridView1.FocusedRowHandle)
            Dim query = From Customer In
                        nwdContext.Customers
                        Where
                        Customer.CustomerID = keyString
                        Select
                        Customer
			customerToEdit = query.ToList()(0)
			EditCustomer(customerToEdit, "EditInfo", AddressOf CloseEditCustomerHandler)
		End Sub
		Private Sub EditCustomer(ByVal customer As Customer, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			f1 = New EditForm(customer) With {.Text = windowTitle}
			AddHandler f1.FormClosing, closedDelegate
			f1.ShowDialog()
		End Sub
		Private Function GetCustomerIDByRowHandle(ByVal rowHandle As Integer) As String
			Return CStr(gridView1.GetRowCellValue(rowHandle, "CustomerID"))
		End Function
		Private Sub CloseEditCustomerHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				Try
					nwdContext.SubmitChanges()
					nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers)
					gridView1.RefreshRow(gridView1.FocusedRowHandle)
				Catch ex As Exception
					HandleExcepton(ex)
				End Try
			End If
			customerToEdit = Nothing
		End Sub
		Private Sub CloseNewCustomerHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)

			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				Try
					nwdContext.Customers.InsertOnSubmit(customerToEdit)
					nwdContext.SubmitChanges()
					gridControl.BeginInvoke(New MethodInvoker(Function() AnonymousMethod1()))
				Catch ex As Exception
					HandleExcepton(ex)
				End Try
				linqServerModeSource1.Reload()
				For i As Integer = 0 To gridView1.DataRowCount - 1
					If customerToEdit.CustomerID = gridView1.GetRowCellValue(i, gridView1.Columns("CustomerID")).ToString() Then
						gridView1.FocusedRowHandle = i
						Exit For
					End If
				Next i
			End If
			customerToEdit = Nothing
		End Sub
		
		Private Function AnonymousMethod1() As Boolean
			nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers)
			gridView1.LayoutChanged()
			Return True
		End Function
		Private Sub HandleExcepton(ByVal ex As Exception)
			MessageBox.Show(ex.Message)
		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
			DeleteCustomer(gridView1.FocusedRowHandle)

		End Sub
		Private Sub DeleteCustomer(ByVal focusedRowHandle As Integer)
			If focusedRowHandle < 0 Then
				Return
			End If
			If MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButtons.OKCancel) <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If
			Dim keyString As String = GetCustomerIDByRowHandle(focusedRowHandle)
            Dim query = From Customer In
                    nwdContext.Customers
                    Where
                    Customer.CustomerID = keyString
                    Select
                    Customer
			nwdContext.Customers.DeleteOnSubmit(query.ToList()(0))
			Try
				nwdContext.SubmitChanges()
				nwdContext.Refresh(RefreshMode.OverwriteCurrentValues, nwdContext.Customers)
			Catch ex As Exception
				HandleExcepton(ex)
                End Try
			linqServerModeSource1.Reload()
			gridView1.FocusedRowHandle = focusedRowHandle
			customerToEdit = Nothing
        End Sub

	End Class
End Namespace