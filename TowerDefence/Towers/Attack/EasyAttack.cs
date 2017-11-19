using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class EasyAttack : IAttack
    {
        public float Impact { get; } = 0.1f;

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with easy impact: " + Impact);
        }
    }
}
