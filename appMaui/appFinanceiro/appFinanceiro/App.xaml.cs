

using appFinanceiro.Pages.Transactions;

namespace appFinanceiro;

public partial class App : Application
{
	public App(TransactionList listPage)
	{
		InitializeComponent();

        MainPage = new NavigationPage(listPage);
	}
}
