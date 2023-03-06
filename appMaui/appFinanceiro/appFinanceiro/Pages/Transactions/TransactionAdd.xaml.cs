using appFinanceiro.Models;
using appFinanceiro.Repositories;
using System.Text;

namespace appFinanceiro.Pages.Transactions;

public partial class TransactionAdd : ContentPage
{
    private ITransactionRepository _repository;
	public TransactionAdd(ITransactionRepository repository)
	{
        InitializeComponent();
        _repository = repository;
    }
    private void TapGestureRecognizer_Tapped(Object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void Validate(object sender, EventArgs e)
    {
        //Valida os dados Digitados
        if (isValid() == false)
            return;
        SaveTransactionInDatabase();
        Navigation.PopModalAsync();
       var count = _repository.GetAll().Count;
        App.Current.MainPage.DisplayAlert("Mensagem!", $"Existem {count} registro(s) no banco! ", "OK");
    }

    private void SaveTransactionInDatabase()
    {
        //pega os dados e cria o objeto Transaction
        Transaction transaction = new Transaction()
        {
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expenses,
            Name = EntryName.Text,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text)
        };

        //Envia para o repositório
        _repository.Add(transaction);
    }

    private bool isValid()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();
        //se for vazio ou um espaço em branco, não irá validar
        if(string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("Campo nome não foi preenchido");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.AppendLine("Campo Valor não foi preenchido");
            valid = false;
        }
        double result;
        if (string.IsNullOrEmpty(EntryValue.Text) && double.TryParse(EntryValue.Text, out result))
        {
            sb.AppendLine("Campo Valor é inválido");
            valid = false;
        }

        if(valid == false)
        {
            LabelError.Text = sb.ToString();
        }


        return valid;
    }
}