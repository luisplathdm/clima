using System.Net.Mime;
using System.Text.Json;

namespace clima;

public partial class MainPage : ContentPage
{
    Resposta resposta;
	const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=42bd1065";
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
			
			labeldafasedalua.Text = resposta.results.moon_phase;
			
			if(resposta.results.moon_phase=="full")
			labeldafasedalua.Text = "Cheia";
		else if(resposta.results.moon_phase=="new")
			labeldafasedalua.Text = "Nova";
		else if(resposta.results.moon_phase=="growing")
			labeldafasedalua.Text = "Crescente";
		else if(resposta.results.moon_phase=="waning")
			labeldafasedalua.Text = "minguante";


		if(resposta.results.currently=="dia")
		{
			if(resposta.results.rain<=10)
			imgBackground.Source="diachuvoso.png";
			else if(resposta.results.cloudiness>=10)
			imgBackground.Source="dianublado.png";
			else
			imgBackground.Source="diaensolarado";
		}
		else
		{
			if(resposta.results.rain<=10)
			 imgBackground.Source="diachuvoso.png";
	 else if (resposta.results.cloudiness>=10)
			 imgBackground.Source="noitenublada.png";
			 else
		 imgBackground.Source="noite.png";
		}
	  }
}

