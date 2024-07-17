using Access_control_system.Extensions;
using Access_control_system.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Access_control_system.Models
{
    public class User
    {
        public User(string email, string password, string name,
            PhoneNumber phoneNumber)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Id = Email.GetDeterministicHashCode();
        }

        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Not a valid email")]
        [DisplayName("Login")]
        public string Email { get; set; }

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
        public Age Age { get; set; }

        [Required]
        public PhoneNumber PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LoggedinAt { get; set; }

        private long Id { get; set; }
    }
}


public class PhoneNumber : ValueObject
{
    private const string phoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"; // TODO:добавить валидацию
    public string Number { get; }
    public PhoneNumber(string number)
    {
        Number = number;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}


public class Age : ValueObject
{
    public string UserAge { get; } // TODO:добавить валидацию
    public Age(string userAge)
    {
        UserAge = userAge;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserAge;
    }
}
