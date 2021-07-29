using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static GuardApp.Helper.PDFHelper;

namespace GuardApp.Helper
{
    public class ReportHelper
    {

        #region Declaration

        int totalColumn = 3;
        iTextSharp.text.Document document;
        iTextSharp.text.Font fontStyle = new iTextSharp.text.Font(BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED), 12, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.pdf.PdfPTable pdfTable = new PdfPTable(3);
        iTextSharp.text.pdf.PdfPCell pdfCell;
        MemoryStream memoryStream = new MemoryStream();
        List<PDFHelperViewModal> _pdfModalList = new List<PDFHelperViewModal>();

        #endregion

        public byte[] PrepareReport(List<PDFHelperViewModal> pdfModalList)
        {
            _pdfModalList = pdfModalList.OrderBy(x => x.GuardNumber).ToList();

            #region

            document = new iTextSharp.text.Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(10f, 10f, 15f, 15f);
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            pdfTable.SetWidths(new float[] { 20f, 150f, 100f });
            #endregion

            this.ReportHeader();
            document.Add(pdfTable);
            this.ReportBody();
            pdfTable.HeaderRows = 2;
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
            fontStyle.Size = size;
            pdfCell = new PdfPCell(new Phrase(text, fontStyle));
            pdfCell.Colspan = totalColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.WHITE;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
        }

        private void ReportBody()
        {
            string nextDateString = DateTime.Now.AddMonths(1).TurkishDateTimeShortToString();

            #region Table Header
            fontStyle.Size = 8f;
            pdfCell = new PdfPCell(new Phrase("KTBK EŞREF BİTLİS KIŞLASI " + nextDateString + " AYI NÖBET ÇİZELGESİ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.WHITE;
            iTextSharp.text.pdf.PdfPTable pdfTableOneColoumn = new PdfPTable(1);
            pdfTableOneColoumn.AddCell(pdfCell);
            pdfTableOneColoumn.CompleteRow();
            document.Add(pdfTableOneColoumn);

            #endregion

            #region Table Body
            foreach (var _pdfModal in _pdfModalList)
            {
                pdfCell = new PdfPCell(new Phrase(_pdfModal.GuardName, fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.WHITE;
                iTextSharp.text.pdf.PdfPTable pTGuardNameColoumn = new PdfPTable(1);
                pTGuardNameColoumn.AddCell(pdfCell);
                pTGuardNameColoumn.CompleteRow();
                document.Add(pTGuardNameColoumn);

                #region pdfTableInformationAndMonthName

                iTextSharp.text.pdf.PdfPTable pdfTableInformationAndMonthName = new PdfPTable(10);
                pdfTableInformationAndMonthName.SetWidths(new float[] { 20f, 100f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 30f });

                pdfCell = new PdfPCell(new Phrase("S.No", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Kimlik", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("P.tesi", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Salı", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Çarş.", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Perş.", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Cuma", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("C.tesi", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase("Pazar", fontStyle));
                pdfTableInformationAndMonthName.AddCell(pdfCell);

                pdfTableInformationAndMonthName.CompleteRow();
                document.Add(pdfTableInformationAndMonthName);

                #endregion

                #region Best Table For Month

                fontStyle.Size = 6f;

                int rank = 1;
                foreach (var _pdfModalPersonal in _pdfModal.PersonalGuardList.OrderBy(x => x.RankNumber))
                {
                    iTextSharp.text.pdf.PdfPTable pdfTablePersonMonth = new PdfPTable(10);
                    pdfTablePersonMonth.SetWidths(new float[] { 20f, 100f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 30f });

                    pdfCell = new PdfPCell(new Phrase(rank.ToString(), fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(_pdfModalPersonal.PersonalInformation, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    #region Days

                    var monday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "1");
                    var mondayGuards = monday != null ? monday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(mondayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var tuesday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "2");
                    var tuesdayGuards = tuesday != null ? tuesday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(tuesdayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var wednesday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "3");
                    var wednesdayGuards = wednesday != null ? wednesday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(wednesdayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var thursday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "4");
                    var thursdayGuards = thursday != null ? thursday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(thursdayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var friday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "5");
                    var fridayGuards = friday != null ? friday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(fridayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var saturday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "6");
                    var saturdayGuards = saturday != null ? saturday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(saturdayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    var sunday = _pdfModalPersonal.DayNumbersAndGuardNumbers.FirstOrDefault(x => x.DayNumber == "0");
                    var sundayGuards = sunday != null ? sunday.GuardNumbers : "";
                    pdfCell = new PdfPCell(new Phrase(sundayGuards, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    #endregion

                    pdfCell = new PdfPCell(new Phrase(_pdfModalPersonal.PersonalUnityName, fontStyle));
                    pdfTablePersonMonth.AddCell(pdfCell);

                    pdfTablePersonMonth.CompleteRow();
                    document.Add(pdfTablePersonMonth);

                    rank++;
                }

                #endregion
            }

            #endregion
        }
    }
}
