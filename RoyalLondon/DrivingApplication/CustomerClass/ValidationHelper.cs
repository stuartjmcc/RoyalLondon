using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClass
{
    static class ValidationHelper
    {
        /// <summary>
        /// Checks the letter template file exists
        /// NOTE: in future could also check for MIME type and/or appropriate regular expressions existing
        /// </summary>
        /// <param name="PathAndFilename"></param>
        /// <returns>true if the file exists and is valid; false if any problem occurs</returns>
        public static bool IsLetterTemplateValid(string PathAndFilename)
        {
            try
            {
                if(!File.Exists(PathAndFilename))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that the file exists and that the headers match
        /// NOTE: It does not validate the contents of the file
        /// </summary>
        /// <param name="PathAndFilename"></param>
        /// <returns>true if the file exists and is valid; false if any problem occurs</returns>
        public static bool IsCustomerSourceFileValid(string PathAndFilename)
        {
            try
            {
                if (File.Exists(PathAndFilename))
                {
                    // Check Header - Probably a lot more to this if versioning were an issue
                    using (StreamReader sourcefile = File.OpenText(PathAndFilename))
                    {
                        if(!sourcefile.ReadLine().Contains("ID,Title,FirstName,Surname,ProductName,PayoutAmount,AnnualPremium"))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate folder existance
        /// </summary>
        /// <param name="Path"></param>
        /// <returns>true if valid; false if any problem occurs</returns>
        public static bool IsResultsFolderValid(string Path)
        {
            try
            {
                if(!Directory.Exists(Path))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
