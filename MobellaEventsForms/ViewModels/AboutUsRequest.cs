using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobellaEventsForms.ViewModels
{
    public class AboutUsRequest
    {
        [DisplayName("Getting Started")]
        public bool GettingStarted { get; set; }

        [DisplayName("Wrapping It Up")]
        public bool WrappingItUp { get; set; }

        [DisplayName("Day of Coordination")]
        public bool DayOfCoordination { get; set; }

        [DisplayName("Lite Coordination")]
        public bool LiteCoordination { get; set; }

        [DisplayName("Full Service Coordination")]
        public bool FullServiceCoordination { get; set; }

        [DisplayName("Candy Buffet")]
        public bool CandyBuffet { get; set; }

        /// <summary>
        /// Sign up for mass emails.
        /// </summary>
        [DisplayName("Would you like to sign up for our newsletter?")]
        public bool SignUp { get; set; }

        [DisplayName("Request Price List")]
        public bool PriceList { get; set; }

        [DisplayName("Additional Questions")]
        [DataType(DataType.MultilineText)]
        public string AdditionalQuestions { get; set; }
    }
}