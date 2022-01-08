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
    public partial class ClientAdd : ContentPage
    {
        public ClientAdd()
        {
            InitializeComponent();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            var client = new Client { Nume = txtNume.Text, Prenume = txtPrenume.Text, Telefon = txtTelefon.Text };

            using (var context = new Services.Context())
            {
                context.Add(client);

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