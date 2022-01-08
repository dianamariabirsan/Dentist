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
    public partial class ClientModify : ContentPage
    {
        private Client client;

        public ClientModify(Client obj)
        {
            InitializeComponent();
            this.client = obj;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            txtNume.Text = this.client.Nume;
            txtPrenume.Text = this.client.Prenume;
            txtTelefon.Text = this.client.Telefon;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            this.client.Nume = txtNume.Text;
            this.client.Prenume = txtPrenume.Text;
            this.client.Telefon = txtTelefon.Text;

            using (var context = new Services.Context())
            {
                context.Update(client);

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