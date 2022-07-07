using System;
using System.Collections.Generic;

namespace Baseball1.Models
{
    public partial class War
    {
        public string Name { get; set; }
        public string bbrefId { get; set; }
        public int yearId { get; set; }
        public string teamId { get; set; }
        public int stintId { get; set; }
        public string lgId { get; set; }
        public float batWAA { get; set; }
        public float batWAR { get; set; }
        public float pitWAA { get; set; }
        public float pitWAR { get; set; }
        public float WAA { get; set; }
        public float WAR { get; set; }

    }
}
