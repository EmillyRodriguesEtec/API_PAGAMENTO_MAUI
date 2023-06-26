using API_Pagamento.Views.Pagamento;
namespace API_Pagamento;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("cadPagamentoView", typeof(CadastroPagamentoView));
	}
}
