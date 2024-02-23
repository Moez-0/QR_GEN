using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

//licence key for


namespace PDF
{
    
    public class GeneratePDF
    {
        
        private byte[] bytes;
        
        public GeneratePDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);

                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(15));
                });
            });
            
            var bytes = document.GeneratePdf();
            this.bytes = bytes;
            Console.WriteLine(bytes);
            System.IO.File.WriteAllBytes("output.pdf", bytes);
 
        }
        public byte[] getBytes()
        {
            return this.bytes;
        }

    }
}
