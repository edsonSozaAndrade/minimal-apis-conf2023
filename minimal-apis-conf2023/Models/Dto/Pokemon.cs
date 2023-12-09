namespace minimal_apis_conf2023.Models.Dto
{
    public class Pokemon
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public int HealthPoints { get; set; } = default!;
        public int Attack { get; set; } = default!;
        public int Defense { get; set; } = default!;
        public int Speed { get; set; } = default!;
        public string EvolveFrom { get; set; } = default!;
        public string EvolveTo { get; set; } = default!;
        //Reference of default values on:
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/variables#93-default-values
    }
}
