using System;
using Game.BodyComponents.Fighting;

namespace Game.Environment.GameStates
{
    public class EnemyVictory : GameState
    {
        private Body _enemy;
        private Action _onEntered;

        public EnemyVictory(GameStatesHandler statesHandler, Body enemy, Action onEntered) : base(statesHandler)
        {
            _enemy = enemy;
            _onEntered = onEntered;
        }

        public override void Enter()
        {
            _enemy.MakeUndying();
            _onEntered.Invoke();
        }

        public override void ReportPlayerDeath()
        {
            
        }

        public override void ReportEnemyDeath()
        {

        }
    }
}
