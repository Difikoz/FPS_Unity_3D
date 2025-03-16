using System;
using System.Collections.Generic;

namespace WinterUniverse
{
    public class StatHolder
    {
        public Action OnStatsChanged;

        private List<Stat> _stats;

        public List<Stat> Stats => _stats;

        public StatHolder(List<StatCreator> baseStats)
        {
            _stats = new();
            foreach (StatCreator creator in baseStats)
            {
                _stats.Add(new(creator.Config, creator.BaseValue));
            }
        }

        public void RecalculateStats()
        {
            foreach (Stat s in _stats)
            {
                s.CalculateCurrentValue();
            }
        }

        public Stat GetStat(string id)
        {
            foreach (Stat s in _stats)
            {
                if (s.Config.ID == id)
                {
                    return s;
                }
            }
            return null;
        }

        public void AddStatModifiers(List<StatModifierCreator> modifiers)
        {
            foreach (StatModifierCreator smc in modifiers)
            {
                AddStatModifier(smc);
            }
            RecalculateStats();
        }

        public void AddStatModifier(StatModifierCreator smc)
        {
            GetStat(smc.Stat.ID).AddModifier(smc.Modifier);
        }

        public void RemoveStatModifiers(List<StatModifierCreator> modifiers)
        {
            foreach (StatModifierCreator smc in modifiers)
            {
                RemoveStatModifier(smc);
            }
            RecalculateStats();
        }

        public void RemoveStatModifier(StatModifierCreator smc)
        {
            GetStat(smc.Stat.ID).RemoveModifier(smc.Modifier);
        }
    }
}