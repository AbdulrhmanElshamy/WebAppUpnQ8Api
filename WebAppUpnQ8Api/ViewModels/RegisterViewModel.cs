namespace WebAppUpnQ8Api.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? FirstName { get; set; }
        public string? LateName { get; set; }
        public string? FirstPhoneNumber { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public string? FirstAdderess { get; set; }
        public string? SecondAddress { get; set; }

        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public bool Gender { get; set; }

        public int? CodeNumberId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
