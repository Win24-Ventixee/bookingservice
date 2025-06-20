﻿using Presentation.Data.Entities;
using Presentation.Data.Repositories;
using Presentation.Models;

namespace Presentation.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
  private readonly IBookingRepository _bookingRepository = bookingRepository;

  public async Task<BookingResult> CreateBookingAsync(CreateBookingRequest request)
  {
    var bookingEntity = new BookingEntity
    {
      EventId = request.EventId,
      BookingDate = DateTime.Now,
      TicketQuantity = request.TicketQuantity,
      Owner = new BookingOwnerEntity
      {
        Firstname = request.FirstName,
        Lastname = request.LastName,
        Email = request.Email,
        Address = new BookingAddressEntity
        {
          StreetName = request.StreetName,
          PostalCode = request.PostalCode,
          City = request.City,
        }
      }
    };

    var result = await _bookingRepository.AddAsync(bookingEntity);

    return result.Success
      ? new BookingResult { Success = true }
      : new BookingResult { Success = false, Error = result.Error };
  }
}
