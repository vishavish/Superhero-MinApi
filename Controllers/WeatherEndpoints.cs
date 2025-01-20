namespace Controllers;


public static class WeatherEndpoints
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapGet("/weather", GetWeather);
	}


	public static string GetWeather ()
	{
		return "hello world wmwkw";
	}
}
