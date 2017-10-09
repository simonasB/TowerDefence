﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers.Attack
{
    public class EasyAttack : IAttack
    {
        public float impact { get; } = 0.1f;

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with easy impact: " + impact);
        }
    }
}
