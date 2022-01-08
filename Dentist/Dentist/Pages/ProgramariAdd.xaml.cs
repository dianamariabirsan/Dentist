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
    public partial class ProgramariAdd : ContentPage
    {
        public int CabinetId;
        
        public int ClientId;

        public ProgramariAdd()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var context = new Services.Context())
            {
                this.PickerCabinet.ItemsSource = context.Cabinete.ToList();
                this.PickerClient.ItemsSource = context.Clienti.ToList();
            }
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            var programare = new Programare {
                CabinetId = ((Cabinet)this.PickerCabinet.SelectedItem).CabinetId,
                ClientId = ((Client)this.PickerClient.SelectedItem).ClientId,
                Data = txtData.Text
            };

            using (var context = new Services.Context())
            {
                context.Add(programare);

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