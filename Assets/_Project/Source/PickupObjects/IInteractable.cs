using _Project.Source.Player;

namespace _Project.Source.PickupObjects
{
    public interface IInteractable
    {
        public void Interact(IItemCollector collector);
    }
}