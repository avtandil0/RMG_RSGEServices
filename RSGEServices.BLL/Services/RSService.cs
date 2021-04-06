using RSGEServices.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RSGEServices.BLL.Services
{
    public class RSService
    {
        public async Task<User> RsLogin(string AuthKey)
        {
            string SecretKey = "143cfd29-6519-f01f-0d55-b6793e4ef2af";

            string RequestString = string.Format("https://eservices.rs.ge/WebServices/oAuth.ashx" + "?SecretKey={0}&AuthKey={1}", SecretKey, AuthKey);

            WebRequest request = WebRequest.Create(RequestString);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            var vasd = ((HttpWebResponse)response).StatusDescription;
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string rsResponse = reader.ReadToEnd();
            var soap = XDocument.Parse(rsResponse);

            XmlSerializer s = new XmlSerializer(typeof(User));
            var user = (User)s.Deserialize(soap.CreateReader());
            reader.Close();
            response.Close();

            return user;
        }
    }
}
