namespace TowerDefence.Towers.Commands
{
    public abstract class ICommand
    {
        protected AbstractTower TowerUnderCommand;

        protected ICommand(AbstractTower towerUnderCommand)
        {
            this.TowerUnderCommand = towerUnderCommand;
        }

        public abstract void execute();

        public void undo() {
            // Undo stuff
        }
    }
}
