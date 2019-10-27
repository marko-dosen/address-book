using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.SignalR;

namespace AddressBook.Hubs
{
    public class ContactHub
        : Hub, IHub<ContactHub>
    {
        private readonly IHubContext<ContactHub> _context;

        public ContactHub(IHubContext<ContactHub> context)
        {
            _context = context;
        }

        public async Task SendUpdateAsync(MessageType type, object payload)
        {
            await _context.Clients.All.SendAsync(type.ToString(), payload);
        }
    }
}
