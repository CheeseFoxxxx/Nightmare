using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Archer
{
    public class ArcherIdleState : ArcherGroundedState
    {
        public ArcherIdleState(global::Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Archer _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateTimer = enemy.idleTime;
            AudioManager.instance.PlaySFX(24, enemy.transform);
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void Update()
        {
            base.Update();

            if (stateTimer < 0)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }
}