using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2.DescargarDatos
{
    public class PDFDownLoad
    {
        public void GenerarPDF(String ruta, String nombreArchivo, BindingSource binding, List<usuaris> _users) {
            PdfWriter pdfWriter = new PdfWriter(ruta+nombreArchivo);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            List<String> columnas = new List<string>();
            foreach (var miembro in binding)
            {
                columnas.Add(miembro.ToString());
            }

            List<float> tamanios = new List<float>();
            foreach (var campo in binding)
            {
                tamanios.Add(3f);
            }

            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios.ToArray()));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            foreach (var user in _users)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(user.id.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.nom.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.rols.nom.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.actiu.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.correu.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.contrasenia.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.any_naixement.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.telefono.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.dni.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.direccion.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(user.formacion.nom.ToString()).SetFont(fontContenido)));
            }

            documento.Add(tabla);
            documento.Close();
        }
    }
}
