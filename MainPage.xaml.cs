using System.Net.Http.Headers;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string URL = "https://meowfacts.herokuapp.com/";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times xyx";
            //dotnet publish -c Release -r android-arm64 -p:PackageFormat=Apk -f net8.0-android --sc true
            SemanticScreenReader.Announce(CounterBtn.Text);


            Test();
        }

        private void Test()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;

            var dataObjects = response.Content.ReadAsStringAsync().Result;

            CounterLbl.Text = dataObjects;
            SemanticScreenReader.Announce(CounterLbl.Text);
        }
    }
}
