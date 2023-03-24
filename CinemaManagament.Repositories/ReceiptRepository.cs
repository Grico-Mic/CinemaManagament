
using CinemaManagamentAppication.Models;

namespace CinemaManagament.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>
    {
        public ReceiptRepository() : base("Receipt.Txt")
        {

        }
    }
}
