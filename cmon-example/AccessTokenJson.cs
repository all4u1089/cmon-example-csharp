using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cmon_example
{
    public class AccessTokenJson
    {
        private string consumerKey;
        private string secretKey;
        private string tokenUrl;

        public AccessTokenJson()
        {
        }

        public AccessTokenJson(string consumerKey, string scretKey, string url)
        {
            this.consumerKey = consumerKey;
            this.secretKey = scretKey;
            this.tokenUrl = url;
        }

        /// <summary>
        /// Get token của system user
        /// </summary>
        /// <returns>Return token</returns>
        public async Task<ToKenResponse> GetToken()
        {
            if (consumerKey != null && secretKey != null)
            {
                if (tokenUrl != null && !string.IsNullOrEmpty(tokenUrl))
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(consumerKey + ":" + secretKey);
                    string keyBase64Encrypted = Convert.ToBase64String(plainTextBytes);

                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(tokenUrl);

                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", keyBase64Encrypted);

                        try
                        {
                            var content = new FormUrlEncodedContent(new[]
                            {
                                new KeyValuePair<string, string>("grant_type", "client_credentials")
                            });

                            var response = await httpClient.PostAsync("token", content);

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var strData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                var data = JsonConvert.DeserializeObject<ToKenResponse>(strData);

                                return data;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("error");
                            return null;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Token url must not be null");
                }
            }
            else
            {
                Console.WriteLine("Consumer key and scret key must not be null");
            }

            return null;
        }
    }

    /// <summary>
    /// ToKenResponse class
    /// </summary>
    public class ToKenResponse
    {
        /// <summary>
        /// Gets or Sets AccessToken
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or Sets ExpiresIn
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Gets or Sets TokenType
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
