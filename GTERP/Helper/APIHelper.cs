﻿using GTERP.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GTERP.Helpers
{
    public static class APIHelper
    {
        public static async Task<T> GetRequest<T>(string uri, bool requireToken)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    if (requireToken)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.JWToken);
                    }

                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<T>(responseBody);
                    }
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static async Task<TOut> PostRequest<TIn, TOut>(string uri, TIn content, bool requireToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (requireToken)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.JWToken);
                    }

                    var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await client.PostAsync(uri, serialized))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<TOut>(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return JsonConvert.DeserializeObject<TOut>("");
        }

        public static async Task GetVoidRequest(string uri, bool requireToken)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    if (requireToken)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.JWToken);
                    }

                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static async Task PostVoidRequest<TIn>(string uri, TIn content, bool requireToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (requireToken)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.JWToken);
                    }

                    var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await client.PostAsync(uri, serialized))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
