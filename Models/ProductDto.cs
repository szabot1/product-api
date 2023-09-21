using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public record ProductDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; init; }
        public required int Price { get; init; }
        public DateTimeOffset CreatedTime { get; init; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedTime { get; init; } = DateTimeOffset.UtcNow;
    }

    public record CreateProductDto
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        [Range(0, 10000)]
        public required int Price { get; init; }
    }

    public record UpdateProductDto
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        [Range(0, 10000)]
        public required int Price { get; init; }
    }
}