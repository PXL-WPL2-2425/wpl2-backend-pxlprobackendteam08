namespace WebApiTeam08.ViewModels
{
    public class SubscriptionViewModel
    {
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RenewDate { get; set; }
        public string Status { get; set; }
        public string AutoRenewal { get; set; }
        public int GroupID { get; set; }

    }
}
