using MBP.MOBIL.Models;

namespace MBP.MOBIL;

public partial class FacturaPage : ContentPage
{
    Buget sl;
    public FacturaPage(Buget slist)
	{
		InitializeComponent();
        sl = slist;

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Factura)BindingContext;
        await App.Database.SaveFacturaAsync(product);
        listView.ItemsSource = await App.Database.GetFacturasAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Factura)BindingContext;
        await App.Database.DeleteFacturaAsync(product);
        listView.ItemsSource = await App.Database.GetFacturasAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetFacturasAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Factura p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Factura;
            var lp = new ListaFacturi()
            {
                BugetID = sl.ID,
                FacturaID = p.ID
            };
            await App.Database.SaveListaFacturiAsync(lp);
            p.ListaFacturis = new List<ListaFacturi> { lp };
            await Navigation.PopAsync();
        }

    }
    }