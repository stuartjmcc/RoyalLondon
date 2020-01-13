using System;

namespace CustomerClass
{
    public enum RecordListStatus
    {
        OK,
        BAD_TEMPLATE,
        BAD_SOURCEFILE,
        OUTPUT_ERROR
    }

    public class CustomerHandler
    {
        #region "Publics"
        /// <summary>
        /// Validate the inputs and outputs
        /// </summary>
        /// <param name="bodyTemplateLocation"></param>
        /// <param name="sourceFileLocation"></param>
        /// <param name="outputFolderLocation"></param>
        /// <returns> Value indicating error type</returns>
        public RecordListStatus IsValid(string bodyTemplateLocation, string sourceFileLocation, string outputFolderLocation)
        {
            if (!ValidationHelper.IsLetterTemplateValid(bodyTemplateLocation))
            {
                return RecordListStatus.BAD_TEMPLATE;
            }

            if (!ValidationHelper.IsCustomerSourceFileValid(sourceFileLocation))
            {
                return RecordListStatus.BAD_SOURCEFILE;
            }

            if (!ValidationHelper.IsResultsFolderValid(outputFolderLocation))
            {
                return RecordListStatus.OUTPUT_ERROR;
            }

            return RecordListStatus.OK;
        }

        /// <summary>
        /// Main processing loop for the CSV file contents
        /// ASSUMPTION: The inputs have already been validated by the calling module (in this case the DrivingApplication)
        /// ASSUMPTION: We are throwing away any bad records (including the Header). I would normally expect bad records to be recorded in some way and fixed extant to this code
        /// </summary>
        /// <param name="bodyTemplateLocation"></param>
        /// <param name="sourceFileLocation"></param>
        /// <param name="outputFolderLocation"></param>
        public void ProcessFile(string bodyTemplateLocation, string sourceFileLocation, string outputFolderLocation)
        {
            // Set the body Template
            string bodyTemplate = System.IO.File.ReadAllText(bodyTemplateLocation,System.Text.Encoding.UTF8);

            // Parse the records in the file and write the results
            string[] csvContents = System.IO.File.ReadAllLines(sourceFileLocation);
            foreach (string record in csvContents)  
            {
                CustomerRecord customerRecord = new CustomerRecord();
                customerRecord.ProcessCSVRecord(record);
                if(customerRecord.ID != -1)
                {
                    string letter = GetPopulatedLetter(bodyTemplate, customerRecord);
                    if(letter != "")
                    {
                        HandleSavingLetterToFile(outputFolderLocation, letter, customerRecord);
                    }
                }
            }

        }
        #endregion "Publics"

        #region "Privates"
        /// <summary>
        /// Combines the template with the contents of a customer record
        /// </summary>
        /// <param name="template"></param>
        /// <param name="customerRecord"></param>
        /// <returns>a single unique customer string OR and empty string if an error occured</returns>
        private string GetPopulatedLetter(string template, CustomerRecord customerRecord)
        {
            string workingString = template;
            try
            {
                workingString = workingString.Replace(@"<CURRENT_DATE>", DateTime.Now.ToString("dd/MM/yyyy"));
                workingString = workingString.Replace(@"<TITLE>", customerRecord.Title);
                workingString = workingString.Replace(@"<FIRST_NAME>", customerRecord.FirstName);
                workingString = workingString.Replace(@"<SURNAME>", customerRecord.Surname);
                workingString = workingString.Replace(@"<PRODUCT_NAME>", customerRecord.ProductName);
                workingString = workingString.Replace(@"<PAYOUT_AMOUNT>", customerRecord.PayoutAmount.ToString("N2"));
                workingString = workingString.Replace(@"<ANNUAL_PREMIUM>", customerRecord.AnnualPremium.ToString("N2"));
                workingString = workingString.Replace(@"<CREDIT_CHARGE>", customerRecord.CreditCharge.ToString("N2"));
                workingString = workingString.Replace(@"<TOTAL_PREMIUM>", customerRecord.TotalPremium.ToString("N2"));
                workingString = workingString.Replace(@"<INITIAL_PAYMENT>", customerRecord.InitialMonthlyPayment.ToString("N2"));
                workingString = workingString.Replace(@"<SUBSEQUENT_PAYMENTS>", customerRecord.RemainingMonthlyPayments.ToString("N2"));
            }
            catch
            {
                workingString = "";
            }

            return workingString;
        }

        /// <summary>
        /// Creates a unique filename based on customer details and writes the customers letter to the file system if it doesn't already exist
        /// ASSUMPTION: As there is no date handling information contained in the spec the potential for an existing file from a different date 
        /// being present is being ignored.
        /// </summary>
        /// <param name="outputFolderLocation"></param>
        /// <param name="letter"></param>
        /// <param name="customerRecord"></param>
        private void HandleSavingLetterToFile(string outputFolderLocation, string letter, CustomerRecord customerRecord)
        {
            // Customer Id and name
            string uniquefilename = string.Format("{0}_{1}_{2}_{3}.txt", customerRecord.ID, customerRecord.Title,customerRecord.FirstName,customerRecord.Surname);
            string fileandpath = string.Format("{0}\\{1}", outputFolderLocation, uniquefilename);
            if(!System.IO.File.Exists(fileandpath))
            {
                System.IO.File.WriteAllText(fileandpath, letter);
            }
        }


        #endregion "Privates"

    }


}
