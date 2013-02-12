using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Serialization;

using MobellaEventsForms.Models;

namespace MobellaEventsForms.Database
{
    public class FormsDb
    {
        public List<ClientInfoModel> ClientInfoModels { get; set; }

        private const string FileSubDirectory = @"Database\";
        private const string FileName = @"FormsDb.xml";

        private readonly string _fullFilePath;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(ClientInfoModel[]));

        public FormsDb(string serverRootPath)
        {
            var fileDirectory = Path.Combine(serverRootPath, FileSubDirectory);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            _fullFilePath = Path.Combine(fileDirectory, FileName);
            using (var fileStream = new FileStream(_fullFilePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length > 0)
                {
                    var modelsArray = _xmlSerializer.Deserialize(fileStream) as ClientInfoModel[];
                    ClientInfoModels = modelsArray != null ? new List<ClientInfoModel>(modelsArray) : new List<ClientInfoModel>();
                }
                else
                {
                    ClientInfoModels = new List<ClientInfoModel>
                        {
                            new ClientInfoModel
                                {
                                    Id = 1,
                                    PrimaryContactTitle = Title.Bride,
                                    PrimaryContact = "Bonnie Elmendorf",
                                    FianceTitle = Title.Groom,
                                    Fiance = "Paul Dutka",
                                    Phone = "(727) 698-7950",
                                    Email = "bonnieelmendorf@gmail.com",
                                    WeddingDate = new DateTime(2013,4,28),
                                    WeddingLocations = "St. Luke's / The MEZZ",
                                    NumberOfGuests = 80,
                                    Interests = new ClientInterestsModel
                                    {
                                        GettingStarted = true,
                                        WrappingItUp = false,
                                        DayOfCoordination = true,
                                        LiteCoordination = false,
                                        FullServiceCoordination = true,
                                        CandyBuffet = true,
                                        SignUp = true,
                                        PriceList = true,
                                        AdditionalQuestions = "Why is Mobella Events so AWESOME?!"
                                    }
                                }
                        };
                }
            }
        }

        public void SaveChanges()
        {
            using (var fileStream = new FileStream(_fullFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                _xmlSerializer.Serialize(fileStream, ClientInfoModels.ToArray());
            }
        }
    }
}