using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entities;

public class BookingOwnerEntity
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string Firstname { get; set; } = null!;
  public string Lastname { get; set; } = null!;
  public string Email { get; set; } = null!;

  [ForeignKey(nameof(Address))]
  public string? BookingAddressId { get; set; }
  public BookingAddressEntity? Address { get; set; }
}
