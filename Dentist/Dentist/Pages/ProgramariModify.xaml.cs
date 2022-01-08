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
    public partial class ProgramariModify : ContentPage
    {
        public int CabinetId;
        
        public int ClientId;

        private Programare programare;

        public ProgramariModify(Programare obj)
        {
            InitializeComponent();
            this.programare = obj;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var context = new Services.Context())
            {
                this.PickerCabinet.ItemsSource = context.Cabinete.ToList();
                this.PickerClient.ItemsSource = context.Clienti.ToList();

                this.PickerCabinet.SelectedItem = context.Cabinete.Where(c =>  c.CabinetId == this.programare.CabinetId).FirstOrDefault();
                this.PickerClient.SelectedItem = context.Clienti.Where(c => c.ClientId == this.programare.ClientId).FirstOrDefault();
                txtData.Text = this.programare.Data;
            }
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            this.programare.CabinetId = ((Cabinet)this.PickerCabinet.SelectedItem).CabinetId;
            this.programare.ClientId = ((Client)this.PickerClient.SelectedItem).ClientId;
            this.programare.Data = txtData.Text;

            using (var context = new Services.Context())
            {
                context.Update(this.programare);

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