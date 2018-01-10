using HeroFormation.Interfaces.Services.CrimeService;
using HeroFormation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HeroFormation.Services
{
    public class CrimeService : ICrimeService
    {
        //The following method retrieves the previous 6 month's of Crime data from the UK Police API, based upon the COORDS parsed via a CoordinatesModel object
        [Authorize]
        public List<Crimes> GetPrevious6MonthsCrimesByLocationAndDate(CoordinatesModel model)
        {
            DateTime currentDate = DateTime.Now;
            DateTime month1 = currentDate.AddMonths(-1);
            DateTime month2 = month1.AddMonths(-1);
            DateTime month3 = month2.AddMonths(-1);
            DateTime month4 = month3.AddMonths(-1);
            DateTime month5 = month4.AddMonths(-1);
            DateTime month6 = month5.AddMonths(-1);

            int[] monthAndYear1 = GetPreviousMonthAndYearAsInts(month1);
            int[] monthAndYear2 = GetPreviousMonthAndYearAsInts(month2);
            int[] monthAndYear3 = GetPreviousMonthAndYearAsInts(month3);
            int[] monthAndYear4 = GetPreviousMonthAndYearAsInts(month4);
            int[] monthAndYear5 = GetPreviousMonthAndYearAsInts(month5);
            int[] monthAndYear6 = GetPreviousMonthAndYearAsInts(month6);

            int month1AsInt = monthAndYear1[0];
            int year1AsInt = monthAndYear1[1];

            int month2AsInt = monthAndYear2[0];
            int year2AsInt = monthAndYear2[1];

            int month3AsInt = monthAndYear3[0];
            int year3AsInt = monthAndYear3[1];

            int month4AsInt = monthAndYear4[0];
            int year4AsInt = monthAndYear4[1];

            int month5AsInt = monthAndYear5[0];
            int year5AsInt = monthAndYear5[1];

            int month6AsInt = monthAndYear6[0];
            int year6AsInt = monthAndYear6[1];

            string url1 = crimeUrlBuilder(year1AsInt, month1AsInt, model.Latitude, model.Longitude);
            string url2 = crimeUrlBuilder(year2AsInt, month2AsInt, model.Latitude, model.Longitude);
            string url3 = crimeUrlBuilder(year3AsInt, month3AsInt, model.Latitude, model.Longitude);
            string url4 = crimeUrlBuilder(year4AsInt, month4AsInt, model.Latitude, model.Longitude);
            string url5 = crimeUrlBuilder(year5AsInt, month5AsInt, model.Latitude, model.Longitude);
            string url6 = crimeUrlBuilder(year6AsInt, month6AsInt, model.Latitude, model.Longitude);

            List<Crimes> crimes = new List<Crimes>();

            Task<List<Crimes>> crimes1 = GetCrimesByLocationAndUrl(model, url1);
            List<Crimes> crime1 = new List<Crimes>();
            foreach (Crimes crime in crimes1.Result)
            {
                crimes.Add(crime);
            }

            Task<List<Crimes>> crimes2 = GetCrimesByLocationAndUrl(model, url2);
            foreach (Crimes crime in crimes2.Result)
            {
                crimes.Add(crime);
            }

            Task<List<Crimes>> crimes3 = GetCrimesByLocationAndUrl(model, url3);
            foreach (Crimes crime in crimes3.Result)
            {
                crimes.Add(crime);
            }

            Task<List<Crimes>> crimes4 = GetCrimesByLocationAndUrl(model, url4);
            foreach (Crimes crime in crimes4.Result)
            {
                crimes.Add(crime);
            }

            Task<List<Crimes>> crimes5 = GetCrimesByLocationAndUrl(model, url5);
            foreach (Crimes crime in crimes5.Result)
            {
                crimes.Add(crime);
            }

            Task<List<Crimes>> crimes6 = GetCrimesByLocationAndUrl(model, url6);
            foreach (Crimes crime in crimes6.Result)
            {
                crimes.Add(crime);
            }

            return crimes;



        }

        #region Private Methods
        //This method, is the method, that executes the HTTP GET request to the UK Police API. Its parameters are a CoordinatesModel model and the URL required to execute the GET. The crimes associated are returned as a Task list of the Crime class
        [HttpGet]
        private async Task<List<Crimes>> GetCrimesByLocationAndUrl(CoordinatesModel model, string Url)
        {


            List<Crimes> crimeInfo = new List<Crimes>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(Url);

                if (res.IsSuccessStatusCode)
                {
                    var criResponse = res.Content.ReadAsStringAsync().Result;
                    crimeInfo = JsonConvert.DeserializeObject<List<Crimes>>(criResponse);
                }

                return (crimeInfo);


            }




        }
        
        private int[] GetPreviousMonthAndYearAsInts(DateTime date)
        {
            int[] result = new int[2];

            DateTime currentDate = date;
            //Request crimes from the previous month, to allow for the Crime API to be updated
            DateTime date1 = currentDate.AddMonths(-1);
            
            int month = date1.Month;
            int year = date1.Year;

            result[0] = month;
            result[1] = year;

            return result;
        }

        private string crimeUrlBuilder(int year, int month, string Latitude, string Longitude)
        {
            string url = "https://data.police.uk/api/crimes-at-location?" +
                "date=" + year + "-" + month + "&" +
                "lat=" + Latitude + "&" +
                "lng=" + Longitude;

            return url;
        }
        #endregion

    }
}
