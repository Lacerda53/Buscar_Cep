
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuscarCep
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
    {
		public Menu ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new MainPage());
        }


        private void GoPage1(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new CEPPage());
            IsPresented = false;
        }
        private void GoPage2(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new EnderecoPage());
            IsPresented = false;
        }
    }
}