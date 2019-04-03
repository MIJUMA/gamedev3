public class PickedUpItemReaction : DelayedReaction
{
    public Item item;


    Inventory inventory;


    protected override void SpecificInit()
    {
    inventory = FindObjectOfType<Inventory>();
    }


    protected override void ImmediateReaction()
    {
    inventory.AddItem(item);
    }
}
