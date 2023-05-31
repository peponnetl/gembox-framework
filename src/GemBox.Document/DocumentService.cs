using GemBox.Document;

namespace GemboxDocument
{
    public class DocumentService : IDocumentService
    {
        private readonly string _gemboxLicense;

        public DocumentService(string licenceKey)
        {
            _gemboxLicense = licenceKey;
        }

        public Stream ConvertWordDocumentToPdf(Stream wordFileStream)
        {
            // Set license key to use GemBox.Document 
            ComponentInfo.SetLicense(_gemboxLicense);

            var outputStream = new MemoryStream();

            using (var memoryStream = new MemoryStream())
            {
                var doc = DocumentModel.Load(wordFileStream, LoadOptions.DocxDefault);
                doc.Save(memoryStream, SaveOptions.PdfDefault);

                memoryStream.Position = 0;
                memoryStream.CopyTo(outputStream);
            }

            outputStream.Position = 0;
            return outputStream;
        }
    }

}