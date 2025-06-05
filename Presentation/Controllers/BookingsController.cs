using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingsService) : ControllerBase
{
  private readonly IBookingService _bookingsService = bookingsService;

  [HttpPost]
  public async Task<IActionResult> Create(CreateBookingRequest request)
  {
    var result = await _bookingsService.CreateBookingAsync(request);
    return result.Success
      ? Ok()
      : StatusCode(StatusCodes.Status500InternalServerError, "Unable to create booking.");
  }
}
