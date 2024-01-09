using System;
using MBP.MOBIL.Data;
using System.IO;
namespace MBP.MOBIL;

public partial class App : Application
{
    static BugetDatabase database;
    public static BugetDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               BugetDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Buget.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
