namespace Baseball1.Dtos
{
    public class PersonFieldingDto
    {
        public List<FieldingDto> FieldingLines { get; set; }
    }

    public class FieldingDto
    {
        public short YearId { get; set; }
        public short Stint { get; set; }
        public string? TeamId { get; set; }
        public string? LgId { get; set; }
        public string Pos { get; set; } = null!;
        public short? G { get; set; }
        public short? Gs { get; set; }
        public short? InnOuts { get; set; }
        public short? Po { get; set; }
        public short? A { get; set; }
        public short? E { get; set; }
        public short? Dp { get; set; }
        public short? Pb { get; set; }
        public short? Wp { get; set; }
        public short? Sb { get; set; }
        public short? Cs { get; set; }
    }
}
