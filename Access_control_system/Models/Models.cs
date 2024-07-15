using Access_control_system.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Access_control_system.Models
{
    public class User
    {
        public User(string emailAddress, string password, string department, string position, string name,
            string phoneNumber, string city, DateTime sessionType)
        {
            Login = emailAddress;
            Password = password;
            Department = department;
            Position = position;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
            SessionTime = sessionType.; /* Необходимо получить дату выхода из системы и через TimeSpan определить 
                                         длительность сессии */
            Id = Login.GetDeterministicHashCode();
        }

        [Required(ErrorMessage = "Login required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Not a valid email")]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Wrong password. Please, try again.")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(16, 120, ErrorMessage = "Age must be between 16 and 120")]
        public string Age { get; set; }

        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Time)] // т.к. будем высчитывать кол-во часов пользователя в системе
        public DateTime SessionTime { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        private long Id { get; set; }
    }
}
