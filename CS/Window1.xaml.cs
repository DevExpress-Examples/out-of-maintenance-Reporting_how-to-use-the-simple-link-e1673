using System;
using System.Globalization;
using System.Windows;
using DevExpress.Xpf.Printing;
// ...

namespace UseCollectionViewLink {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

string[] data;

private void button1_Click(object sender, RoutedEventArgs e) {
    // Create an array of strings.
    data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

    // Create a link and specify a template and detail count for it.
    SimpleLink link = new SimpleLink();
    link.DetailTemplate = (DataTemplate)Resources["dayNameTemplate"];
    link.DetailCount = data.Length;

    // Create a document.
    link.CreateDetail += new EventHandler<CreateAreaEventArgs>(link_CreateDetail);
            
    // Show a Print Preview window.
    PrintHelper.ShowPrintPreviewDialog(this, link);
}

void link_CreateDetail(object sender, CreateAreaEventArgs e) {
    e.Data = data[e.DetailIndex];
}
    }

}
