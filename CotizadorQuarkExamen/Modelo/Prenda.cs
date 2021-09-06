﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo
{
    public abstract class Prenda
    {
        public int IdPrenda { get; set; }
        public bool CalidadPremium { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnStock { get; set; }
        public abstract decimal PrecioFinal();
        protected static int idPrendaGlobal=0;
        
    }
}
