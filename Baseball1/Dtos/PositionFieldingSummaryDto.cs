namespace Baseball1.Dtos
{
    public class PositionFieldingSummaryDto
    {
        public string? TeamId { get; set; }
        public string Pos { get; set; } = null!;
        public short? G { get; set; }
        public short? Gs { get; set; }
        public int? InnOuts { get; set; }
        public int? Po { get; set; }
        public short? A { get; set; }
        public short? E { get; set; }
        public short? Dp { get; set; }
        public short? Pb { get; set; }
        public short? Wp { get; set; }
        public short? Sb { get; set; }
        public short? Cs { get; set; }
    }
}
