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
Namespace LinqServerModeSource

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.gridControl = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.linqServerModeSource1 = New DevExpress.Data.Linq.LinqServerModeSource()
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.button3 = New System.Windows.Forms.Button()
            CType((Me.gridControl), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.linqServerModeSource1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl
            ' 
            Me.gridControl.Dock = System.Windows.Forms.DockStyle.Top
            Me.gridControl.Location = New System.Drawing.Point(0, 0)
            Me.gridControl.MainView = Me.gridView1
            Me.gridControl.Name = "gridControl"
            Me.gridControl.Size = New System.Drawing.Size(778, 519)
            Me.gridControl.TabIndex = 0
            Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.gridView1.GridControl = Me.gridControl
            Me.gridView1.Name = "gridView1"
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(196, 538)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(75, 23)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Add"
            Me.button1.UseVisualStyleBackColor = True
            AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(324, 538)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(75, 23)
            Me.button2.TabIndex = 2
            Me.button2.Text = "Edit"
            Me.button2.UseVisualStyleBackColor = True
            AddHandler Me.button2.Click, New System.EventHandler(AddressOf Me.button2_Click)
            ' 
            ' button3
            ' 
            Me.button3.Location = New System.Drawing.Point(452, 538)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(75, 23)
            Me.button3.TabIndex = 3
            Me.button3.Text = "Delete"
            Me.button3.UseVisualStyleBackColor = True
            AddHandler Me.button3.Click, New System.EventHandler(AddressOf Me.button3_Click)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(778, 573)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.gridControl)
            Me.LookAndFeel.SkinName = "Foggy"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.gridControl), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.linqServerModeSource1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private gridControl As DevExpress.XtraGrid.GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Private linqServerModeSource1 As DevExpress.Data.Linq.LinqServerModeSource

        Private button1 As System.Windows.Forms.Button

        Private button2 As System.Windows.Forms.Button

        Private button3 As System.Windows.Forms.Button
    End Class
End Namespace
