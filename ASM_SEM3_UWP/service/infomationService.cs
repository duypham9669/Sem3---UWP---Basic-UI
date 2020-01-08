using ASM_SEM3_UWP.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASM_SEM3_UWP.service
{
    class infomationService
    {
        private static readonly string MemberInformationApiUrl = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/information";
        public async Task<user> GetMemberInformation(string token)
        {
            // gọi shipper
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            // gửi đến đây (link), món quà này (contentToSend), chờ quá trình gửi thành công, thì lấy xác nhận từ người nhận.
            var response = await httpClient.GetAsync(MemberInformationApiUrl);
            // đọc dữ liệu response từ người nhận.
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<user>(stringContent);
            }
            return null;
        }
    }
}
