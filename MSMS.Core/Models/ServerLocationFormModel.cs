using System;
using System.ComponentModel.DataAnnotations;
using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Core.Models;

public class ServerLocationFormModel
{
    public int WorldId { get; set; }
    public WorldType WorldType { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [RegularExpression(@"\d{1,5}\/\d{1,5}\/\d{1,5}")]
    public string Coordinates { get; set; } = null!;

    [Required]
    public LocationType LocationType { get; set; }

    [Required]
    public LocationAccessModifier AccessModifier { get; set; }

    public string? Description { get; set; } = null!;

    public string? CreatorId { get; set; } = null!;
}
