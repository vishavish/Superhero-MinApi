using Application.Heroes.Commands;
using Application.Heroes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;


public static class HeroEndpoints
{
	public static void Map(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/heroes"); 


		group.MapPost("/", CreateHero);
		group.MapGet("/", GetHeroes);
	}


	public static async Task<IResult> CreateHero(ISender sender, [FromBody]CreateHeroCommand cmd)
	{
		var res = await sender.Send(cmd);
		return Results.Ok(res);
	}


	public static async Task<IResult> GetHeroes(ISender sender)
	{
		var qry = new ListHeroesQuery();
		var list = await sender.Send(qry);

		return Results.Ok(list);
	}
}
