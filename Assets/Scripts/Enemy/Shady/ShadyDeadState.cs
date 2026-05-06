using UnityEngine;

namespace Assets.Scripts.Enemy.Shady
{
    public class ShadyDeadState : EnemyState
    {
        private Enemy_Shady enemy;
        public ShadyDeadState(global::Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Shady _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            if(triggerCalled)
                enemy.SeltDestroy();
        }
    }
}