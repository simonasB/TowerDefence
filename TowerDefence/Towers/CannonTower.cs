namespace TowerDefence.Towers {
    public class CannonTower : ITower {
        public string Name { get; } = "Cannon tower";

        public int Damage { get; } = 20;

        public int Range { get; } = 1;

        public void StartAttack() {
            throw new System.NotImplementedException();
        }

        public void StopAttack() {
            throw new System.NotImplementedException();
        }
    }
}
