


using Microsoft.Maui.Controls;

namespace MauiApp3;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Load();
    }
    protected async Task Load()
    {
        base.OnAppearing();


        name.Text = await ReadRes("name.xml");

        var html = await ReadRes("index.html");
        web.Source = new HtmlWebViewSource() { Html = html };
    }

    private async Task<string> ReadRes(string key)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(key);
        using var reader = new StreamReader(stream);

        var contents = reader.ReadToEnd();
        return contents;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

