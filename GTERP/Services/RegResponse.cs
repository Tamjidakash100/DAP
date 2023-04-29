using GTERP.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GTERP.Services
{
    public class RegResponse
    {
        public bool Succeeded { get; set; }
        public List<APIErrorDto> Errors { get; set; }
        public string OTP { get; set; }
    }

    public class GetResponse
    {

        public GetResponse(string json)
        {

            if (json != null)
            {
                JObject jObject = JObject.Parse(json);

                string data = jObject["MyUsers"].ToString();
                string data2 = jObject["Companies"].ToString();

                MyResponse Response = JsonConvert.DeserializeObject<MyResponse>(json);
                MyUsers = Response.MyUsers;
                Companies = Response.Companies;

            }
        }
        public ICollection<MyUser> MyUsers { get; set; }
        public ICollection<Company> Companies { get; set; }

    }
    //{"myUsers":[{"userID":"c7c1b283-14af-4fec-a877-3c13d151955b","userName":"shariat@gmail.com"}],"companies":[{"comId":"dapa26-414a-44e4-a287-18e846b51d99","companyName":"DAP"}]}

}
public class RegError
{
    public string Code { get; set; }
    public string Description { get; set; }
}
public class MyUser
{
    public string UserID { get; set; }
    public string UserName { get; set; }

}
public class MyUserMenuPermission
{
    public string useridPermission { get; set; }
    public string UserName { get; set; }

}
public class MyResponse
{
    public ICollection<MyUser> MyUsers { get; set; }
    public ICollection<Company> Companies { get; set; }

}


public class APIErrorDto
{
    public string Key { get; set; }
    public string Error { get; set; }
}





