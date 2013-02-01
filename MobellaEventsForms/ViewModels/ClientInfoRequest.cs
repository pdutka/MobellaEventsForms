using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MobellaEventsForms.Models;

namespace MobellaEventsForms.ViewModels
{
    public class ClientInfoRequest : IValidatableObject
    {
        // About the client...

        [DisplayName("Primary Contact Title")]
        public Title PrimaryContactTitle { get; set; }

        [DisplayName("Primary Contact")]
        [Required]
        public string PrimaryContact { get; set; }

        [DisplayName("Fiancé Title")]
        public Title? FianceTitle { get; set; }

        [DisplayName("Fiancé")]
        public string Fiance { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Wedding Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WeddingDate { get; set; }

        [DisplayName("Wedding Location(s)")]
        public string WeddingLocations { get; set; }

        [DisplayName("Number of Guests")]
        public int? NumberOfGuests { get; set; }

        // Interesting in...

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var field = new[] { "Phone", "Email" };

            if (string.IsNullOrWhiteSpace(Phone) &&
                string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Please provide either a phone number or email address, or both.", field);
            }
        }
    }
}