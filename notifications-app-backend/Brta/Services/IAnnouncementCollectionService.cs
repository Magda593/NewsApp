using NewsApi.Models;

namespace NewsApi.Services
{
    public interface IAnnouncementCollectionService :ICollectionService <Announcement>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
