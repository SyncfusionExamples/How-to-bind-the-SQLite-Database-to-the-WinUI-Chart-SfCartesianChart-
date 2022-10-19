using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_ChartSqliteSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddChartDataPage : Page
    {
        public AddChartDataPage()
        {
            this.InitializeComponent();
        }

        private void Insert_Clicked(object sender, RoutedEventArgs e)
        {
            // Insert items into table
            var todoItem = (ChartDataModel)DataContext;
            App.Database.SaveChartDataModelAsync(todoItem);
            this.Frame.GoBack();
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            // Delete items into table
            var todoItem = (ChartDataModel)DataContext;
            App.Database.DeleteChartDataModelAsync(todoItem);
            this.Frame.GoBack();
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
