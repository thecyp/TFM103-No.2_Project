using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwenGo.Models.Repository.Entity
{
    public class RecaptchaOption
    {
        public string ReCAPTCHA_Site_Key { get; set; }

        public string ReCAPTCHA_Secret_Key { get; set; }

        public string Url { get; set; }
    }
}
