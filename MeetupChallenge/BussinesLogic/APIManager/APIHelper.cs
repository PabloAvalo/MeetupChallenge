using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BussinesLogic.APIManager
{
    public static class APIHelper
    {

        private static HttpClient ApiClient { get; set; }

        
        private static void InitializeApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient GetApiClient() {

            if (ApiClient == null) {
                
                InitializeApiClient();
            }
            
            return ApiClient;

        } 

        public static string MeetupUrl = "https://localhost:44372/api";

       

        //

  
    }
}
