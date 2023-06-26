using System;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem.Data
{
    /// <summary>
    /// Класс хелпер для удобного создания слотов в ContainerDefaultState
    /// </summary>
    [Serializable]
    public class SOSlot
    {
        [field: SerializeField] public ItemMeta ItemMeta { get; private set; }
        [field: SerializeField, Range(1, 10000)] public uint Amount { get; private set; }
    }
}
