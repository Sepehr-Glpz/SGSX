using System.Linq;
namespace SGSX.Security.JWT
{
    public static class JwtUtility
    {
        static JwtUtility()
        {
        }

        public static string CreateJwtToken(JwtOptions options)
        {
            //null checks
            if (options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }
            if (string.IsNullOrWhiteSpace(options.SecretKey))
            {
                throw new System.ArgumentNullException(nameof(options.SecretKey));
            }

            var claims = new System.Collections.Generic.List<System.Security.Claims.Claim>();
            foreach(var item in options.CustomClaims)
            {
                claims.Add(new System.Security.Claims.Claim(type: item.Key, value: item.Value));
            }
            claims = claims.SetClaims(options);

            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(options.SecretKey);

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secretKeyBytes);

            var signingCredentials = new
                    Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey,
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            #region TokenDescriptor and handler.Create() method
            //var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor();
            //tokenDescriptor.Audience = options.Audience;
            //tokenDescriptor.Issuer = options.Issuer;
            //tokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(claims);
            //tokenDescriptor.SigningCredentials = signingCredentials;
            //tokenDescriptor.Expires = System.DateTime.Now.Add(options.ExpirationTime);

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            #endregion

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(options.Issuer,
                                                                             options.Audience,
                                                                             claims,
                                                                             null,
                                                                             System.DateTime.Now.Add(options.ExpirationTime),
                                                                             signingCredentials);
            
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        //public static bool ValidateJwtToken(string token,)
        //{
        //    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

        //}

        private static System.Collections.Generic.List<System.Security.Claims.Claim> SetClaims(this System.Collections.Generic.List<System.Security.Claims.Claim> claims, JwtOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.UniqueName) == false)
            {
                claims.Add(
                    new System.Security.Claims.Claim(type: System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, value: options.UniqueName));
            }
            if (string.IsNullOrWhiteSpace(options.Subject) == false)
            {
                claims.Add(
                    new System.Security.Claims.Claim(type: System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, value: options.Subject));
            }
            if (string.IsNullOrWhiteSpace(options.Name) == false)
            {
                claims.Add(
                    new System.Security.Claims.Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, value: options.Name));
            }
            claims.Add(new System.Security.Claims.Claim(type: System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,
                value: options.TokenId.ToString()));

            return claims;
        }



    }
}
