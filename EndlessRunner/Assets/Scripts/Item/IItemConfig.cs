using Inventory;
using Stat;
using UnityEngine;

namespace Item
{
    public interface IItemConfig
    {
        IStats BaseStats { get; }
        ItemType ItemType { get; }
        int BonusStats { get; }
        string ItemName { get; }
        Sprite ItemSprite { get; }
        Sprite ItemIcon { get; }
        string Id { get; }
    }
}