using System.Linq;
using System.Web.Mvc;
using MobellaEventsForms.Database;
using MobellaEventsForms.Models;
using MobellaEventsForms.ViewModels;

namespace MobellaEventsForms.Controllers
{
    public class ShowController : Controller
    {
        private FormsDb _db;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var serverRootPath = Server.MapPath("~");
            _db = new FormsDb(serverRootPath);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutYou(int? clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null)
            {
                var aboutYou = new AboutYouRequest
                    {
                        PrimaryContactTitle = client.PrimaryContactTitle,
                        PrimaryContact = client.PrimaryContact,
                        FianceTitle = client.FianceTitle,
                        Fiance = client.Fiance,
                        Phone = client.Phone,
                        Email = client.Email,
                        WeddingDate = client.WeddingDate,
                        WeddingLocations = client.WeddingLocations,
                        NumberOfGuests = client.NumberOfGuests,
                    };

                return View(aboutYou);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AboutYou(int? clientId, AboutYouRequest aboutYou)
        {
            if (ModelState.IsValid)
            {
                var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
                if (client == null)
                {
                    client = new ClientInfoModel { Id = _db.ClientInfoModels.Count + 1 };
                    _db.ClientInfoModels.Add(client);
                }
                clientId = client.Id;
                client.PrimaryContactTitle = aboutYou.PrimaryContactTitle;
                client.PrimaryContact = aboutYou.PrimaryContact;
                client.FianceTitle = aboutYou.FianceTitle;
                client.Fiance = aboutYou.Fiance;
                client.Phone = aboutYou.Phone;
                client.Email = aboutYou.Email;
                client.WeddingDate = aboutYou.WeddingDate;
                client.WeddingLocations = aboutYou.WeddingLocations;
                client.NumberOfGuests = aboutYou.NumberOfGuests;
                _db.SaveChanges();

                return RedirectToAction("ScheduleConsultation", new { clientId = clientId.Value });
            }

            return View(aboutYou);
        }

        [HttpGet]
        public ActionResult AboutUs(int clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null)
            {
                var aboutUs = new AboutUsRequest
                {
                    GettingStarted = client.Interests.GettingStarted,
                    WrappingItUp = client.Interests.WrappingItUp,
                    DayOfCoordination = client.Interests.DayOfCoordination,
                    LiteCoordination = client.Interests.LiteCoordination,
                    FullServiceCoordination = client.Interests.FullServiceCoordination,
                    CandyBuffet = client.Interests.CandyBuffet,
                    SignUp = client.Interests.SignUp,
                    PriceList = client.Interests.PriceList,
                    AdditionalQuestions = client.Interests.AdditionalQuestions,
                };

                return View(aboutUs);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AboutUs(int clientId, AboutUsRequest aboutUs)
        {
            if (ModelState.IsValid)
            {
                var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
                if (client != null)
                {
                    client.Interests = new ClientInterestsModel
                        {
                            GettingStarted = aboutUs.GettingStarted,
                            WrappingItUp = aboutUs.WrappingItUp,
                            DayOfCoordination = aboutUs.DayOfCoordination,
                            LiteCoordination = aboutUs.LiteCoordination,
                            FullServiceCoordination = aboutUs.FullServiceCoordination,
                            CandyBuffet = aboutUs.CandyBuffet,
                            SignUp = aboutUs.SignUp,
                            PriceList = aboutUs.PriceList,
                            AdditionalQuestions = aboutUs.AdditionalQuestions
                        };
                    _db.SaveChanges();

                    return RedirectToAction("ScheduleConsultation", new { clientId });
                }
            }

            return View(aboutUs);
        }

        [HttpGet]
        public ActionResult ScheduleConsultation(int clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null && client.ScheduleConsultation != null)
            {
                var scheduleConsultation = new ScheduleConsultationRequest
                    {
                        When = client.ScheduleConsultation.When,
                        OnDateTime = client.ScheduleConsultation.OnDateTime,
                        DaysOfTheWeek = client.ScheduleConsultation.DaysOfTheWeek,
                        TimesOfTheDay = client.ScheduleConsultation.TimesOfTheDay,
                        AdditionalPreferences = client.ScheduleConsultation.AdditionalPreferences,
                    };

                return View(scheduleConsultation);
            }

            return View();
        }

        [HttpPost]
        public ActionResult ScheduleConsultation(int clientId, ScheduleConsultationRequest scheduleConsultation)
        {
            if (ModelState.IsValid)
            {
                var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
                if (client != null)
                {
                    client.ScheduleConsultation = new ScheduleConsultationModel
                        {
                            When = scheduleConsultation.When,
                            OnDateTime = scheduleConsultation.OnDateTime,
                            DaysOfTheWeek = scheduleConsultation.DaysOfTheWeek,
                            TimesOfTheDay = scheduleConsultation.TimesOfTheDay,
                            AdditionalPreferences = scheduleConsultation.AdditionalPreferences
                        };
                    _db.SaveChanges();

                    return RedirectToAction("ThanksForVisiting", new { clientId });
                }
            }

            return View(scheduleConsultation);
        }

        [HttpGet]
        public ActionResult ThanksForVisiting(int clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null)
            {
                var aboutYou = new AboutYouRequest
                {
                    PrimaryContactTitle = client.PrimaryContactTitle,
                    PrimaryContact = client.PrimaryContact,
                    FianceTitle = client.FianceTitle,
                    Fiance = client.Fiance,
                    Phone = client.Phone,
                    Email = client.Email,
                    WeddingDate = client.WeddingDate,
                    WeddingLocations = client.WeddingLocations,
                    NumberOfGuests = client.NumberOfGuests,
                };

                return View(aboutYou);
            }

            return View();
        }

        [HttpGet]
        public ActionResult MobellaNotes(int clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null)
            {
                var mobellaNotes = new MobellaNotesRequest
                    {
                        AdditionalNotes = client.AdditionalNotes
                    };

                return View(mobellaNotes);
            }

            return View();
        }

        [HttpPost]
        public ActionResult MobellaNotes(int clientId, MobellaNotesRequest mobellaNotes)
        {
            if (ModelState.IsValid)
            {
                var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
                if (client != null)
                {
                    client.AdditionalNotes = mobellaNotes.AdditionalNotes;
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(mobellaNotes);
        }
    }
}
