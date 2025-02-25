using _Project.Source.PickupObjects;

namespace _Project.Source.Player
{
    public interface IItemCollector
    {
        void CollectItem(PickupObject pickupObject);
    }
}