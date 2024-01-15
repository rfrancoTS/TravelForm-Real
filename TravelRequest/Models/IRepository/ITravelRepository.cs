namespace TravelRequest.Models.IRepository
{
    public interface ITravelRepository
    {
        public ICollection<TsiTravelModel> GetAllTravelInformation();
    }
}
