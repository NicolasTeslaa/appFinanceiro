namespace appFinanceiro.Pages.Transactions;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
        InitializeComponent();
    }
    private void TapGestureRecognizer_Tapped(Object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

}