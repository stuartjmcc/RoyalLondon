using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerClass
{

    public class CustomerRecord
    {
        // Items from CSV File
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ProductName { get; set; }
        public double PayoutAmount { get; set; }
        public double AnnualPremium { get; set; }

        // Calculated Items
        public double CreditCharge { get; set; }
        public double TotalPremium { get; set; }
        public double AverageMonthlyPremium { get; set; }
        public double InitialMonthlyPayment { get; set; }
        public double RemainingMonthlyPayments { get; set; }

        /// <summary>
        /// Constructor - Set all value to empty or invalid monetary values
        /// </summary>
        public CustomerRecord()
        {
            ID = -1;
            Title = "";
            FirstName = "";
            Surname = "";
            ProductName = "";
            PayoutAmount = -1;
            AnnualPremium = -1;
            CreditCharge = -1;
            TotalPremium = -1;
            AverageMonthlyPremium = -1;
            InitialMonthlyPayment = -1;
            RemainingMonthlyPayments = -1;
        }

        /// <summary>
        /// Populates the object with values from the CSV record then calculates the other values
        /// ASSUMPTIONS:
        /// 1/ Not checking values are valid and to two decimal places - these errors handled by exception
        /// 2/ Using Parse instead of TryParse so any conversion errors are handled by exception
        /// </summary>
        /// <param name="record"></param>
        /// <returns> true if record is OK, false if en error occurs in processing it</returns>
        public bool ProcessCSVRecord(string record)
        {
            try
            {
                string[] items = record.Split(',');
                ID = int.Parse(items[0]);
                Title = ParseTitle(items[1]);
                if(Title == "")
                {
                    ID = -1;
                    return false;
                }
                FirstName = items[2];
                Surname = items[3];
                ProductName = items[4];
                PayoutAmount = double.Parse(items[5]);
                AnnualPremium = double.Parse(items[6]);

                // Do Calculated values
                SetCreditCharge();
                SetTotalPremium();
                SetAverageMonthlyPremium();
                SetMonthlyPayments();
            }
            catch
            {
                // Anything goes wrong set the ID to -1 to indicate invalid
                ID = -1;
            }

            if(ID != -1)
                return true;
            else
                return false;
        }

        #region "Private functions"
        /// <summary>
        /// Checks the record only contains one of the allowed formats
        /// </summary>
        /// <param name="title"></param>
        /// <returns> the title contained in the record or and empty string</returns>
        private string ParseTitle(string title)
        {
            if (title == "Mr" || title == "Miss" || title == "Mrs")
                return title;
            else
                return "";
        }

        /// <summary>
        /// An additional charge that applies when paying monthly by Direct Debit.
        /// 5% of the annual premium, rounded up to a whole number of pounds and pence
        /// </summary>
        private void SetCreditCharge()
        {
            double round3places = Math.Round((AnnualPremium * 5) / 100, 3);
            double round2places = Math.Round((AnnualPremium * 5) / 100, 2);
            CreditCharge = (round3places - round2places) != 0 ? round2places + 0.01 : round2places;
        }

        /// <summary>
        /// The total amount payable for the year when paying monthly by Direct Debit. 
        /// The Annual Premium plus the Credit Charge
        /// </summary>
        private void SetTotalPremium()
        {
            TotalPremium = AnnualPremium + CreditCharge;
        }

        /// <summary>
        /// The average amount payable per month when paying monthly by Direct Debit.
        /// The Total Premium(Direct Debit) divided by the number of months in a year
        /// </summary>
        private void SetAverageMonthlyPremium()
        {
            AverageMonthlyPremium = TotalPremium / 12;
        }

        /// <summary>
        /// Sets InitialMonthlyPayment and RemainingMonthlyPayments
        /// All monthly payments must be a whole amount of pounds and pence, 
        /// and at least 11 of the 12 payment amounts must be equal; 
        /// when the average monthly premium isn’t a whole number of pounds and pence, the first (initial) payment must be higher. 
        /// There should be as little difference as possible between the amount of the initial payment and the amount of the other 11 payments
        /// </summary>
        private void SetMonthlyPayments()
        {
            // Work in integer values to avoid rounding issues
            int totalPremiumAsInt = (int)(TotalPremium * 100);
            int averageAsInt = totalPremiumAsInt / 12;
            int totalElevenRemainingPayments = averageAsInt * 11;
            InitialMonthlyPayment = totalPremiumAsInt - totalElevenRemainingPayments;
            RemainingMonthlyPayments = averageAsInt;

            // Convert back to double values and assign. Also sort decimal places out just to be sure
            InitialMonthlyPayment = Math.Round(InitialMonthlyPayment / 100, 2);
            RemainingMonthlyPayments = Math.Round(RemainingMonthlyPayments / 100, 2);
        }

        #endregion "Private functions"

    }
}
