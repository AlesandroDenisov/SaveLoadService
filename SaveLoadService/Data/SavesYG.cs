using HomoLudens.Data;
using UnityEngine;
using System;

namespace YG
{
    [Serializable]
    public partial class SavesYG
    {
        public int idSave;
        [field: SerializeField] public PlayerProgress Progress = new();
    }
}
