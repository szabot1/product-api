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
        public required string Name { get; init; }
        public required int Price { get; init; }
    }

    public record UpdateProductDto
    {
        public required string Name { get; init; }
        public required int Price { get; init; }
    }
}