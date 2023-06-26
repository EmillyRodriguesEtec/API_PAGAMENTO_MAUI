using API_Pagamento.ViewModels.Pagamento;

namespace API_Pagamento.Views.Pagamento;

public partial class ListagemView : ContentPage
{
	ListagemPagamentoViewModel viewModel;

	public ListagemView()
	{
		InitializeComponent();

		viewModel = new ListagemPagamentoViewModel();
		BindingContext = viewModel;
		Title = "Pagamento Pix - APP Pagamento";
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_ = viewModel.ObterPagamento();
	}
}
