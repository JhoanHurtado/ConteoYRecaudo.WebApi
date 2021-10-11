﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Dto.Dto
{
    public class RecaudosDto
    {
        public int Id { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public string Hora { get; set; }
        public string Categoria { get; set; }
        public Decimal ValorTabulado { get; set; }

    }
}

