namespace TravelRequest.Models.IRepository
{
    public interface ITravelRepository
    {
        public ICollection<TravelModel> GetAllTravelInformation();
    }
}
