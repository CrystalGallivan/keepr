using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    [MaxLength(20)]
    [MinLength(6)]
    // [HttpContext]
    public string UserId { get; set; }
    [Required]
    [Url]
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}