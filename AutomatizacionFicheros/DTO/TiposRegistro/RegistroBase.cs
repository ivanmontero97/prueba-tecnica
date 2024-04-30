using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatizacionFicheros.DTO.TiposRegistro
{
    public class RegistroBase
    {
        public string tipoFormato { get; set; }
        public string codigoEmpresa { get; set; }
        public string fechaApunte { get; set; }
        public string tipoRegistro { get; set; }
        public string cuenta { get; set; }
        public string descripcionCuenta { get; set; }
        public string monedaEnlace { get; set; }
        public string indicadorGenerado { get; set; }

    }
}
