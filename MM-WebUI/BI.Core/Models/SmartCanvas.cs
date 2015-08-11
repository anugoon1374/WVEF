using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.Core.Models
{
    /// <summary>
    /// Class SmartCanvas.
    /// </summary>
    public class SmartCanvas
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public bool AutoApprove { get; set; }
        public List<string> MetaTags { get; set; }
        public ContentProvider ContentProvider { get; set; }
        public List<string> Categories { get; set; }
        public BusinessInfo JsonExtendedData { get; set; }
        public string Content { get; set; }
        public List<string> Attachments { get; set; }
    }

    /// <summary>
    /// Class ContentProvider.
    /// </summary>
    public class ContentProvider
    {
        public string ContentId { get; set; }
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
