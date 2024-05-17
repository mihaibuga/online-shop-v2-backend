using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.API.Controllers
{
	[ApiController]
	public class ApiControllerBase : ControllerBase
	{
		protected IActionResult HandleResult(object result = null, bool success = true, string errorMessage = null, int statusCode = 200)
		{
			if (result == null)
			{
				return NotFound();
			}

			if (success && result == null)
			{
				return NotFound();
			}

			if (success && result != null)
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
