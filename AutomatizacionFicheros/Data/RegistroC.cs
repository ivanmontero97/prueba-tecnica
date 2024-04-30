using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO;
using AutomatizacionFicheros.DTO.TiposRegistro;
using ClosedXML.Excel;
using System.IO;

namespace AutomatizacionFicheros.Data
{
    public class RegistroC : IExcelWritter
    {
        public AltaModificacion altaModificacion { get; set; }
        private string filePath { get; set; }

        public RegistroC(AltaModificacion altaModificacion, string filePath)
        {
            this.altaModificacion = altaModificacion;
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
                "Tipo Formato", "Código Empresa", "Fecha Alta", "Tipo Registro", "Cuenta",
                "Descripción Cuenta", "Actualizar saldo inicial", "Saldo Inicial", "Ampliacion",
                "Reserva1","NIF", "Siglas Via Publica", "Via Publica", "Numero", "Escalera",
                "Piso", "Puerta", "Municipio","Codigo Postal","Provincia","Pais","Telefono","Extension",
                "Fax", "Email", "Reservado1","Criterio de caja","Reservado2", "Cuenta contrapartida", "Codigo pais","Reserva2","Moneda enlace","Indicador Generado"
            };

            for (int i = 0; i < encabezados.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = encabezados[i];
            }
        }

        public void EscribirDatos(IXLWorksheet worksheet, int row)
        {
            worksheet.Cell(row, 1).Value = altaModificacion.tipoFormato;
            worksheet.Cell(row, 2).Value = altaModificacion.codigoEmpresa;
            worksheet.Cell(row, 3).Value = altaModificacion.fechaAlta;
            worksheet.Cell(row, 4).Value = altaModificacion.tipoRegistro;
            worksheet.Cell(row, 5).Value = altaModificacion.cuenta;
            worksheet.Cell(row, 6).Value = altaModificacion.descripcionCuenta;
            worksheet.Cell(row, 7).Value = altaModificacion.actualizarSaldoInicial;
            worksheet.Cell(row, 8).Value = altaModificacion.saldoInicial;
            worksheet.Cell(row, 9).Value = altaModificacion.ampliacion;
            worksheet.Cell(row, 10).Value = altaModificacion.reserva1;
            worksheet.Cell(row, 11).Value = altaModificacion.nif;
            worksheet.Cell(row, 12).Value = altaModificacion.siglasViaPublica;
            worksheet.Cell(row, 13).Value = altaModificacion.viaPublica;
            worksheet.Cell(row, 14).Value = altaModificacion.numero;
            worksheet.Cell(row, 15).Value = altaModificacion.escalera;
            worksheet.Cell(row, 16).Value = altaModificacion.piso;
            worksheet.Cell(row, 17).Value = altaModificacion.puerta;
            worksheet.Cell(row, 18).Value = altaModificacion.municipio;
            worksheet.Cell(row, 19).Value = altaModificacion.codigoPostal;
            worksheet.Cell(row, 20).Value = altaModificacion.provincia;
            worksheet.Cell(row, 21).Value = altaModificacion.pais;
            worksheet.Cell(row, 22).Value = altaModificacion.telefono;
            worksheet.Cell(row, 23).Value = altaModificacion.extension;
            worksheet.Cell(row, 24).Value = altaModificacion.fax;
            worksheet.Cell(row, 25).Value = altaModificacion.email;
            worksheet.Cell(row, 26).Value = altaModificacion.reservado1;
            worksheet.Cell(row, 27).Value = altaModificacion.criterioCaja;
            worksheet.Cell(row, 28).Value = altaModificacion.reservado2;
            worksheet.Cell(row, 29).Value = altaModificacion.cuentaContrapartida;
            worksheet.Cell(row, 30).Value = altaModificacion.codigoPais;
            worksheet.Cell(row, 31).Value = altaModificacion.reserva2;
            worksheet.Cell(row, 32).Value = altaModificacion.monedaEnlace;
            worksheet.Cell(row, 33).Value = altaModificacion.indicadorGenerado;
        }
    }
}
