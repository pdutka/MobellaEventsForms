using System;

namespace MobellaEventsForms.Models
{
    public enum Title
    {
        Bride,
        Groom
    }

    public class ClientInfoModel
    {
        public virtual int Id { get; set; }

        public virtual Title PrimaryContactTitle { get; set; }
        public virtual string PrimaryContact { get; set; }
        public virtual Title? FianceTitle { get; set; }
        public virtual string Fiance { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime? WeddingDate { get; set; }
        public virtual string WeddingLocations { get; set; }
        public virtual int? NumberOfGuests { get; set; }

        public virtual ClientInterestsModel Interests { get; set; }

        public virtual ScheduleConsultationModel ScheduleConsultation { get; set; }

        public virtual string AdditionalNotes { get; set; }

        public virtual DateTime RequestDate { get; set; }
    }

    public class ClientInterestsModel
    {
        public virtual bool GettingStarted { get; set; }
        public virtual bool WrappingItUp { get; set; }
        public virtual bool DayOfCoordination { get; set; }
        public virtual bool LiteCoordination { get; set; }
        public virtual bool FullServiceCoordination { get; set; }
        public virtual bool CandyBuffet { get; set; }

        public virtual bool SignUp { get; set; }

        public virtual bool PriceList { get; set; }

        public virtual string AdditionalQuestions { get; set; }
    }

    public enum Schedule
    {
        Now,
        Later,
        Never
    }

    public enum TimeOfDay
    {
        Morning,
        Afternoon,
        Evening
    }

    public class ScheduleConsultationModel
    {
        public virtual Schedule When { get; set; }

        // Schedule - Now

        public virtual DateTime? OnDateTime { get; set; }

        // Schedule - Later

        public virtual DayOfWeek[] DaysOfTheWeek { get; set; }
        public virtual TimeOfDay[] TimesOfTheDay { get; set; }
        public virtual string AdditionalPreferences { get; set; }
    }
}