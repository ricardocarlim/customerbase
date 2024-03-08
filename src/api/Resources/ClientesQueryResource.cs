namespace api.Resources
{
    public record ClientesQueryResource: QueryResource
    {
        public string? Nome { get; init; }
        public string? Email { get; init; }
    }
}
