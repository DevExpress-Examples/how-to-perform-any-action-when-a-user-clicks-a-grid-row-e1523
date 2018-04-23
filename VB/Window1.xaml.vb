Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Data

Namespace RowsHitTest

	Partial Public Class Window1
		Inherits Window

		Private list As List(Of TestData)

		Public Sub New()
			InitializeComponent()

'			#Region "Data Binding"
			list = New List(Of TestData)()
			For i As Integer = 0 To 99
				list.Add(New TestData() With {.Text = "row " & i, .Number = i})
			Next i

			grid.ItemsSource = list
'			#End Region

'			#Region "#MouseEvents"
			AddHandler view.MouseDown, AddressOf OnMouseEvent
			AddHandler view.MouseUp, AddressOf OnMouseEvent
			AddHandler view.MouseDoubleClick, AddressOf OnMouseEvent
'			#End Region
		End Sub

		#Region "#MouseEventHandler"
		Private Sub OnMouseEvent(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim rowHandle As Integer = view.GetRowHandleByMouseEventArgs(e)

			If rowHandle <> GridDataController.InvalidRow Then
				eventLog.Text += String.Format("row index: {0}, event: {1}" & Constants.vbCrLf, grid.GetListIndexByRowHandle(rowHandle), e.RoutedEvent.Name)

				eventLog.ScrollToEnd()
			End If
		End Sub
		#End Region
	End Class

	#Region "TestData"
	Public Class TestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class
	#End Region
End Namespace
