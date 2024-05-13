using Contract.DTOs.CartDTO;
using Contract.DTOs.AccountDTO;
using System.Collections.ObjectModel;

namespace Contract.Service.Cart
{
    public class Response 
    {
        public Guid Account_id {  get; set; }
        public AccountDTO Account { get; set; }
        public int Count_Product { get; set; }
        public Collection<CartProductDTO> CartProducts { get; set; }
    }
}
