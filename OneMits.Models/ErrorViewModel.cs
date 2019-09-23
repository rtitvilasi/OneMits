using System;

namespace OneMits.Models
{
    public class ErrorViewModel : LayoutBaseModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
