using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.SignalR;

namespace AddressBook.Hubs
{
    public interface IHub<T> where T: Hub
    {
        Task SendUpdateAsync(MessageType type, object payload);
    }
}
