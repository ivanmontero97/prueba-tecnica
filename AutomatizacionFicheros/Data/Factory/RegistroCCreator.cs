using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO;
using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomatizacionFicheros.Data.Factory
{
    public class RegistroCCreator : Creator
    {
        readonly string filePath = Path.Combine(FileConfig.directorioSalida, "AltaModificacion.xlsx");
        public override IExcelWritter FactoryMethod(string linea)
        {
            AltaModificacion  registroTipoC = new AltaModificacion
            {
                tipoFormato = ObtenerValorSeguro(linea, 0),
                codigoEmpresa = ObtenerSubstringSeguro(linea, 1, 5),
                fechaApunte = ObtenerSubstringSeguro(linea, 6, 8),
                tipoRegistro = ObtenerValorSeguro(linea, 14),
                cuenta = ObtenerSubstringSeguro(linea, 15, 12),
                descripcionCuenta = ObtenerSubstringSeguro(linea, 27, 30),
                actualizarSaldoInicial = ObtenerValorSeguro(linea, 57),
                saldoInicial = ObtenerSubstringSeguro(linea, 58, 14),
                ampliacion = ObtenerValorSeguro(linea, 72),
                reserva1 = ObtenerSubstringSeguro(linea, 73, 4),
                nif = ObtenerSubstringSeguro(linea, 77, 14),
                siglasViaPublica = ObtenerSubstringSeguro(linea, 91, 2),
                viaPublica = ObtenerSubstringSeguro(linea, 93, 30),
                numero = ObtenerSubstringSeguro(linea, 123, 5),
                escalera = ObtenerSubstringSeguro(linea, 128, 2),
                piso = ObtenerSubstringSeguro(linea, 130, 2),
                puerta = ObtenerSubstringSeguro(linea, 132, 2),
                municipio = ObtenerSubstringSeguro(linea, 134, 20),
                codigoPostal = ObtenerSubstringSeguro(linea, 154,5),
                provincia=ObtenerSubstringSeguro(linea,159,15),
                pais=ObtenerSubstringSeguro(linea,174,3),
                telefono=ObtenerSubstringSeguro(linea,177,12),
                extension=ObtenerSubstringSeguro(linea,189,4),
                fax=ObtenerSubstringSeguro(linea,193,12),
                email=ObtenerSubstringSeguro(linea,205,30),
                reservado1=ObtenerSubstringSeguro(linea,235,2),
                criterioCaja=ObtenerValorSeguro(linea,1),
                reservado2=ObtenerSubstringSeguro(linea,238,2),
                cuentaContrapartida=ObtenerSubstringSeguro(linea,240,12),
                codigoPais=ObtenerSubstringSeguro(linea,252,2),
                reserva2=ObtenerSubstringSeguro(linea,254,254),
                monedaEnlace = ObtenerValorSeguro(linea, 508),
                indicadorGenerado = ObtenerValorSeguro(linea, 509)
            };

            return new RegistroC(registroTipoC, filePath);
        }
    }
}
