namespace TowerDefence.Towers.Commands
{
    public class CommandAttack : ICommand
    {
        public CommandAttack(AbstractTower towerUnderCommand) : base(towerUnderCommand) {}

        public override void execute()
        {
            TowerUnderCommand.Attack();
        }
    }
}
