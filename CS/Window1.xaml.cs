using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Printing;

namespace UseCollectionViewLink {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        #region #SimpleLink
        string[] data;

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Create an array of strings.
            data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            // Create a link and specify a template and detail count for it.
            SimpleLink link = new SimpleLink();
            link.Detail = (DataTemplate)Resources["dayNameTemplate"];
            link.DetailCount = data.Length;

            // Bind the link to the PrintPreview instance.
            preview.Model = new LinkPreviewModel(link);

            // Create a document.
            link.CreateDetail += new EventHandler<CreateAreaEventArgs>(link_CreateDetail);
            link.CreateDocument(true);
        }

        void link_CreateDetail(object sender, CreateAreaEventArgs e) {
            e.Data = data[e.DetailIndex];
        }
        #endregion #SimpleLink

    }

}
