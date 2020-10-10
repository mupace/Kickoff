namespace Kickoff.Models.Media
{
    public class FileModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public string FilePath { get; set; }

        public int Size { get; set; }

        public string Extension { get; set; }
    }
}