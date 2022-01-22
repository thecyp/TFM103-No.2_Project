using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TwenGo.Models.Repository.Entity
{
    public class RecaptchaHelper
    {
        private readonly RecaptchaOption _settings;
        public RecaptchaHelper(IOptions<RecaptchaOption> setting) 
        {
            _settings = setting.Value;
        }

        public RecaptchaResponse ValidateCaptcha(string response) 
        {
           
            using(var client=new WebClient()) 
            {
                string secret = _settings.ReCAPTCHA_Secret_Key;
                string url = $"{_settings.Url}secret={secret}&response={response}";
                var result = client.DownloadString(url);

                try
                {
                    var data = JsonConvert.DeserializeObject<RecaptchaResponse>(result.ToString());
                    return data;
                }
                catch (Exception)
                {

                    return default(RecaptchaResponse);
                }
            }
           
        }
    }
}
