using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GAV
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();

            appWindow.Title = "GAV - User Interface";

            navItem_Databases.IsEnabled = false;
            navItem_Account.IsEnabled = true;

            if (accountPage == null)
            {
                accountPage = new GAV.GavRes.winuiAssets.Pages.AccountPage();
            }
            if (contentFrame == null && contentFrame.Content == null)
            {
                contentFrame = new Frame();
                contentFrame.Content = accountPage;
            }

            using (GAV.GavRes.DataAccess.Context.GavContext context = new GavRes.DataAccess.Context.GavContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public GAV.GavRes.winuiAssets.Pages.DataBase pageDatabase;
        GAV.GavRes.winuiAssets.Pages.AccountPage accountPage;

        public void Nav_DB(NavigationView sender, NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItemContainer.Tag.ToString() == "pet" || e.SelectedItemContainer.Tag.ToString() == "vet" || e.SelectedItemContainer.Tag.ToString() == "client"
                || e.SelectedItemContainer.Tag.ToString() == "user")
            {

                if (pageDatabase != null)
                {
                    pageDatabase.currentTag = e.SelectedItemContainer.Tag.ToString();
                }

                if (pageDatabase != null && pageDatabase.currentTag != null)
                {
                    contentFrame.Content = pageDatabase;
                    pageDatabase.TopDataGridViewUpdated(pageDatabase.currentTag);
                    pageDatabase.Filters_ComboBox();
                }
            }
            else if (e.SelectedItemContainer.Tag.ToString() == "account")
            {
                if (accountPage == null)
                {
                    accountPage = new GAV.GavRes.winuiAssets.Pages.AccountPage();
                }
                contentFrame.Content = accountPage;
            }

            GC.Collect();
        }

        private void appWindow_Closed(object sender, WindowEventArgs args)
        {
            if (pageDatabase != null)
            {
                pageDatabase.gavContext.Dispose();
            }
        }
    }
}
