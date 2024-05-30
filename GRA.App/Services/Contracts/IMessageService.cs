using GRA.Models.Dtos;

namespace GRA.App.Services.Contracts
{
    public interface IMessageService
    {
        Task<int> CreateMessage(MessageDto message);
        Task<IEnumerable<MessageDto>?> GetAllMessages();
        Task MarkMessageAsRead(int messageId);
    }
}
