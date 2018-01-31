using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CalculatorService
{
    public class GetDataObject<T>
    {
        readonly string _path;
        public GetDataObject(string path) => _path = path;

        public T MakeCall()
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create (_path);  
            
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;  

            // Get the response.  
            WebResponse response = request.GetResponse ();  

            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream ();  

            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader (dataStream); 

            // Read the content.  
            string responseFromServer = reader.ReadToEnd();  

            // Clean up the streams and the response.  
            reader.Close ();  
            response.Close ();

            return JsonConvert.DeserializeObject<T>(responseFromServer);
        }
    }
}