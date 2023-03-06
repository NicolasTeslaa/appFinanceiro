using appFinanceiro.Repositories;

namespace appFinanceiro.Pages.Transactions;
public partial class TransactionList : ContentPage
{
    private TransactionAdd _transactionAdd;
    private TransactionEdit _transactionEdit;
    public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit )
	{
        this._transactionAdd = transactionAdd;
        this._transactionEdit = transactionEdit;
		InitializeComponent();
    }

	private void Add(object sender, EventArgs e)
	{
        Navigation.PushModalAsync(_transactionAdd);
	}
    private void Edit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionEdit);
    }
}