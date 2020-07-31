using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DL.NetCore.EmptySolution.Web.UI.Models.User
{
    public class InviteUserViewModel
    {
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please provide the invitee's Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [StringLength(254, ErrorMessage = "Maximum email address length exceeded")]
        public string EmailAddress { get; set; }

        [DisplayName("Display Name")]
        [Required(ErrorMessage = "Please provide the invitee's display name")]
        public string DisplayName { get; set; }
    }
}
