namespace TowerDefence.Mediator {
    public class MinionDamageControlManager {
        public static IMinionDamageControl MinionDamageControl { get; } = new MinionDamageControl();
    }
}
