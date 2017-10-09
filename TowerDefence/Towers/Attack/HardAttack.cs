using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers.Attack
{
    public class HardAttack : IAttack
    {
        public float impact { get; } = 0.8f;

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with hard impact: " + impact);
        }
    }
}
