using BuscarCep.Models;
using BuscarCep.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuscarCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnderecoPage : ContentPage, INotifyPropertyChanged
    {
        public EnderecoPage()
        {
            InitializeComponent();
            IsLoading = false;
            IsDisabled = true;
            BindingContext = this;
        }
        private async void BuscarViaEndereco(object sender, EventArgs args)
        {
            try
            {
                aparece();
                await Task.Delay(1000);
                List<Endereco> end = ViaCepService.BuscarCEPViaEndereco(uf.Text, cidade.Text, logradouro.Text);
                CepList.ItemsSource = end;
                some();
            }
            catch (Exception)
            {
                some();
                await DisplayAlert("ERRO", "Algum campo está inválido, verifique se os campos estão escritos corretamente e tente novamente.", "Ok");
            }
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