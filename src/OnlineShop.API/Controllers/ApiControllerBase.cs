using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.API.Controllers
{
	[ApiController]
	public class ApiControllerBase : ControllerBase
	{
		protected IActionResult HandleResult(string? errorMessage, object? result, bool success = true, int statusCode = 200)
		{
			if (result == null)
			{
				return NotFound();
			}

			if (success)
			{
				return StatusCode(statusCode, new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new
			{
				success = false,
				error = errorMessage
			});
		}
	}
}
