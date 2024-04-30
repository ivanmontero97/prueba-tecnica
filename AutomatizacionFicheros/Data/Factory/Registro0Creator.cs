using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutomatizacionFicheros.Data.Factory
{
    public class Registro0Creator : Creator
    {
        readonly string filePath = Path.Combine(FileConfig.directorioSalida, "altaApuntesSinIva.xlsx");
        public override IExcelWritter FactoryMethod(string linea)
        {
            AltaApuntesSinIva registroTipo0 = new AltaApuntesSinIva
            {
                tipoFormato = ObtenerValorSeguro(linea, 0),
                codigoEmpresa = ObtenerSubstringSeguro(linea, 1, 5),
                fechaApunte = ObtenerSubstringSeguro(linea, 6, 8),
                tipoRegistro = ObtenerValorSeguro(linea, 14),
                cuenta = ObtenerSubstringSeguro(linea, 15, 12),
                descripcionCuenta = ObtenerSubstringSeguro(linea, 27, 30),
                tipoImporte = ObtenerValorSeguro(linea, 57),
                referenciaDocumento = ObtenerSubstringSeguro(linea, 58, 10),
                lineaApunte = ObtenerValorSeguro(linea, 68),
                descripcionApunte = ObtenerSubstringSeguro(linea, 69, 30),
                importe = ObtenerSubstringSeguro(linea, 99, 14),
                reserva1 = ObtenerSubstringSeguro(linea, 113, 137),
                indicadorAsientoNomina = ObtenerValorSeguro(linea, 250),
                registroAnalitico = ObtenerValorSeguro(linea, 251),
                reserva2 = ObtenerSubstringSeguro(linea, 252, 256),
                monedaEnlace = ObtenerValorSeguro(linea, 508),
                indicadorGenerado = ObtenerValorSeguro(linea, 509)
            };

            return new Registro0(registroTipo0,filePath);
        }
    }
}
