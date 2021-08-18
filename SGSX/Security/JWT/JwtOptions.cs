using System.Linq;
namespace SGSX.Security.JWT
{
    public class JwtOptions
    {
        public JwtOptions()
        {
            ExpirationTime = System.TimeSpan.FromMinutes(20);
            TokenId = System.Guid.NewGuid();
            CustomClaims = new System.Collections.Generic.SortedDictionary<string, string>();
        }

        public string SecretKey { get; init; }
        public string Issuer { get; init; }
        public string UniqueName { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Audience { get; init; }
        public string Subject { get; init; }

        public System.TimeSpan ExpirationTime { get; init; }

        public System.Guid TokenId { get; init; }

        public System.Collections.Generic.IReadOnlyDictionary<string,string> CustomClaims { get; init; }

        public void AddClaim(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) == true || string.IsNullOrWhiteSpace(value) == true)
            {
                return;
            }

            if (CustomClaims.ContainsKey(key) == false && IsSpecialKey(key) == false)
            {
                (CustomClaims as System.Collections.Generic.SortedDictionary<string,string>).Add(key, value);
            }
        }

        private bool IsSpecialKey(string key)
        {
            var fields = typeof(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy);
            var specialKeys = fields.Where(current => current.IsLiteral)
                .Select(x => x.GetRawConstantValue() as string).ToList();
            if (specialKeys.Any(current => current.ToLower() == key.ToLower()) == true)
            {
                return true;
            }
            return false;
        }

    }
}
