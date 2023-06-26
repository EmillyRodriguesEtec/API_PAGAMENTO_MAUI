using API_Pagamento.ViewModels.Pagamento;
namespace API_Pagamento.Views.Pagamento;

public partial class CadastroPagamentoView : ContentPage
{
	private CadastroPagamentoViewModel cadViewModel;
	public CadastroPagamentoView()
	{
		InitializeComponent();

		cadViewModel = new CadastroPagamentoViewModel();
		BindingContext = cadViewModel;
		Title = "Novo Pagamento";
	}
}