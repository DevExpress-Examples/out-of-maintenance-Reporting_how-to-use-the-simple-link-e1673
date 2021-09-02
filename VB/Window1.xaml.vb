#Region "#Reference"
Imports System
Imports System.Globalization
Imports System.Windows
Imports DevExpress.Xpf.Printing
' ...
#End Region ' #Reference

Namespace UseCollectionViewLink

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

#Region "#SimpleLink"
Private data() As String

Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
	' Create an array of strings.
	data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

	' Create a link and specify a template and detail count for it.
	Dim link As New SimpleLink()
	link.DetailTemplate = DirectCast(Resources("dayNameTemplate"), DataTemplate)
	link.DetailCount = data.Length

	' Create a document.
	AddHandler link.CreateDetail, AddressOf link_CreateDetail

	' Show a Print Preview window.
	PrintHelper.ShowPrintPreviewDialog(Me, link)
End Sub

Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
	e.Data = data(e.DetailIndex)
End Sub
#End Region ' #SimpleLink
	End Class

End Namespace
