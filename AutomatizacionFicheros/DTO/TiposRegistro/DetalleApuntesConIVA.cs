using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatizacionFicheros.DTO
{
    public class DetalleApuntesConIva : RegistroBase
    {
        public string tipoImporte { get; set; }
        public string numeroFactura { get; set; }
        public string lineaApunte { get; set; }
        public string descripcionApunte { get; set; }
        public string subtipoFactura { get; set; }
        public string baseImponible { get; set; }
        public string porcentajeIVA { get; set; }
        public string cuotaIVA { get; set; }
        public string porcentajeRecargo { get; set; }
        public string cuotaRecargo { get; set; }
        public string porcentajeRetencion { get;set; }
        public string cuotaRetencion { get; set; }  
        public string operacionSujetaIVA { get; set; }
        public string marcaAfecta415 { get; set; }
        public string marcaFacturaCaja { get; set; }
        public string reserva1 { get; set; }
        public string cuentaIvaSoportado { get; set; }
        public string cuentaRecargoSoportado { get; set; }
        public string cuentaRetencion { get; set; }
        public string cuentaIVARepercutido2 { get; set; }
        public string cuentaRecargo2 { get; set; }
        public string registroAnalitico { get; set; }
        public string reserva2 { get;set; }
    }

}
