using Application.Heroes.Commands;
using Application.Heroes.Queries;
using FluentValidation;
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
		group.MapGet("/{id}", GetHero);
		group.MapPut("/update/{id}", UpdateHero);
		group.MapDelete("/remove/{id}", RemoveHero);
	}

	public static async Task<IResult> GetHeroes(ISender sender)
	{
		// var list = await sender.Send(new ListHeroesQuery());
		return Results.Ok(await sender.Send(new ListHeroesQuery()));
	}

	public static async Task<IResult> GetHero(ISender sender, [AsParameters]GetHeroQuery qry)
	{
		var hero = await sender.Send(qry);
		return Results.Ok(hero);
	}

	public static async Task<IResult> CreateHero(
		IValidator<CreateHeroCommand> validator,
		ISender sender,
		[FromBody]CreateHeroCommand cmd)
	{
		var validationResult = await validator.ValidateAsync(cmd);
		if(!validationResult.IsValid)
		{
			return Results.ValidationProblem(validationResult.ToDictionary());	
		}
		
		var res = await sender.Send(cmd);
		return Results.Ok(res);
	}

	public static async Task<IResult> UpdateHero(
		IValidator<UpdateHeroCommand> validator,
		ISender sender,
		[FromBody]UpdateHeroCommand cmd)
	{
		var validationResult = await validator.ValidateAsync(cmd);
		if (!validationResult.IsValid)
		{
			return Results.ValidationProblem(validationResult.ToDictionary());
		}
		
		return Results.Ok(await sender.Send(cmd));
	}
	
	public static async Task<IResult> RemoveHero(ISender sender, [FromBody]RemoveHeroCommand cmd)
	{
		return Results.Ok(await sender.Send(cmd));
	}
}
