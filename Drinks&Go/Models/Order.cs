using Drinks_Go.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [BindNever]
    public int OrderId { get; set; }

    [BindNever]
    public List<OrderDetail>? OrderLines { get; set; }

    [Required(ErrorMessage = "Please enter your first name")]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name")]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your address")]
    [Display(Name = "Address Line 1")]
    public string AddressLine1 { get; set; }

    [Display(Name = "Address Line 2")]
    public string? AddressLine2 { get; set; }

    [Required(ErrorMessage = "Please enter your zip code")]
    [Display(Name = "Zip code")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "Please enter your city")]
    public string City { get; set; }

    public string? State { get; set; }

    [Required(ErrorMessage = "Please enter your country")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public decimal OrderTotal { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; }
}