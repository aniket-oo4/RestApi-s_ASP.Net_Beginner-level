using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace MvcApplication1.Auth
{
public static class CustomJwtHandler
    {
        private static string Secret = "MYAPI_SECRET_DONT_REVEAL_TO_ANYONE";

        public static string GenerateToken(string username, string role, int expirationMinutes = 20)
        {
            var header = new { alg = "HS256", typ = "JWT" };
            var payload = new Dictionary<string, object>
            {
                { "sub", username },
                { "role", role },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(expirationMinutes) }
            };

            var headerJson = Newtonsoft.Json.JsonConvert.SerializeObject(header);
            var payloadJson = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            var headerBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(headerJson));
            var payloadBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(payloadJson));

            var unsignedToken = headerBase64 + "." + payloadBase64;
            var signature = ComputeSignature(unsignedToken, Secret);

            return unsignedToken + "." + signature;
        }

        public static ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                var parts = token.Split('.');
                if (parts.Length != 3)
                    return null;

                var header = parts[0];
                var payload = parts[1];
                var cryptoSignature = parts[2];

                var headerJson = Encoding.UTF8.GetString(Base64UrlDecode(header));
                var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));

                var payloadData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(payloadJson);

                var signatureCheck = ComputeSignature(header + "." + payload, Secret);
                if (cryptoSignature != signatureCheck)
                    return null;

                if (payloadData.ContainsKey("exp"))
                {
                    var expiration = Convert.ToDateTime(payloadData["exp"]);
                    if (expiration <= DateTimeOffset.UtcNow)
                        return null;
                }

                var claims = new List<Claim>();
                if (payloadData.ContainsKey("sub"))
                    claims.Add(new Claim(ClaimTypes.Name, payloadData["sub"].ToString()));
                if (payloadData.ContainsKey("role"))
                    claims.Add(new Claim(ClaimTypes.Role, payloadData["role"].ToString()));

                return new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
            }
            catch
            {
                return null;
            }
        }

        private static string ComputeSignature(string input, string secret)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Base64UrlEncode(hash);
            }
        }

        private static string Base64UrlEncode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0];
            output = output.Replace('+', '-');
            output = output.Replace('/', '_');
            return output;
        }

        private static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+');
            output = output.Replace('_', '/');
            switch (output.Length % 4)
            {
                case 0: break;
                case 2: output += "=="; break;
                case 3: output += "="; break;
                default: throw new Exception("Illegal base64url string!");
            }
            return Convert.FromBase64String(output);
        }
    }
}