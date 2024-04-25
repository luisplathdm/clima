using System.Net.Mime;
using System.Text.Json;

namespace clima;

public partial class MainPage : ContentPage
{
    Resposta resposta;
	const string Url="https://api.hgbrasil.com/weather42bd1065";
	public MainPage()

	{
		InitializeComponent();
		AtualizaTempo();
	}

    async void AtualizaTempo() 
	{
		try
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(Url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}
			PreencherTela();
		}
		catch (Exception e)	
		{
			System.Diagnostics.Debug.WriteLine(e);
		}
	}

   

	
    void PreencherTela()
		{
				
			labeltemp.Text= resposta.results.temp.ToString();

			labelcity.Text= resposta.results.city;

			labeldachuva.Text = resposta.results.rain.ToString();

			labeldaumidade.Text = resposta.results.humidity.ToString();

			labeldaforcadovento.Text = resposta.results.wind_speedy;

			labeldadirecaodovento.Text = resposta.results.wind_direction.ToString();

			labeldonascerdosol.Text = resposta.results.sunrise;

			labeldopordosol.Text = resposta.results.sunset;
			
		}

}

