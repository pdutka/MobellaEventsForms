using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobellaEventsForms.ViewModels
{
    /// <summary>
    /// Our internal notes about the client.
    /// </summary>
    public class MobellaNotesRequest
    {
        [DisplayName("Additional Notes")]
        [DataType(DataType.MultilineText)]
        public string AdditionalNotes { get; set; }
    }
}