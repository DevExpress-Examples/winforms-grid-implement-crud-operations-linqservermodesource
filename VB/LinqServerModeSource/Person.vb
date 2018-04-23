Imports Microsoft.VisualBasic
Imports System

Namespace LinqServerModeSource
	Friend Class Person
		Private firstName_Renamed As String
		Private secondName_Renamed As String
		Private comments_Renamed As String
		Public Sub New(ByVal firstName As String, ByVal secondName As String)
			Me.firstName_Renamed = firstName
			Me.secondName_Renamed = secondName
			comments_Renamed = String.Empty
		End Sub
		Public Sub New(ByVal firstName As String, ByVal secondName As String, ByVal comments As String)
			Me.New(firstName, secondName)
			Me.comments_Renamed = comments
		End Sub
		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				firstName_Renamed = value
			End Set
		End Property
		Public Property SecondName() As String
			Get
				Return secondName_Renamed
			End Get
			Set(ByVal value As String)
				secondName_Renamed = value
			End Set
		End Property
		Public Property Comments() As String
			Get
				Return comments_Renamed
			End Get
			Set(ByVal value As String)
				comments_Renamed = value
			End Set
		End Property
	End Class
End Namespace