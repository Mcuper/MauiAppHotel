using MauiAppHotel.Models;
using MauiAppHotel.Views;

// O namespace 'MauiAppHotel.Views' deve ser usado se a pasta 'Views' existir
// Caso contrário, use apenas 'MauiAppHotel'
namespace MauiAppHotel;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // ----------------------------------------------------
        // CÓDIGO DE INICIALIZAÇÃO MOVIDO PARA DENTRO DO CONSTRUTOR
        // E EXECUTADO APÓS InitializeComponent()
        // ----------------------------------------------------
        PropriedadesApp = (App)Application.Current;

        // O compilador agora reconhece pck_quarto, dtpck_checkin, etc.
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos; 

        dtpck_checkin.MinimumDate = DateTime.Now; 
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1); 
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}