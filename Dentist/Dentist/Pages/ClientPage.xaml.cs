using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dentist.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();

        }

        async private void OnItemTapped(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ClientModify(null)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var context = new Services.Context())
            {
                blobCollectionView.ItemsSource = context.Clienti.ToList();
            }
        }

        async void Adauga_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ClientAdd()));
        }

        async void Modifica_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null) 
                await Navigation.PushModalAsync(new NavigationPage(new ClientModify((Client)blobCollectionView.SelectedItem)));
        }

        async void Sterge_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null)
            {
                using (var context = new Services.Context())
                {
                    context.Remove((Client)blobCollectionView.SelectedItem);

                    await context.SaveChangesAsync();

                    blobCollectionView.ItemsSource = context.Clienti.ToList();
                }
            }
        }

        async void DeleteAll_Clicked(object sender, EventArgs e)
        {
            using (var context = new Services.Context())
            {
                context.RemoveRange(context.Clienti);

                await context.SaveChangesAsync();

                blobCollectionView.ItemsSource = context.Clienti.ToList();
            }
        }
    }
}