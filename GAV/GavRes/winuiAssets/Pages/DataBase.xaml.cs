using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GAV.GavRes.winuiAssets.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataBase : Page
    {

        public GavRes.DataAccess.Context.GavContext gavContext;
        public string currentTag = "client";
        private bool onStart = true;
        private bool searchOptioncontains = true;

        ObservableCollection<GAV.GavRes.DataAccess.Models.Pet> Pets;
        ObservableCollection<GAV.GavRes.DataAccess.Models.Vet> Vets;
        ObservableCollection<GAV.GavRes.DataAccess.Models.Client> Clients;
        ObservableCollection<GAV.GavRes.DataAccess.Models.User> Users;

        public DataBase(string tag)
        {
            currentTag = tag;
            if (onStart)
            {
                this.InitializeComponent();
                Pets = new ObservableCollection<GAV.GavRes.DataAccess.Models.Pet>();
                Vets = new ObservableCollection<GAV.GavRes.DataAccess.Models.Vet>();
                Clients = new ObservableCollection<GAV.GavRes.DataAccess.Models.Client>();
                Users = new ObservableCollection<DataAccess.Models.User>();
                onStart = false;
            }
        }

        private void topDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void topDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (infoBar.IsOpen)
            {
                infoBar.IsOpen = false;
            }
        }

        private void topDataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
        {
        }

        private void topDataGrid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }

        private async void topDataGrid_RowEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            try
            {
                using (gavContext = new DataAccess.Context.GavContext())
                {
                    if (gavContext.Entry(topDataGrid.SelectedItem).GetDatabaseValues() != null)
                    {
                        gavContext.Update(topDataGrid.SelectedItem);
                    }
                    else
                    {
                        gavContext.Add(topDataGrid.SelectedItem);
                    }
                    gavContext.SaveChanges();
                    TopDataGridViewUpdated(currentTag);
                }

                infoBar.Title = "INFO";
                infoBar.HorizontalAlignment = HorizontalAlignment.Left;
                infoBar.VerticalAlignment = VerticalAlignment.Bottom;
                infoBar.IsIconVisible = true;
                infoBar.IsClosable = true;
                infoBar.Message = "Successfuly recorded.";
                infoBar.IsOpen = true;

            }
            catch (Exception)
            {
                ContentDialog contentDialog = new ContentDialog()
                {
                    Title = "Oopss",
                    Content = "Something gone wrong.",
                    CloseButtonText = "Ok",
                    XamlRoot = this.XamlRoot
                };
                await contentDialog.ShowAsync();

                infoBar.Title = "INFO";
                infoBar.HorizontalAlignment = HorizontalAlignment.Left;
                infoBar.VerticalAlignment = VerticalAlignment.Bottom;
                infoBar.IsIconVisible = true;
                infoBar.IsClosable = true;
                infoBar.Message = "Failed to record.";
                infoBar.IsOpen = true;
            }

        }

        private async void RemoveRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (gavContext = new DataAccess.Context.GavContext())
                {
                    gavContext.Remove(topDataGrid.SelectedItem);
                    gavContext.SaveChanges();
                    TopDataGridViewUpdated(currentTag);
                }

                infoBar.Title = "INFO";
                infoBar.HorizontalAlignment = HorizontalAlignment.Left;
                infoBar.VerticalAlignment = VerticalAlignment.Bottom;
                infoBar.IsIconVisible = true;
                infoBar.IsClosable = true;
                infoBar.Message = "Succesfuly removed.";
                infoBar.IsOpen = true;
            }
            catch (Exception)
            {
                ContentDialog contentDialog = new ContentDialog()
                {
                    Title = "Oopss",
                    Content = "Something gone wrong.",
                    CloseButtonText = "Ok",
                    XamlRoot = this.XamlRoot
                };
                await contentDialog.ShowAsync();

                infoBar.Title = "INFO";
                infoBar.HorizontalAlignment = HorizontalAlignment.Left;
                infoBar.VerticalAlignment = VerticalAlignment.Bottom;
                infoBar.IsIconVisible = true;
                infoBar.IsClosable = true;
                infoBar.Message = "Failed to remove.";
                infoBar.IsOpen = true;
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTag)
            {
                case "pet":
                    Pets.Add(new GAV.GavRes.DataAccess.Models.Pet()
                    { RegistrationDate = DateTime.Now });
                    break;
                case "vet":
                    Vets.Add(new GAV.GavRes.DataAccess.Models.Vet()
                    { RegistrationDate = DateTime.Now });
                    break;
                case "client":
                    Clients.Add(new GAV.GavRes.DataAccess.Models.Client()
                    { RegistrationDate = DateTime.Now });
                    break;
                case "user":
                    Users.Add(new GAV.GavRes.DataAccess.Models.User()
                    { RegistrationDate = DateTime.Now });
                    break;
                default:
                    break;
            }
        }

        public void TopDataGridViewUpdated(string tag)
        {
            using (gavContext = new DataAccess.Context.GavContext())
            {
                switch (tag)
                {
                    case "pet":
                        Pets.Clear();
                        foreach (var record in gavContext.Pets)
                        {
                            Pets.Add(record);
                        }

                        topDataGrid.DataContext = Pets;
                        break;
                    case "vet":
                        Vets.Clear();
                        foreach (var record in gavContext.Vets)
                        {
                            Vets.Add(record);
                        }

                        topDataGrid.DataContext = Vets;
                        break;
                    case "client":
                        Clients.Clear();
                        foreach (var record in gavContext.Clients)
                        {
                            Clients.Add(record);
                        }

                        topDataGrid.DataContext = Clients;
                        break;
                    case "user":
                        Users.Clear();
                        foreach (var record in gavContext.Users)
                        {
                            Users.Add(record);
                        }

                        topDataGrid.DataContext = Users;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Filters_ComboBox()
        {
            if (filterComboBox.Items.Count > 0)
            {
                filterComboBox.Items.Clear();
            }



            switch (currentTag)
            {
                case "pet":
                    foreach (var property in gavContext.Pets.EntityType.GetProperties())
                    {
                        filterComboBox.Items.Add(property.Name);
                    };
                    break;
                case "vet":
                    foreach (var property in gavContext.Vets.EntityType.GetProperties())
                    {
                        filterComboBox.Items.Add(property.Name);
                    };
                    break;
                case "client":
                    foreach (var property in gavContext.Clients.EntityType.GetProperties())
                    {
                        filterComboBox.Items.Add(property.Name);
                    };
                    break;
                case "user":
                    foreach (var property in gavContext.Users.EntityType.GetProperties())
                    {
                        filterComboBox.Items.Add(property.Name);
                    };
                    break;
                default:
                    break;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (filterComboBox.SelectedItem != null && SearcBox.Text != string.Empty)
            {
                using (gavContext = new DataAccess.Context.GavContext())
                {
                    Microsoft.EntityFrameworkCore.Metadata.IProperty selectedProperty;

                    switch (currentTag)
                    {
                        case "pet":
                            selectedProperty = gavContext.Pets.EntityType.GetProperties().Where(x => x.Name == filterComboBox.SelectedItem.ToString()).FirstOrDefault();

                            Pets.Clear();

                            foreach (var record in gavContext.Pets)
                            {
                                if (!searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().StartsWith(SearcBox.Text.ToLower())).Any())
                                {
                                    Pets.Add(record);
                                }
                                else if (searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().Contains(SearcBox.Text.ToLower())).Any())
                                {
                                    Pets.Add(record);
                                }
                            }

                            topDataGrid.DataContext = Pets;

                            break;
                        case "vet":
                            selectedProperty = gavContext.Vets.EntityType.GetProperties().Where(x => x.Name == filterComboBox.SelectedItem.ToString()).FirstOrDefault();

                            Vets.Clear();

                            foreach (var record in gavContext.Vets)
                            {
                                if (!searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().StartsWith(SearcBox.Text.ToLower())).Any())
                                {
                                    Vets.Add(record);
                                }
                                else if (searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().Contains(SearcBox.Text.ToLower())).Any())
                                {
                                    Vets.Add(record);
                                }
                            }

                            topDataGrid.DataContext = Vets;

                            break;
                        case "client":
                            selectedProperty = gavContext.Clients.EntityType.GetProperties().Where(x => x.Name == filterComboBox.SelectedItem.ToString()).FirstOrDefault();

                            Clients.Clear();

                            foreach (var record in gavContext.Clients)
                            {
                                if (!searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().StartsWith(SearcBox.Text.ToLower())).Any())
                                {
                                    Clients.Add(record);
                                }
                                else if (searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().Contains(SearcBox.Text.ToLower())).Any())
                                {
                                    Clients.Add(record);
                                }
                            }

                            topDataGrid.DataContext = Clients;

                            break;
                        case "user":
                            selectedProperty = gavContext.Users.EntityType.GetProperties().Where(x => x.Name == filterComboBox.SelectedItem.ToString()).FirstOrDefault();

                            Users.Clear();

                            foreach (var record in gavContext.Users)
                            {
                                if (!searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().StartsWith(SearcBox.Text.ToLower())).Any())
                                {
                                    Users.Add(record);
                                }
                                else if (searchOptioncontains && gavContext.Entry(record).Properties.Where(x => x.Metadata.PropertyInfo.Name.ToLower() == selectedProperty.Name.ToLower() && x.CurrentValue.ToString().ToLower().Contains(SearcBox.Text.ToLower())).Any())
                                {
                                    Users.Add(record);
                                }
                            }

                            topDataGrid.DataContext = Users;

                            break;
                    }
                }
            }

            SearcBox.Text = String.Empty;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchOptioncontains = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            searchOptioncontains = true;
        }
    }
}
