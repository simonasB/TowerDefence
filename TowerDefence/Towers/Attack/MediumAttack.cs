using System;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class MediumAttack : IAttack
    {
        public float Impact { get; } = 0.4f;

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with medium impact: " + Impact);
        }
    }
}
