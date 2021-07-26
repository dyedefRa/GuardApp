using GuardApp.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardApp.Helper;


namespace GuardApp.Helper
{
    public class ReportHelper
    {

        #region Declaration

        int totalColumn = 3;
        iTextSharp.text.Document document;
        iTextSharp.text.Font fontStyle;
        iTextSharp.text.pdf.PdfPTable pdfTable = new PdfPTable(3);
        iTextSharp.text.pdf.PdfPCell pdfCell;
        MemoryStream memoryStream = new MemoryStream();
        List<Personal> _personals = new List<Personal>();

        #endregion

        public byte[] PrepareReport(List<Personal> personals)
        {
            _personals = personals;

            #region

            document = new iTextSharp.text.Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(10f, 10f, 15f, 15f);
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            //pdfWriter.SetLanguage("tr-TR");

            document.Open();
            pdfTable.SetWidths(new float[] { 20f, 150f, 100f });
            #endregion

            this.ReportHeader();
            document.Add(pdfTable);

            this.ReportBody(DateTime.Now); // BURASI
            pdfTable.HeaderRows = 2;
            //document.AddLanguage("tr-TR");
            document.Close();
            return memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            AddRowLineForReportHeader("HİZMETE ÖZEL", 7f);
            AddRowLineForReportHeader("T.C.", 8f);
            AddRowLineForReportHeader("KARA KUVVETLERİ KOMUTANLIĞI", 10f);
            AddRowLineForReportHeader("Kıbrıs Türk Barış Kuvvetleri Komutanlığı", 8f);
            AddRowLineForReportHeader("Topçu Alay Komutanlığı", 8f);
            AddRowLineForReportHeader("\n", 8f);

        }

        private void AddRowLineForReportHeader(string text, float size)
        {
            fontStyle = FontFactory.GetFont("Tahoma", size, 1);
            pdfCell = new PdfPCell(new Phrase(text, fontStyle));
            pdfCell.Colspan = totalColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.WHITE;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
        }

        private void ReportBody(DateTime dateTime)
        {
            #region Table Header

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfCell = new PdfPCell(new Phrase("KTBK EŞREF BİTLİS KIŞLASI " + dateTime.TurkishDateTimeShortToString() + " AYI NÖBET ÇİZELGESİ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.WHITE;
            iTextSharp.text.pdf.PdfPTable pdfTableOneColoumn = new PdfPTable(1);
            pdfTableOneColoumn.AddCell(pdfCell);
            pdfTableOneColoumn.CompleteRow();
            document.Add(pdfTableOneColoumn);

            #endregion

            #region Table Body




            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfCell = new PdfPCell(new Phrase("NOBET ADI", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.WHITE;
            iTextSharp.text.pdf.PdfPTable pTGuardNameColoumn = new PdfPTable(1);
            pTGuardNameColoumn.AddCell(pdfCell);
            pTGuardNameColoumn.CompleteRow();
            document.Add(pTGuardNameColoumn);



            //10 COL TABLE
            iTextSharp.text.pdf.PdfPTable pdfTable10Coloumn = new PdfPTable(10);
            pdfTable10Coloumn.SetWidths(new float[] { 20f, 100f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 30f });

            pdfCell = new PdfPCell(new Phrase("S.No", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Kimlik", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("P.tesi", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Salı", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Çarş.", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Perş.", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cuma", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("C.tesi", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Pazar", fontStyle));
            pdfTable10Coloumn.AddCell(pdfCell);

            pdfTable10Coloumn.CompleteRow();
            document.Add(pdfTable10Coloumn);






            #endregion
        }


    }
}
