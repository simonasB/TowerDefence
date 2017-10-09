using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers.Attack
{
    public interface IAttack
    {
        float impact { get; }

        void Attack();
    }
}
