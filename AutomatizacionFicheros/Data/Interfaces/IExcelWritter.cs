using AutomatizacionFicheros.DTO.TiposRegistro;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatizacionFicheros.Data.Interfaces
{
    public interface IExcelWritter
    {
        void EscribirEncabezados(IXLWorksheet worksheet);
        void GuardarDatos();
        void EscribirDatos(IXLWorksheet worksheet, int row);
    }
}
