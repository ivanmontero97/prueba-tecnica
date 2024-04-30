using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatizacionFicheros.DTO.TiposRegistro
{
    public class AltaApuntesSinIva : RegistroBase
    {
        public string tipoImporte { get; set; }
        public string referenciaDocumento { get; set; }
        public string lineaApunte { get; set; }
        public string descripcionApunte { get; set; }
        public string importe { get; set; }
        public string reserva1 { get; set; }
        public string indicadorAsientoNomina { get; set; }
        public string registroAnalitico { get; set; }
        public string reserva2 { get; set; }
    }
}

