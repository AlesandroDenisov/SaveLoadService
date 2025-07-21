using HomoLudens.Data;
using System;
using UnityEngine;

namespace HomoLudens.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}