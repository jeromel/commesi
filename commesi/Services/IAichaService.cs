using commesi.Models;

namespace commesi.Services
{
    public interface IAichaService
    {
        AichaDocument GetDocumentByPreviousSentence(string previousSentence);
    }
}
