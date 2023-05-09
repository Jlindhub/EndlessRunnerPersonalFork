using Inventory;
using Item;
using Stat;
using UnityEngine;

[CreateAssetMenu]
public class Dependencies : ScriptableObject
{
    private static Dependencies _instance;
    [SerializeField] private DummyInventory dummyInventory;

    private InventorySerializer inventorySerializer;
    [SerializeField] private ItemDataBaseSO itemDataBase;

    public static Dependencies Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<Dependencies>(nameof(Dependencies));
            return _instance;
        }
    }


    public IInventoryData Inventory => dummyInventory;
    public IActiveInventory Equipped => dummyInventory;

    private void OnEnable()
    {
        //Move to constructor when not scriptableObject anymore
        inventorySerializer = new InventorySerializer(dummyInventory, itemDataBase);
        var playerStats = new PlayerStats(Equipped);
        Load();
    }

    public void CreateItemButton()
    {
        dummyInventory.CreateDummyItem();
    }

    private void Load()
    {
        var items = inventorySerializer.Load();
        dummyInventory.Load(items);
    }
}