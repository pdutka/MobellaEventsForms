using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MobellaEventsForms.Models;

namespace MobellaEventsForms.ViewModels
{
    public class ScheduleConsultationRequest : IValidatableObject
    {
        public Schedule When { get; set; }

        // Schedule - Now

        [DisplayName("Date & Time")]
        public DateTime? OnDateTime { get; set; }

        // Schedule - Later

        public DayOfWeek[] DaysOfTheWeek { get; set; }

        public TimeOfDay[] TimesOfTheDay { get; set; }

        [DisplayName("Additional Preferences")]
        [DataType(DataType.MultilineText)]
        public string AdditionalPreferences { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (When == Schedule.Now)
            {
                var field = new[] { "OnDateTime" };
                if (!OnDateTime.HasValue)
                {
                    yield return new ValidationResult("Please enter a valid date.", field);
                }
                else if (OnDateTime.Value <= DateTime.Today)
                {
                    yield return new ValidationResult("Please enter a date in the future.", field);
                }
            }

            if (When == Schedule.Later)
            {
                if (DaysOfTheWeek == null || DaysOfTheWeek.Length == 0)
                {
                    yield return new ValidationResult("Please enter at least one day.");
                }
                if (TimesOfTheDay == null || TimesOfTheDay.Length == 0)
                {
                    yield return new ValidationResult("Please enter at least one time.");
                }
            }
        }
    }
}