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

    Friend Class Person

        Private firstNameField As String

        Private secondNameField As String

        Private commentsField As String

        Public Sub New(ByVal firstName As String, ByVal secondName As String)
            firstNameField = firstName
            secondNameField = secondName
            commentsField = String.Empty
        End Sub

        Public Sub New(ByVal firstName As String, ByVal secondName As String, ByVal comments As String)
            Me.New(firstName, secondName)
            commentsField = comments
        End Sub

        Public Property FirstName As String
            Get
                Return firstNameField
            End Get

            Set(ByVal value As String)
                firstNameField = value
            End Set
        End Property

        Public Property SecondName As String
            Get
                Return secondNameField
            End Get

            Set(ByVal value As String)
                secondNameField = value
            End Set
        End Property

        Public Property Comments As String
            Get
                Return commentsField
            End Get

            Set(ByVal value As String)
                commentsField = value
            End Set
        End Property
    End Class
End Namespace
