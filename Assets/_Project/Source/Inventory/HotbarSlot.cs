using _Project.Source.Inventory.ItemTypesConfigs;

namespace _Project.Source.Inventory
{
    public class HotbarSlot
    {
        public Item Item { get; private set; }
        public int ItemAmount { get; private set; }
    
        public void AssignItem(Item item, int startAmount)
        {
            Item = item;
            ItemAmount = startAmount;
        }

        public void AddItemAmount(int amount)
        {
            if (Item == null || Item.StackAmount <= 1)
                return;

            if (ItemAmount + amount <= Item.StackAmount)
                ItemAmount += amount;
            else
                ItemAmount = Item.StackAmount;
        }

        public void RemoveItemAmount(int amount)
        {
            if (Item == null && (Item is Weapon weapon))
                return;

            if (ItemAmount >= amount)
            {
                ItemAmount -= amount;

                if (ItemAmount <= 0)
                {
                    Item = null;
                    ItemAmount = 0;
                }
            }
        }
    }
}