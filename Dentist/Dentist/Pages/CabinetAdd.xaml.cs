using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dentist.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CabinetAdd : ContentPage
    {
        public CabinetAdd()
        {
            InitializeComponent();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            var cabinet = new Cabinet { Nume = txtNume.Text, Adresa = txtAdresa.Text };

            using (var context = new Services.Context())
            {
                context.Add(cabinet);

                await context.SaveChangesAsync();
            }

            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}