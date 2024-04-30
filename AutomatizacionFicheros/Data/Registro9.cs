using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO;
using ClosedXML.Excel;
using System.IO;

namespace AutomatizacionFicheros.Data
{
    public class Registro9 : IExcelWritter
    {
        public DetalleApuntesConIva detalleApuntesConIva { get; set; }
        private string filePath { get; set; }

        public Registro9(DetalleApuntesConIva detalleApuntesConIva, string filePath)
        {
            this.detalleApuntesConIva = detalleApuntesConIva;
            this.filePath = filePath;
        }

        public void GuardarDatos()
        {
            XLWorkbook workbook;
            IXLWorksheet worksheet;

            if (File.Exists(filePath))
            {
                workbook = new XLWorkbook(filePath);
                worksheet = workbook.Worksheet(1);
            }
            else
            {
                workbook = new XLWorkbook();
                worksheet = workbook.Worksheets.Add("Registros");
                EscribirEncabezados(worksheet);
            }

            int lastRow = worksheet.LastRowUsed().RowNumber() + 1;
            EscribirDatos(worksheet, lastRow);

            workbook.SaveAs(filePath);
        }

        public void EscribirEncabezados(IXLWorksheet worksheet)
        {
            string[] encabezados = {
                "Tipo Formato", "Código Empresa", "Fecha Apunte", "Tipo Registro", "Cuenta",
                "Descripción Cuenta", "Tipo de importe", "Numero de factura o documento", "Linea Apunte",
                "Descripcion del apunte","Subtipo de factura", "Base Imponible", "Porcentaje de IVA", "Cuota de IVA", "Porcentaje de recargo",
                "Cuota de recargo", "Porcentaje de retencion", "Cuota de Retencion","Operacion sujeta a IVA","Marca afecta 415","Marca factura en criterio de caja","Reserva1","Cuenta de IVA Soportado",
                "Cuenta de recargo soportado", "Cuenta de retención", "Cuenta de IVA 2 Repercutido","Cuenta de recargo 2 repercutido","Tiene Registro Ánalitico", "Reserva2", "Moneda Enlace","Indicador de generado"
            };

            for (int i = 0; i < encabezados.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = encabezados[i];
            }
        }

        public void EscribirDatos(IXLWorksheet worksheet, int row)
        {
            worksheet.Cell(row, 1).Value = detalleApuntesConIva.tipoFormato;
            worksheet.Cell(row, 2).Value = detalleApuntesConIva.codigoEmpresa;
            worksheet.Cell(row, 3).Value = detalleApuntesConIva.fechaApunte;
            worksheet.Cell(row, 4).Value = detalleApuntesConIva.tipoRegistro;
            worksheet.Cell(row, 5).Value = detalleApuntesConIva.cuenta;
            worksheet.Cell(row, 6).Value = detalleApuntesConIva.descripcionCuenta;
            worksheet.Cell(row, 7).Value = detalleApuntesConIva.tipoImporte;
            worksheet.Cell(row, 8).Value = detalleApuntesConIva.numeroFactura;
            worksheet.Cell(row, 9).Value = detalleApuntesConIva.lineaApunte;
            worksheet.Cell(row, 10).Value = detalleApuntesConIva.descripcionApunte;
            worksheet.Cell(row, 11).Value = detalleApuntesConIva.subtipoFactura;
            worksheet.Cell(row, 12).Value = detalleApuntesConIva.baseImponible;
            worksheet.Cell(row, 13).Value = detalleApuntesConIva.porcentajeIVA;
            worksheet.Cell(row, 14).Value = detalleApuntesConIva.cuotaIVA;
            worksheet.Cell(row, 15).Value = detalleApuntesConIva.porcentajeRecargo;
            worksheet.Cell(row, 16).Value = detalleApuntesConIva.cuotaRecargo;
            worksheet.Cell(row, 17).Value = detalleApuntesConIva.porcentajeRetencion;
            worksheet.Cell(row, 18).Value = detalleApuntesConIva.cuotaRetencion;
            worksheet.Cell(row, 19).Value = detalleApuntesConIva.operacionSujetaIVA;
            worksheet.Cell(row, 20).Value = detalleApuntesConIva.marcaAfecta415;
            worksheet.Cell(row, 21).Value = detalleApuntesConIva.marcaFacturaCaja;
            worksheet.Cell(row, 22).Value = detalleApuntesConIva.reserva1;
            worksheet.Cell(row, 23).Value = detalleApuntesConIva.cuentaIvaSoportado;
            worksheet.Cell(row, 24).Value = detalleApuntesConIva.cuentaRecargoSoportado;
            worksheet.Cell(row, 25).Value = detalleApuntesConIva.cuentaRetencion;
            worksheet.Cell(row, 26).Value = detalleApuntesConIva.cuentaIVARepercutido2;
            worksheet.Cell(row, 27).Value = detalleApuntesConIva.cuentaRecargo2;
            worksheet.Cell(row, 28).Value = detalleApuntesConIva.registroAnalitico;
            worksheet.Cell(row, 29).Value = detalleApuntesConIva.reserva2;
            worksheet.Cell(row, 30).Value = detalleApuntesConIva.monedaEnlace;
            worksheet.Cell(row, 31).Value = detalleApuntesConIva.indicadorGenerado;
        }
    }
}
