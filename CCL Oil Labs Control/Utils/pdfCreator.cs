using System;
using System.Collections.Generic;
using CCL_Oil_Labs_Control.Model;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;

namespace CCL_Oil_Labs_Control.Utils
{
    public static class pdfCreator
    {

        private static Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Sample Analysis";


            //DefineStyles();

            //CreatePage();

            // FillContent();

            return document;
        }

        public static void createPDF(string stationName, DateTime importNumber, DateTime analysisDate, IList<Transformer> transformers, string evaluation)
        {
            try
            {
                // Create a MigraDoc document
                Document document = new Document();

                // Each MigraDoc document needs at least one section.
                Section section = document.AddSection();

                // Put a logo in the header
                Paragraph header = section.Headers.Primary.AddParagraph();

                header.AddText("Central Chemical Laboratories");
                header.AddLineBreak();
                header.AddText("General Management for Oil Analysis");
                header.AddLineBreak();
                header.AddText("Transformer Oil Testing Laboratory");
                header.Format.Font.Size = 12;
                header.Format.Alignment = ParagraphAlignment.Center;

                TextFrame titleFrame = section.AddTextFrame();
                titleFrame.Height = "1.0cm";
                titleFrame.Width = "7.0cm";
                titleFrame.Left = ShapePosition.Center;
                titleFrame.RelativeHorizontal = RelativeHorizontal.Page;
                //titleFrame.Top = "5.0cm";
                //titleFrame.RelativeVertical = RelativeVertical.Page;

                TextFrame sampleInfoFrame = section.AddTextFrame();
                sampleInfoFrame.Height = "3.0cm";
                sampleInfoFrame.Width = "7.0cm";
                sampleInfoFrame.Left = ShapePosition.Left;
                sampleInfoFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                sampleInfoFrame.RelativeVertical = RelativeVertical.Line;
                Paragraph sampleInfoFrameParagraph = sampleInfoFrame.AddParagraph();
                sampleInfoFrameParagraph.Format.Font.Size = 12;
                sampleInfoFrameParagraph.Format.Font.Bold = true;
                sampleInfoFrameParagraph.AddText("Sample Source:");
                sampleInfoFrameParagraph.AddLineBreak();
                sampleInfoFrameParagraph.AddText("Sample Date:");
                sampleInfoFrameParagraph.AddLineBreak();
                sampleInfoFrameParagraph.AddText("Analysis Date:");


                // Create the item table
                Table table = section.AddTable();
                table.Style = "Table";
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;

                // Before you can add a row, you must define the columns
                Column column;

                column = table.AddColumn("3.5cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column = table.AddColumn("2.1cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column = table.AddColumn("2.1cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column = table.AddColumn("2.1cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column = table.AddColumn("2.1cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                column = table.AddColumn("2.1cm");
                column.Format.Alignment = ParagraphAlignment.Center;

                // Create the header of the table
                Row row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Cells[1].AddParagraph("Standard Method");
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[5].AddParagraph("Acting Test");
                row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[5].VerticalAlignment = VerticalAlignment.Center;

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Specific Gravity at 15 ºC");
                row.Cells[1].AddParagraph("ASTM D1298");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.SG?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.SG?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.SG?.ToString());


                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Color");
                row.Cells[1].AddParagraph("ASTM D1500");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.COL?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.COL?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.COL?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Water  Content ppm at 20 ºC");
                row.Cells[1].AddParagraph("BS 148 IEC 60733");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.WA?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.WA?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.WA?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Impurities");
                row.Cells[1].AddParagraph("ASTM D1796");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.IMP?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.IMP?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.IMP?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Total Acidity (mg KOH/g oil)");
                row.Cells[1].AddParagraph("ASTM D974 IP 1");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.IPI?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.IPI?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.IPI?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Break down Voltage Kv /2.5 mm");
                row.Cells[1].AddParagraph("IEC 60156");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.KV?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.KV?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.KV?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Power Factor at 90 ºC");
                row.Cells[1].AddParagraph("ASTM D924");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.PF?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.PF?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.PF?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Inter Facial Tension dyne/cm");
                row.Cells[1].AddParagraph("ASTM D971");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.ST?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.ST?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.ST?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Kinematics Viscosity (CST) at 40 ºC");
                row.Cells[1].AddParagraph("ASTM D445");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.KI?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.KI?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.KI?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Flash Point open ºC");
                row.Cells[1].AddParagraph("ASTM D92");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.FL?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.FL?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.FL?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Copper Corrosion");
                row.Cells[1].AddParagraph("ASTM D130");
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(transformers[1]?.CO?.ToString());
                row.Cells[3].AddParagraph(transformers[2]?.CO?.ToString());
                row.Cells[4].AddParagraph(transformers[3]?.CO?.ToString());

                row = table.AddRow();
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Evaluation");
                row.Cells[1].MergeRight = 4;
                // row.Cells[2] : row.Cells[5] data
                row.Cells[2].AddParagraph(evaluation);
                row.Cells[3].AddParagraph(evaluation);
                row.Cells[4].AddParagraph(evaluation);


                TextFrame signatureFrame = section.AddTextFrame();
                signatureFrame.Left = ShapePosition.Center;
                signatureFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                signatureFrame.RelativeVertical = RelativeVertical.Line;
                Paragraph signatureFrameParagraph = signatureFrame.AddParagraph();
                signatureFrameParagraph.Format.Font.Size = 12;
                signatureFrameParagraph.Format.Font.Bold = true;
                signatureFrameParagraph.AddText(" Manager of General Manager");
                signatureFrameParagraph.AddLineBreak();
                signatureFrameParagraph.AddText("Transformer Oils Lab of Oil Analysis Department\n");


                document.UseCmykColor = true;

                // Create a renderer for PDF that uses Unicode font encoding
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

                // Set the MigraDoc document
                pdfRenderer.Document = document;

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...
                string filename = "Report.pdf";
                // I don't want to close the document constantly...
                filename = "Report" + Guid.NewGuid().ToString("N").ToUpper() + ".pdf";
                pdfRenderer.Save(filename);
                // ...and start a viewer.
                Process.Start(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }

}
