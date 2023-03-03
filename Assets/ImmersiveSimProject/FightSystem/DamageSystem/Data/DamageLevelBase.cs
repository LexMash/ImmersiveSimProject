using ImmersiveSimProject.DamageSystem.View;
using System;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [Serializable]
    public abstract class DamageLevelBase<DView> where DView : DamageLevelViewBase
    {
        [SerializeField] private DView _view;
        [SerializeField] private int _healthLevel;

        public DView View => _view;
        public int HealthLevel => _healthLevel;
    }
}
