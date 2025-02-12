using Application.Organizations.Commands;
using Application.Organizations.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;


public static class OrganizationEndpoints
{
	public static void Map(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("api/organizations");
		group.MapPost("/", CreateOrganization);
		group.MapGet("/", GetOrganizations);
		group.MapGet("/{id}", GetOrganization);
		group.MapPut("/{id}", UpdateOrganization);
		group.MapDelete("/{id}", RemoveOrganization);
	}

	private static async Task<IResult> GetOrganizations(ISender sender)
	{
		return Results.Ok(await sender.Send(new ListOrganizationsQuery()));
	}

	private static async Task<IResult> GetOrganization(ISender sender, [AsParameters]GetOrganizationQuery qry)
	{
		var org = await sender.Send(qry);
		return Results.Ok(org);
	}

	private static async Task<IResult> CreateOrganization(IValidator<CreateOrganizationCommand> validator, ISender sender, [FromBody]CreateOrganizationCommand cmd)
	{
		var validationResult = await validator.ValidateAsync(cmd);
		if(!validationResult.IsValid)
		{
			return Results.ValidationProblem(validationResult.ToDictionary());
		}

		var res = await sender.Send(cmd);
		return Results.Ok(res);
	}

	private static async Task<IResult> UpdateOrganization(IValidator<UpdateOrganizationCommand> validator, ISender sender, [FromBody]UpdateOrganizationCommand cmd)
	{
		var validationResult = await validator.ValidateAsync(cmd);
		if(!validationResult.IsValid)
		{
			return Results.ValidationProblem(validationResult.ToDictionary());
		}

		return Results.Ok(await sender.Send(cmd));
	}	

	private static async Task<IResult> RemoveOrganization(ISender sender, [FromBody]RemoveOrganizationCommand cmd)
	{
		return Results.Ok(await sender.Send(cmd));
	}
}
