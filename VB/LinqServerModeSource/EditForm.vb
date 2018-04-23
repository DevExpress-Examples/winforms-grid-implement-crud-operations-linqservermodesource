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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace LinqServerModeSource
	Partial Public Class EditForm
		Inherits Form
		Public Sub New(ByVal customer As Customer)
			InitializeComponent()
			textEdit1.DataBindings.Add("EditValue", customer, "CompanyName")
			textEdit2.DataBindings.Add("EditValue", customer, "ContactName")
			textEdit3.DataBindings.Add("EditValue", customer, "Address")
			textEdit4.DataBindings.Add("EditValue", customer, "Country")
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			DialogResult = System.Windows.Forms.DialogResult.Cancel
		End Sub

	End Class
End Namespace
