using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomatizacionFicheros.Data.Factory
{
    public class Registro1Creator : Creator
    {
        readonly string filePath = Path.Combine(FileConfig.directorioSalida, "altaCabeceraApuntesConIva.xlsx");
        public override IExcelWritter FactoryMethod(string linea)
        {
            AltaCabeceraApuntesConIva registroTipo1 = new AltaCabeceraApuntesConIva
            {
                tipoFormato = ObtenerValorSeguro(linea, 0),
                codigoEmpresa = ObtenerSubstringSeguro(linea, 1, 5),
                fechaApunte = ObtenerSubstringSeguro(linea, 6, 8),
                tipoRegistro = ObtenerValorSeguro(linea, 14),
                cuenta = ObtenerSubstringSeguro(linea, 15, 12),
                descripcionCuenta = ObtenerSubstringSeguro(linea, 27, 30),
                tipoFactura = ObtenerValorSeguro(linea, 57),
                numeroFacturaDocumento = ObtenerSubstringSeguro(linea, 58, 10),
                lineaApunte = ObtenerValorSeguro(linea, 68),
                descripcionApunte = ObtenerSubstringSeguro(linea, 69, 30),
                importe = ObtenerSubstringSeguro(linea, 99, 14),
                reserva1 = ObtenerSubstringSeguro(linea, 113, 62),
                nifClienteProveedor = ObtenerSubstringSeguro(linea, 175, 14),
                nombreClienteProveedor = ObtenerSubstringSeguro(linea, 189, 40),
                codigoPostal = ObtenerSubstringSeguro(linea, 229, 5),
                reserva2 = ObtenerSubstringSeguro(linea, 234, 2),
                fechaOperacion = ObtenerSubstringSeguro(linea, 236, 8),
                fechaFactura = ObtenerSubstringSeguro(linea, 244, 8),
                numeroFacturaAmpliado = ObtenerSubstringSeguro(linea, 252, 60),
                reserva3 = ObtenerSubstringSeguro(linea, 312, 196),
                monedaEnlace = ObtenerValorSeguro(linea, 508),
                indicadorGenerado = ObtenerValorSeguro(linea, 509)
            };

            return new Registro1(registroTipo1, filePath);
        }
    }
}
