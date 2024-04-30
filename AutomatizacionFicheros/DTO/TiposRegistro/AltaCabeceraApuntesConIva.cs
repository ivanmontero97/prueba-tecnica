using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatizacionFicheros.DTO.TiposRegistro
{
    public class AltaCabeceraApuntesConIva : RegistroBase
    {
        public string tipoFactura { get; set; }
        public string numeroFacturaDocumento { get; set; }
        public string lineaApunte { get; set; }
        public string descripcionApunte { get; set; }
        public string importe { get; set; }
        public string reserva1 { get; set; }
        public string nifClienteProveedor { get; set; }
        public string nombreClienteProveedor { get; set; }
        public string codigoPostal { get; set; }
        public string reserva2 { get; set; }

        public string fechaOperacion { get; set; }
        public string fechaFactura { get; set; }
        public string numeroFacturaAmpliado { get; set; }
        public string reserva3 { get; set; }
    }
}
