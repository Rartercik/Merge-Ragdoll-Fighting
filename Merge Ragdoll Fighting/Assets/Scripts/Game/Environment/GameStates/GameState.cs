namespace Game.Environment.GameStates
{
    public abstract class GameState
    {
        public GameState(GameStatesHandler statesHandler)
        {
            StatesHandler = statesHandler;
        }

        protected GameStatesHandler StatesHandler { get; private set; }

        public abstract void Enter();

        public abstract void ReportPlayerDeath();

        public abstract void ReportEnemyDeath();
    }
}
