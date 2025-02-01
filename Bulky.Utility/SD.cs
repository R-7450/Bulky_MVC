using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    public static class SD     // static details
    {
        public const string Role_Customer = "Customer"; // if a user role is customer then they will have advantage to make payment for order under 30 days.
        public const string Role_Company = "Company";
        public const string Role_Admin = "Admin";
        public  const string Role_Employee = "Employee";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";
        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";
        public const string SessionCart = "SessionShoppingCart";



    }
}
