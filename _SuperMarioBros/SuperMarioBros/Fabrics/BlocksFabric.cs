using SuperMarioBros.GameObjects;

namespace SuperMarioBros.Fabrics;

public class BlocksFabric : AbstractFabric<Block>
{
    public override event Action? OnItemsUpdated;

    public BlocksFabric()
    {
        _list = new List<Block>();
    }

    public void CreateBlocks()
    {
        
    }
    
    public override void AddItem(Block item)
    {
        _list.Add(item);
        OnItemsUpdated?.Invoke();
    }

    public override void Clear()
    {
        _list.Clear();
        OnItemsUpdated?.Invoke();
    }
    
    public override void RemoveItem(Block item)
    {
        _list.Remove(item);
        OnItemsUpdated?.Invoke();
    }
    
    public override List<Block> GetItems() => _list;

}