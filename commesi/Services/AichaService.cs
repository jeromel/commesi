using commesi.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace commesi.Services
{
    public class AichaService : IAichaService
    {
        private IHostingEnvironment _env;

        public IList<AichaDocument> Documents { get; set; }

        public AichaService(IHostingEnvironment env)
        {
            _env = env;

            LoadDocuments();
        }

        private void LoadDocuments()
        {
            Documents = new List<AichaDocument>();

            string txt = File.ReadAllText(Path.Combine(_env.WebRootPath,"aicha.json"));

            Documents = JsonConvert.DeserializeObject<IList<AichaDocument>>(txt);
        }

        public AichaDocument GetDocumentByPreviousSentence(string previousSentence)
        {
            return Documents.FirstOrDefault(x => x.PreviousSentence == previousSentence);
        }
    }
}
