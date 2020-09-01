using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAuthenticationExplorerUI.Converters
{
    /// <summary>
    /// Static Helper to convert JWT to human readable data
    /// </summary>
    public static class JWTConverter
    {
        public static string ConvertFromJWT(string jwtToken)
        {
            string tokenData = null;
            if (!jwtToken.StartsWith("eyJ"))
            {
                return "Invalid JWT-Token";
            }
            else
            {
                for(int i = 0; i<2; i++)
                { 
                    //Normalize the Tokendata
                    tokenData = jwtToken.Split('.')[i].Replace("-", "+").Replace("_", "/");
                    switch(tokenData.Length % 4)
                    {
                        case 0:
                            break;
                        case 2:
                            {
                                tokenData += "==";
                                break;
                            }
                        case 3:
                            {
                                tokenData += "=";
                                break;
                            }
                    }
                }
                var byteData = Convert.FromBase64String(tokenData);
                string readableToken = Encoding.UTF8.GetString(byteData);
                //Make the output nice and clean. 
                return Newtonsoft.Json.JsonConvert.DeserializeObject(readableToken).ToString();
            }
        }
    }
}
