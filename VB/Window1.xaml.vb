Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Data
Imports DevExpress.Xpf.Printing

Namespace UseCollectionViewLink

    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#SimpleLink"
        Private data() As String

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Create an array of strings.
            data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

            ' Create a link and specify a template and detail count for it.
            Dim link As New SimpleLink()
            link.DetailTemplate = DirectCast(Resources("dayNameTemplate"), DataTemplate)
            link.DetailCount = data.Length

            ' Bind the link to the PrintPreview instance.
            preview.Model = New LinkPreviewModel(link)

            ' Create a document.
            AddHandler link.CreateDetail, AddressOf link_CreateDetail
            link.CreateDocument(True)
        End Sub

        Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
            e.Data = data(e.DetailIndex)
        End Sub
        #End Region ' #SimpleLink

    End Class

End Namespace
