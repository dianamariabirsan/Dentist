using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dentist.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramariPage : ContentPage
    {
        public ProgramariPage()
        {
            InitializeComponent();
        }

        async private void OnItemTapped(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ProgramariModify(null)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var context = new Services.Context())
            {
                blobCollectionView.ItemsSource = context.Programari.ToList();
            }
        }

        async void Adauga_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ProgramariAdd()));
        }

        async void Modifica_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null)
                await Navigation.PushModalAsync(new NavigationPage(new ProgramariModify((Programare)blobCollectionView.SelectedItem)));
        }

        async void Sterge_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null)
            {
                using (var context = new Services.Context())
                {
                    context.Remove((Programare)blobCollectionView.SelectedItem);

                    await context.SaveChangesAsync();

                    blobCollectionView.ItemsSource = context.Programari.ToList();
                }
            }
        }

        async void DeleteAll_Clicked(object sender, EventArgs e)
        {
            using (var context = new Services.Context())
            {
                context.RemoveRange(context.Programari);

                await context.SaveChangesAsync();

                blobCollectionView.ItemsSource = context.Programari.ToList();
            }
        }
    }

}