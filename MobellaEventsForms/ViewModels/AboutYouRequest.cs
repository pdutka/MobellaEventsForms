using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MobellaEventsForms.Models;

namespace MobellaEventsForms.ViewModels
{
    public class AboutYouRequest : IValidatableObject
    {
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