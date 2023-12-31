using System;
using Stat;
using UnityEngine;

namespace Item
{
    [Serializable]
    public class ItemData : IItemData
    {
        [SerializeField] private Stats bonusStats;
        [SerializeField] private IItemConfig itemConfig;

        public ItemData(Stats bonusStats, IItemConfig itemConfig)
        {
            this.bonusStats = bonusStats;
            this.itemConfig = itemConfig;
        }

        public IItemConfig ItemConfig => itemConfig;

        public IStats BonusStats => bonusStats;

        public IStats TotalStats => itemConfig.BaseStats.Add(bonusStats);
    }
}