﻿using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers
{
    public abstract class AbstractTower
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set;}
        protected IAttack AttackType;

        protected AbstractTower(IAttack attackType)
        {
            this.AttackType = attackType;
        }

        public virtual void Attack()
        {
            AttackType.Attack();
        }
    }
}
