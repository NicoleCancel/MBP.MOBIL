using MBP.MOBIL.Models;

namespace MBP.MOBIL;

public partial class AdaugareBugetPage : ContentPage
{
	public AdaugareBugetPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetBugetsAsync();
    }
    async void OnBugetAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BugetPage
        {
            BindingContext = new Buget()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new BugetPage
            {
                BindingContext = e.SelectedItem as Buget
            });
        }
    }
}