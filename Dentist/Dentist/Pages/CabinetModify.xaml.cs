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
    public partial class CabinetModify : ContentPage
    {
        private Cabinet cabinet;

        public CabinetModify(Cabinet obj)
        {
            InitializeComponent();
            this.cabinet = obj;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            txtNume.Text = this.cabinet.Nume;
            txtAdresa.Text = this.cabinet.Adresa;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            this.cabinet.Nume = txtNume.Text;
            this.cabinet.Adresa = txtAdresa.Text;

            using (var context = new Services.Context())
            {
                context.Update(this.cabinet);

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