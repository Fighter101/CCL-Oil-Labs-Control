using System;
using System.Collections.Generic;
using CCL_Oil_Labs_Control.Model;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using System.Diagnostics;

namespace CCL_Oil_Labs_Control.Utils
{
    public static class pdfCreator
    {

        private static Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Sample Analysis";

            
            DefineStyles();
            
            CreatePage();
            
            FillContent();
            
            return document;
        }

        public static void createPDF(string stationName , DateTime importNumber , DateTime analysisDate , IList<Transformer> transformers , string evaluation)
        {
            Document document = CreateDocument();
            document.UseCmykColor = true;
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            // Save the document...
            const string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);

        }

    }
}
