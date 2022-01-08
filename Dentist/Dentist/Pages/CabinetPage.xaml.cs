using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace Dentist.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CabinetPage : ContentPage
    {
        public CabinetPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var context = new Services.Context())
            {
                blobCollectionView.ItemsSource = context.Cabinete.ToList();
            }
        }

        async void Adauga_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CabinetAdd()));
        }

        async void Modifica_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null)
                await Navigation.PushModalAsync(new NavigationPage(new CabinetModify((Cabinet)blobCollectionView.SelectedItem)));
        }

        async void Sterge_Clicked(System.Object sender, System.EventArgs e)
        {
            if (blobCollectionView.SelectedItem != null)
            {
                using (var context = new Services.Context())
                {
                    context.Remove((Cabinet)blobCollectionView.SelectedItem);

                    await context.SaveChangesAsync();

                    blobCollectionView.ItemsSource = context.Cabinete.ToList();
                }
            }
        }

        async void DeleteAll_Clicked(object sender, EventArgs e)
        {
            using (var context = new Services.Context())
            {
                context.RemoveRange(context.Cabinete);

                await context.SaveChangesAsync();

                blobCollectionView.ItemsSource = context.Cabinete.ToList();
            }
        }
    }
}