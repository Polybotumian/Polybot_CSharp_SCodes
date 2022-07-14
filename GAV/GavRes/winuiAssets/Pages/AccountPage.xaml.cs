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

namespace GAV.GavRes.winuiAssets.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();

            Button_LogOut.IsEnabled = false;

            using (GAV.GavRes.DataAccess.Context.GavContext context = new GavRes.DataAccess.Context.GavContext())
            {
                if (context.Users.Count() < 1)
                {
                    context.Users.Add(new DataAccess.Models.User() { UserName = "admin", Password = "admin", RegistrationDate = DateTime.Now });
                    context.SaveChanges();
                }
            }
        }

        public string currentUserName;
        public string currentPassword;

        private async void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            currentUserName = TextBox_UserName.Text.ToString().Trim();
            currentPassword = PasswordBox.Password.ToString().Trim();

            using (GAV.GavRes.DataAccess.Context.GavContext context = new GavRes.DataAccess.Context.GavContext())
            {
                var window = (MainWindow)(Application.Current as App)?.m_window;

                if (context.Users.Where(x => x.UserName == currentUserName && x.Password == currentPassword).Any())
                {
                    window.navItem_Databases.IsEnabled = true;
                    Button_Login.IsEnabled = false;
                    Button_LogOut.IsEnabled = true;

                    if (window.pageDatabase == null)
                    {
                        window.pageDatabase = new GAV.GavRes.winuiAssets.Pages.DataBase("client");
                        window.pageDatabase.TopDataGridViewUpdated("client");
                        window.pageDatabase.Filters_ComboBox();
                    }
                    window.contentFrame.Content = window.pageDatabase;

                    ContentDialog contentDialog = new ContentDialog()
                    {
                        Title = "Login Success",
                        Content = "You can select any option via navigation menu now.",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot
                    };
                    await contentDialog.ShowAsync();
                }
                else
                {
                    window.navItem_Databases.IsEnabled = false;
                    ContentDialog contentDialog = new ContentDialog()
                    {
                        Title = "Login Failed",
                        Content = "Your user name or password is wrong.",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot
                    };
                    await contentDialog.ShowAsync();
                }
            }
        }

        private async void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            TextBox_UserName.Text = String.Empty;
            PasswordBox.Password = String.Empty;
            currentUserName = TextBox_UserName.Text;
            currentPassword = PasswordBox.Password;
            var window = (MainWindow)(Application.Current as App)?.m_window;
            window.navItem_Databases.IsEnabled = false;
            Button_Login.IsEnabled = true;
            Button_LogOut.IsEnabled = false;
            ContentDialog contentDialog = new ContentDialog()
            {
                Title = "You have logout.",
                Content = "You have no longer access to options.",
                CloseButtonText = "Ok",
                XamlRoot = this.XamlRoot
            };
            await contentDialog.ShowAsync();
        }
    }
}
