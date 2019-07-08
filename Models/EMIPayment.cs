using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPAF.Models
{
    public class EMIWorkList
    {
        public string SNo { get; set; }
        public string EMIAmount { get; set; }
        public string DueDate { get; set; }
        public string EMIReceived { get; set; }
        public string LastReceivedDate { get; set; }
        public string NoofDaysDelayed { get; set; }
        public string Penalty { get; set; }
        public string Status { get; set; }
        public string AgreementDate { get; set; }
        public string NoOfEMIs { get; set; }
        public string CustomerID { get; set; }


    }
   
    public class EMIPayment
    {
        public List<EMIWorkList> EMIWorkList { get; set; }
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }
        public string AgreementID { get; set; }

        public string VehicleNo { get; set; }

        public string EMIAmount { get; set; }
        public string BalanceAmount { get; set; }
        public string TotalEMIs { get; set; }
        public string StoreLocation { get; set; }
        public string TotalLoanAmount { get; set; }
        public string DueDate { get; set; }
        public string NoODaysDelayed { get; set; }
        public string Status { get; set; }
        public string TotalAmountInThisMonth { get; set; }
    }
}