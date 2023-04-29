using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GTERP.Services
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool RequiresTwoFactor { get; set; }

        public string JWToken { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }

        public List<Company> Companies { get; set; }
        public List<Product> Products { get; set; }


    }

    public class ResponseObject
    {
        public int Id { get; set; }
        public Microsoft.AspNetCore.Identity.SignInResult Result { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }

        public Company Companie { get; set; }
        public List<Product> Products { get; set; }

    }
    public class Company
    {
        public Guid ComId { get; set; }
        public string CompanyName { get; set; }

        public static explicit operator Company(List<JToken> v)
        {
            throw new NotImplementedException();
        }
    }
    public class Product
    {
        public Guid ProductId { get; set; }
        public int VersionId { get; set; }
        public string VersionName { get; set; }
    }
}
