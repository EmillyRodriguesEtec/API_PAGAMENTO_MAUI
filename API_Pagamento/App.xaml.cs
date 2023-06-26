using API_Pagamento.Views.Pagamento;

namespace API_Pagamento;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Views.Pagamento.ListagemView();
	}
}
