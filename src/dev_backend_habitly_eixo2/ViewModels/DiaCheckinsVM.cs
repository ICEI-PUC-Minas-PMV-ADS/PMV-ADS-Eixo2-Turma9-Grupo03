using System;
using System.Collections.Generic;

namespace dev_backend_habitly_eixo2.Models
{
    public class DiaCheckinsVM
    {
        public DateTime Data { get; set; }
        public int Total { get; set; }
        public List<string> Horarios { get; set; } = new();
    }
}
