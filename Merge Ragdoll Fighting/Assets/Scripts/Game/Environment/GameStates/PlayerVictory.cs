using System;
using Game.BodyComponents.Fighting;

namespace Game.Environment.GameStates
{
    public class PlayerVictory : GameState
    {
        private Body _player;
        private Action _onEntered;

        public PlayerVictory(GameStatesHandler statesHandler, Body player, Action onEntered) : base(statesHandler)
        {
            _player = player;
            _onEntered = onEntered;
        }

        public override void Enter()
        {
            _player.MakeUndying();
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
