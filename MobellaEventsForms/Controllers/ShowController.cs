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
        public ActionResult Form(int? clientId)
        {
            var client = _db.ClientInfoModels.SingleOrDefault(x => x.Id == clientId);
            if (client != null)
            {
                var clientInfo = new ClientInfoRequest
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

                return View(clientInfo);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Form(int? clientId, ClientInfoRequest clientInfo)
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
                client.PrimaryContactTitle = clientInfo.PrimaryContactTitle;
                client.PrimaryContact = clientInfo.PrimaryContact;
                client.FianceTitle = clientInfo.FianceTitle;
                client.Fiance = clientInfo.Fiance;
                client.Phone = clientInfo.Phone;
                client.Email = clientInfo.Email;
                client.WeddingDate = clientInfo.WeddingDate;
                client.WeddingLocations = clientInfo.WeddingLocations;
                client.NumberOfGuests = clientInfo.NumberOfGuests;
                client.Interests = client.Interests ?? new ClientInterestsModel();
                client.Interests.GettingStarted = clientInfo.GettingStarted;
                client.Interests.WrappingItUp = clientInfo.WrappingItUp;
                client.Interests.DayOfCoordination = clientInfo.DayOfCoordination;
                client.Interests.LiteCoordination = clientInfo.LiteCoordination;
                client.Interests.FullServiceCoordination = clientInfo.FullServiceCoordination;
                client.Interests.CandyBuffet = clientInfo.CandyBuffet;
                client.Interests.SignUp = clientInfo.SignUp;
                client.Interests.PriceList = clientInfo.PriceList;
                client.Interests.AdditionalQuestions = clientInfo.AdditionalQuestions;
                _db.SaveChanges();

                return RedirectToAction("ScheduleConsultation", new { clientId = clientId.Value });
            }

            return View(clientInfo);
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
