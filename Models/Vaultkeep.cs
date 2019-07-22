using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vaultkeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    // [Required]
    public string UserId { get; set; }
  }
}