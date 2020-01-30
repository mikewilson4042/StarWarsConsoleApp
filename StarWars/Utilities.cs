using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public static class Utilities
    {

        public static string GetPageNumber(string nextPage)
        {
            string pageString = "";
            try
            {
                int lastEqualIndex = nextPage.LastIndexOf('=');
                if (lastEqualIndex != -1)
                {
                    pageString = nextPage.Substring((lastEqualIndex + 1), (nextPage.Length - (lastEqualIndex + 1)));
                    return pageString;
                }
                else
                    return "";
            }
            catch
            {
                //returning empty will skip processing bad data
                return "";
            }

        }

        public static string GetIDNumber(string url)
        {
            try
            {
                string IdString = "";

                if (url.EndsWith("/"))
                    url = url.Substring(0, url.Length - 1);

                int lastSlashIndex = url.LastIndexOf('/');
                if (lastSlashIndex != -1)
                {
                    IdString = url.Substring((lastSlashIndex + 1), (url.Length - (lastSlashIndex + 1)));
                    return IdString;
                }
                else
                    return "";
            }
            catch
            {
                //returning empty will skip processing bad data
                return "";
            }

        }

        public static int ValidateCount(string entry)
        {
            try
            {
                int userPassengerRequirement;
                int.TryParse(entry, out userPassengerRequirement);
                if (userPassengerRequirement < 0)
                {
                    //any non-numeric value or number 0 or less will generate error
                    return 0;
                }
                return userPassengerRequirement;
            }
            catch
            {
                //any non-numeric value or number 0 or less will generate error
                return 0;
            }
        }
        public static int GetIntValue(string sString)
        {
            int returnValue = 0;
            try
            {
                if (sString == "" || sString == null)
                {
                    return 0;
                }
                else
                {
                    returnValue = int.Parse(sString);
                    return returnValue;
                }
            }
            catch
            {
                //returning 0 will skip processing bad data
                return 0;
            }
        }

    }
}
