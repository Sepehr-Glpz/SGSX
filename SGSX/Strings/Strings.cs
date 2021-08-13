namespace SGSX.Strings
{
    public static class Strings
    {
        static Strings()
        {

        }
        /// <summary>
        /// Fixes most of the Commonly made mistakes when entering strings.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// A Fixed String without commonly made mistakes.
        /// </returns>
        public static string Fix(this string text)
        {
            if (string.IsNullOrWhiteSpace(text) == true)
            {
                return string.Empty;
            }
            text = text.Trim();
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            return text;
            
        }

        /// <summary>
        /// Method for getting the SHA256 hash of a string in hex
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetSHA256Hash(string text)
        {
            if (string.IsNullOrWhiteSpace(text) == true)
            {
                return string.Empty;
            }
            System.Security.Cryptography.SHA256 algorithm = null;
            try
            { 
                algorithm = System.Security.Cryptography.SHA256.Create();
                byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hashResultBytes = algorithm.ComputeHash(stringBytes);
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                foreach(byte item in hashResultBytes)
                {
                    stringBuilder.Append(item.ToString("X2"));
                }
                return stringBuilder.ToString();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if(algorithm != null)
                {
                    algorithm.Dispose();
                }
            }
        }




    }
}
