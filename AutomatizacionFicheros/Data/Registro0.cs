using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO.TiposRegistro;
using ClosedXML.Excel;
using System;
using System.IO;

namespace AutomatizacionFicheros.Data
{
    public class Registro0 : IExcelWritter
    {
        public AltaApuntesSinIva _altaApuntesSinIva { get; set; }
        private string _filePath { get; set; }

        public Registro0(AltaApuntesSinIva altaApuntesSinIva, string filePath)
        {
            _altaApuntesSinIva = altaApuntesSinIva;
            _filePath = filePath;
        }

        public void EscribirEncabezados(IXLWorksheet worksheet)
        {
            // Definir los encabezados de las columnas
            string[] encabezados = {
                "Tipo Formato", "Código Empresa", "Fecha Apunte", "Tipo Registro", "Cuenta",
                "Descripción Cuenta", "Tipo Importe", "Referencia Documento", "Linea de apunte", "Descripción Apunte",
                "Importe", "Reserva1", "Indicador Asiento Nómina", "Registro Analítico", "Reserva2",
                "Moneda Enlace", "Indicador Generado"
            };

            // Escribir los encabezados en la primera fila
            for (int i = 0; i < encabezados.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = encabezados[i];
            }
        }

        public void GuardarDatos()
        {
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet;

            // Si el archivo ya existe, abrirlo y escribir en la siguiente fila
            if (File.Exists(_filePath))
            {
                workbook = new XLWorkbook(_filePath);
                worksheet = workbook.Worksheet(1);
                // Encuentra la primera fila vacía para escribir los datos
                int row = worksheet.LastRowUsed().RowNumber() + 1;
                EscribirDatos(worksheet, row);
            }
            else
            {
                worksheet = workbook.Worksheets.Add("Registros");
                EscribirEncabezados(worksheet);
                EscribirDatos(worksheet, 2); // Empezar a escribir en la segunda fila
            }

            // Guardar el archivo Excel
            Console.WriteLine($"Creando Excel del registro AltaApuntesSinIva en {_filePath}");
            workbook.SaveAs(_filePath);
        }

        public void EscribirDatos(IXLWorksheet worksheet, int row)
        {
            // Escribir los datos del registro en la hoja de cálculo
            worksheet.Cell(row, 1).Value = _altaApuntesSinIva.tipoFormato;
            worksheet.Cell(row, 2).Value = _altaApuntesSinIva.codigoEmpresa;
            worksheet.Cell(row, 3).Value = _altaApuntesSinIva.fechaApunte;
            worksheet.Cell(row, 4).Value = _altaApuntesSinIva.tipoRegistro;
            worksheet.Cell(row, 5).Value = _altaApuntesSinIva.cuenta;
            worksheet.Cell(row, 6).Value = _altaApuntesSinIva.descripcionCuenta;
            worksheet.Cell(row, 7).Value = _altaApuntesSinIva.tipoImporte;
            worksheet.Cell(row, 8).Value = _altaApuntesSinIva.referenciaDocumento;
            worksheet.Cell(row, 9).Value = _altaApuntesSinIva.lineaApunte;
            worksheet.Cell(row, 10).Value = _altaApuntesSinIva.descripcionApunte;
            worksheet.Cell(row, 11).Value = _altaApuntesSinIva.importe;
            worksheet.Cell(row, 12).Value = _altaApuntesSinIva.reserva1;
            worksheet.Cell(row, 13).Value = _altaApuntesSinIva.indicadorAsientoNomina;
            worksheet.Cell(row, 14).Value = _altaApuntesSinIva.registroAnalitico;
            worksheet.Cell(row, 15).Value = _altaApuntesSinIva.reserva2;
            worksheet.Cell(row, 16).Value = _altaApuntesSinIva.monedaEnlace;
            worksheet.Cell(row, 17).Value = _altaApuntesSinIva.indicadorGenerado;
        }
    }
}
