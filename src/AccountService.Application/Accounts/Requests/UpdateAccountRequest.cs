using System;
using System.ComponentModel.DataAnnotations;

namespace AccountService.Application.Accounts.Requests
{
    public class UpdateAccountRequest
    {
        [Required(ErrorMessage = "The field Block")]
        public Guid Guid { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "The field Holder Account Name must contain at least {2} and at most {1} characters")]
        public string HolderAccountName { get; set; }

        [Required(ErrorMessage = "The field Value Balance")]
        public double ValueBalance { get; set; }

        [Required(ErrorMessage = "The field Value Limit")]
        public double ValueLimit { get; set; }

        [Required(ErrorMessage = "The field Block")]
        public bool Blocked { get; set; }
    }
}
