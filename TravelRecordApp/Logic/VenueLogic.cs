using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Result>> GetVenues(double latitude, double longitude)
        {
            List<Result> venues = new List<Result>();

            var url = Venue.GenerateUrl(latitude,longitude);

            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("Authorization", Constants.API_KEY);
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<Venue>(json);

                venues = venueRoot.results as List<Result>;
            }

            return venues;
        }
    }
}
