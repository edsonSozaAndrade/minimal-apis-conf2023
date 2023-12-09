namespace minimal_apis_conf2023.Models.Request
{
    public class CreatePokemonRequest
    {
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public int HealthPoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string EvolveFrom { get; set; } = default!;
        public string EvolveTo { get; set; } = default!;
    }
}
