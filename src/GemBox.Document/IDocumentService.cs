namespace GemboxDocument
{
    public interface IDocumentService
    {
        Stream ConvertWordDocumentToPdf(Stream wordFileStream);
    }
}
