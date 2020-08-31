using System;

namespace Kickoff.Models
{
    public class BaseDocumentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Guid UniqueKey { get; set; }

        public BaseDocumentModel() { }
    }
}
