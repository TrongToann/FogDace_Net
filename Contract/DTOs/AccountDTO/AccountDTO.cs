using Contract.DTOs.BaseDTO;

namespace Contract.DTOs.AccountDTO
{
    public class AccountDTO : Base
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
    }
}
