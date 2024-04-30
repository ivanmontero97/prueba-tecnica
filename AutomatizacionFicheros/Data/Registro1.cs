using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO.TiposRegistro;
using ClosedXML.Excel;
using System;
using System.IO;

namespace AutomatizacionFicheros.Data
{
    public class Registro1 : IExcelWritter
    {
        public AltaCabeceraApuntesConIva _altaCabeceraApuntesConIva { get; set; }
        private string _filePath { get; set; }

        public Registro1(AltaCabeceraApuntesConIva altaCabeceraApuntesConIva, string filePath)
        {
            _altaCabeceraApuntesConIva = altaCabeceraApuntesConIva;
            _filePath = filePath;
        }

        public void EscribirEncabezados(IXLWorksheet worksheet)
        {
            // Definir los encabezados de las columnas
            string[] encabezados = {
                "Tipo Formato", "Código Empresa", "Fecha Apunte", "Tipo Registro", "Cuenta",
                "Descripción Cuenta", "Tipo de Factura", "Número de factura o documento", "Línea Apunte(I)",
                "Descripción del apunte", "Importe", "Reserva1", "NIF Cliente o proveedor", "Nombre cliente o proveedor",
                "Código Postal", "Reserva2", "Fecha Operación", "Fecha factura", "Número factura ampliado",
                "Reserva3", "Moneda enlace", "Indicador Generado"
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
            Console.WriteLine($"Creando Excel del registro AltaCabeceraApuntesConIva en {_filePath}");
            workbook.SaveAs(_filePath);
        }

        public void EscribirDatos(IXLWorksheet worksheet, int row)
        {
            // Escribir los datos del registro en la hoja de cálculo
            worksheet.Cell(row, 1).Value = _altaCabeceraApuntesConIva.tipoFormato;
            worksheet.Cell(row, 2).Value = _altaCabeceraApuntesConIva.codigoEmpresa;
            worksheet.Cell(row, 3).Value = _altaCabeceraApuntesConIva.fechaApunte;
            worksheet.Cell(row, 4).Value = _altaCabeceraApuntesConIva.tipoRegistro;
            worksheet.Cell(row, 5).Value = _altaCabeceraApuntesConIva.cuenta;
            worksheet.Cell(row, 6).Value = _altaCabeceraApuntesConIva.descripcionCuenta;
            worksheet.Cell(row, 7).Value = _altaCabeceraApuntesConIva.tipoFactura;
            worksheet.Cell(row, 8).Value = _altaCabeceraApuntesConIva.numeroFacturaDocumento;
            worksheet.Cell(row, 9).Value = _altaCabeceraApuntesConIva.lineaApunte;
            worksheet.Cell(row, 10).Value = _altaCabeceraApuntesConIva.descripcionApunte;
            worksheet.Cell(row, 11).Value = _altaCabeceraApuntesConIva.importe;
            worksheet.Cell(row, 12).Value = _altaCabeceraApuntesConIva.reserva1;
            worksheet.Cell(row, 13).Value = _altaCabeceraApuntesConIva.nifClienteProveedor;
            worksheet.Cell(row, 14).Value = _altaCabeceraApuntesConIva.nombreClienteProveedor;
            worksheet.Cell(row, 15).Value = _altaCabeceraApuntesConIva.codigoPostal;
            worksheet.Cell(row, 16).Value = _altaCabeceraApuntesConIva.reserva2;
            worksheet.Cell(row, 17).Value = _altaCabeceraApuntesConIva.fechaOperacion;
            worksheet.Cell(row, 18).Value = _altaCabeceraApuntesConIva.fechaFactura;
            worksheet.Cell(row, 19).Value = _altaCabeceraApuntesConIva.numeroFacturaAmpliado;
            worksheet.Cell(row, 20).Value = _altaCabeceraApuntesConIva.reserva3;
            worksheet.Cell(row, 21).Value = _altaCabeceraApuntesConIva.monedaEnlace;
            worksheet.Cell(row, 22).Value = _altaCabeceraApuntesConIva.indicadorGenerado;
        }
    }
}
