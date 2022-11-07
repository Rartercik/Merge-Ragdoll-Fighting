namespace Game.Environment.GameStates
{
    public class Fighting : GameState
    {
        public Fighting(GameStatesHandler statesHandler) : base(statesHandler) { }

        public override void Enter()
        {
            
        }

        public override void ReportPlayerDeath()
        {
            StatesHandler.SwitchState<EnemyVictory>();
        }

        public override void ReportEnemyDeath()
        {
            StatesHandler.SwitchState<PlayerVictory>();
        }
    }
}
