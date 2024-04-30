using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO;
using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomatizacionFicheros.Data.Factory
{
    public class Registro9Creator : Creator
    {
        readonly string filePath = Path.Combine(FileConfig.directorioSalida, "detalleApuntesConIva.xlsx");
        public override IExcelWritter FactoryMethod(string linea)
        {
            DetalleApuntesConIva registroTipo9 = new DetalleApuntesConIva
            {
                tipoFormato = ObtenerValorSeguro(linea, 0),
                codigoEmpresa = ObtenerSubstringSeguro(linea, 1, 5),
                fechaApunte = ObtenerSubstringSeguro(linea, 6, 8),
                tipoRegistro = ObtenerValorSeguro(linea, 14),
                cuenta = ObtenerSubstringSeguro(linea, 15, 12),
                descripcionCuenta = ObtenerSubstringSeguro(linea, 27, 30),
                tipoImporte = ObtenerValorSeguro(linea, 57),
                numeroFactura = ObtenerSubstringSeguro(linea, 58, 10),
                lineaApunte = ObtenerValorSeguro(linea, 68),
                descripcionApunte = ObtenerSubstringSeguro(linea, 69, 30),
                subtipoFactura = ObtenerSubstringSeguro(linea, 99, 2),
                baseImponible = ObtenerSubstringSeguro(linea, 101, 14),
                porcentajeIVA = ObtenerSubstringSeguro(linea, 115, 5),
                cuotaIVA = ObtenerSubstringSeguro(linea, 120, 14),
                porcentajeRecargo = ObtenerSubstringSeguro(linea, 134, 5),
                cuotaRecargo = ObtenerSubstringSeguro(linea, 139, 14),
                porcentajeRetencion = ObtenerSubstringSeguro(linea, 153, 5),
                cuotaRetencion = ObtenerSubstringSeguro(linea, 158, 14),
                operacionSujetaIVA = ObtenerValorSeguro(linea, 174),
                marcaAfecta415 = ObtenerValorSeguro(linea, 175),
                marcaFacturaCaja = ObtenerValorSeguro(linea, 176),
                reserva1 = ObtenerSubstringSeguro(linea, 177,14),
                cuentaIvaSoportado=ObtenerSubstringSeguro(linea,191,12),
                cuentaRecargoSoportado=ObtenerSubstringSeguro(linea,203,12),
                cuentaRetencion=ObtenerSubstringSeguro(linea,215,12),
                cuentaIVARepercutido2=ObtenerSubstringSeguro(linea,227,12),
                cuentaRecargo2=ObtenerSubstringSeguro(linea,239,12),
                registroAnalitico=ObtenerValorSeguro(linea,251),
                reserva2=ObtenerSubstringSeguro(linea,252,256),
                monedaEnlace=ObtenerValorSeguro(linea,508),
                indicadorGenerado=ObtenerValorSeguro(linea,509)
            };

            return new Registro9(registroTipo9, filePath);
        }
    }
}
