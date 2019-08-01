using System;

namespace AccountService.Application.Accounts.Responses
{
    public class GetAllAccountResponse
    {
        public Guid Guid { get; set; }
        public string HolderAccountName { get; set; }
        public double ValueBalance { get; set; }
        public double ValueLimit { get; set; }
        public bool Blocked { get; set; }
    }
}
