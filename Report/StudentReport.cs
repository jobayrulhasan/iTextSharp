using iTextSharp.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace iTextSharp.Report
{
    public class StudentReport
    {
        #region Declaration
        int totalColam = 4;
        Document document;
        Font fontStyle;
        PdfPTable PdfPTable = new PdfPTable(4);
        PdfPCell PdfPCell;
        MemoryStream memoryStream = new MemoryStream();
        List<Student> students = new List<Student>();
        #endregion
        public byte[] PrepareReport(List<Student> _students)
        {
            _students = students;
            #region PagesetUp
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);
            PdfPTable.WidthPercentage = 100;
            PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1); //8f font size and 1 is color that means it bolt
            PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            PdfPTable.SetWidths(new float[] { 20f, 150f, 100f, 100f }); //20f for serial no , 150f for Name,100f for Roll and 100f for department
            #endregion

            this.ReportHeader();
            this.ReportBody();
            PdfPTable.HeaderRows = 2;
            document.Add(PdfPTable);
            document.Close();
            return memoryStream.ToArray();
        }
        private void ReportHeader()
        {
            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell = new PdfPCell(new Phrase("My University Name", fontStyle));
            PdfPCell.Colspan = totalColam;
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.Border = 0;
            PdfPCell.BackgroundColor = BaseColor.WHITE;
            PdfPCell.ExtraParagraphSpace = 0;
            PdfPTable.AddCell(PdfPCell);
            PdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfPCell = new PdfPCell(new Phrase("Student List", fontStyle));
            PdfPCell.Colspan = totalColam;
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.Border = 0;
            PdfPCell.BackgroundColor = BaseColor.WHITE;
            PdfPCell.ExtraParagraphSpace = 0;
            PdfPTable.AddCell(PdfPCell);
            PdfPTable.CompleteRow();
        }
        private void ReportBody()
        {
            #region table header
            //col-1
            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell = new PdfPCell(new Phrase("Serial Number", fontStyle));
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPTable.AddCell(PdfPCell);
            //col-2
            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell = new PdfPCell(new Phrase("Name", fontStyle));
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPTable.AddCell(PdfPCell);
            //col-3
            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell = new PdfPCell(new Phrase("Roll", fontStyle));
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPTable.AddCell(PdfPCell);
            //col-4
            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell = new PdfPCell(new Phrase("Department", fontStyle));
            PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            PdfPTable.AddCell(PdfPCell);
            PdfPTable.CompleteRow();
            #endregion

            #region Table body
            fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNo = 1;
            foreach (Student std in students)
            {
                PdfPCell = new PdfPCell(new Phrase(serialNo++.ToString(), fontStyle));
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell.BackgroundColor = BaseColor.WHITE;
                PdfPTable.AddCell(PdfPCell);

                PdfPCell = new PdfPCell(new Phrase(std.Name, fontStyle));
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell.BackgroundColor = BaseColor.WHITE;
                PdfPTable.AddCell(PdfPCell);

                PdfPCell = new PdfPCell(new Phrase(std.Roll, fontStyle));
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell.BackgroundColor = BaseColor.WHITE;
                PdfPTable.AddCell(PdfPCell);

                PdfPCell = new PdfPCell(new Phrase(std.Department, fontStyle));
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                PdfPCell.BackgroundColor = BaseColor.WHITE;
                PdfPTable.AddCell(PdfPCell);
                PdfPTable.CompleteRow();
            }
            #endregion
        }
    }
}