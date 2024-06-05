using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Coravel.Invocable;
using MoreMobile.Data.Repositories;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using MoreMobile.Resources.Core;

namespace MoreMobile.Application.Services
{
    public class SMSReminderService : IInvocable
    {
        private readonly IConfiguration _configuration;
        public IVisitDateRepository VisitDateRepository { get; set; }

        public SMSReminderService(IConfiguration configuration, IVisitDateRepository visitDateRepository)
        {
            VisitDateRepository = visitDateRepository;
            _configuration = configuration;
        }

        public async Task Invoke()
        {
            var smsConfig = _configuration.GetSection("SMSSettings").Get<SMSSettings>() ?? throw new Exception("Null");
            Uri uri = new Uri("https://api1.smeskom.pl");
            HttpClient http = new HttpClient();
            http.BaseAddress = uri;
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{smsConfig.Login}:{smsConfig.Password}")));

            var items = await VisitDateRepository.GetAllAsync();

            foreach (var item in items.Where(x => !x.ReminderSent && x.IsTimeToSendReminder))
            {
                var payload = new
                {
                    msisdn = item.Warranty.User.PhoneNumber,
                    body = string.Format(CoreResource.ReminderSMSMessage, item?.InspectionDate, smsConfig.Name)
                };

                var response = await http.PostAsync("/api/v1/sms/send", new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK && item != null)
                {
                    item.ReminderSent = true;
                    VisitDateRepository.Edit(item);
                    await VisitDateRepository.SaveAsync();
                }
            }
        }
    }
}