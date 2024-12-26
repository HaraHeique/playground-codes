using System.ComponentModel.DataAnnotations;

namespace Youtube.MilanJovanovic.InputValidation;

public record ValidationSettings 
{
    public const string SectionKey = "ValidationSettings";

    [Required]
    public int MinimumAge { get; init; }
}