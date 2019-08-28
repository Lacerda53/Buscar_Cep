using BuscarCep.Models;
using BuscarCep.Services;
using Plugin.Connectivity;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CEPPage : ContentPage, INotifyPropertyChanged
    {
        public CEPPage()
        {
            InitializeComponent();
            IsLoading = false;
            IsDisabled = true;
            BindingContext = this;
        }

        private async void BuscarViaCEP(object sender, EventArgs args)
        {
            aparece();
            await Task.Delay(1000);
            if (CEP.Text.Length != 9)
            {
                some();
                await DisplayAlert("ERRO", "CEP Inválido", "OK");
            }
            else
            {
                if (CrossConnectivity.Current.IsConnected)
                {

                    Endereco end = ViaCepService.BuscarEnderecoViaCEP(CEP.Text);
                    Resultado.Text = $"Endereço: {end.Localidade}-{end.Uf} \n" +
                                    (string.IsNullOrWhiteSpace(end.Logradouro) ? "" : $"Rua: {end.Logradouro}\n") +
                                    (string.IsNullOrWhiteSpace(end.Bairro) ? "" : $"Bairro: {end.Bairro}\n");
                }
                else
                {
                    await DisplayAlert("ERRO", "Sem internet, verifique sua conexão e tente novamente", "OK");
                }
            }
            some();
        }
        public async void aparece()
        {
            IsLoading = true;
            IsDisabled = false;
        }
        public async void some()
        {
            IsLoading = false;
            IsDisabled = true;
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        private bool isDisabled;
        public bool IsDisabled
        {
            get
            {
                return this.isDisabled;
            }
            set
            {
                this.isDisabled = value;
                RaisePropertyChanged("IsDisabled");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
