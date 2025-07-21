using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace HomoLudens.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public LevelData LevelData;
        public ResourceData ResourceData;
        public HealthData HeroHealth;
        public HeroStats HeroStats;
        public ExperienceData Experience;

        public PlayerProgress()
        {
            WorldData = new WorldData();
            LevelData = new LevelData();
            ResourceData = new ResourceData();
            HeroHealth = new HealthData();
            HeroStats = new HeroStats();
            Experience = new ExperienceData();
        }

        public PlayerProgress(PlayerProgress other)
        {
            WorldData = other.WorldData();
            LevelData = other.LevelData();
            ResourceData = other.ResourceData();
            HeroHealth = other.HealthData();
            HeroStats = other.HeroStats();
            Experience = other.ExperienceData();
        }
    }
}