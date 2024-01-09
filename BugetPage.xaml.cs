using MBP.MOBIL.Models;
namespace MBP.MOBIL;

public partial class BugetPage : ContentPage
{
	public BugetPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Buget)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveBugetAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Buget)BindingContext;
        await App.Database.DeleteBugetAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseAddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacturaPage((Buget)
       this.BindingContext)
        {
            BindingContext = new Factura()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Buget)BindingContext;

        listView.ItemsSource = await App.Database.GetListaFacturisAsync(shopl.ID);
    }



}