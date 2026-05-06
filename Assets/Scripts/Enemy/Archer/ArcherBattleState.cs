using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Archer
{
    public class ArcherBattleState : EnemyState
    {
        private Transform player;
        private Enemy_Archer enemy;
        private int moveDir;

        public ArcherBattleState(global::Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Archer _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            player = PlayerManager.instance.player.transform;

            if (player.GetComponent<PlayerStats>().isDead)
                stateMachine.ChangeState(enemy.moveState);
        }
        public override void Update()
        {
            base.Update();

            if (enemy.IsPlayerDetected())
            {
                stateTimer = enemy.battleTime;

                if (enemy.IsPlayerDetected().distance < enemy.safeDistance)
                {
                    if (CanJump())
                        stateMachine.ChangeState(enemy.jumpState);
                }

                if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
                {
                    if (CanAttack())
                    {
                        stateMachine.ChangeState(enemy.attackState);
                    }
                }
            }
            else
            {
                if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 15)
                {
                    stateMachine.ChangeState(enemy.idleState);
                }
            }

            BattleStateFlipController();

        }

        private void BattleStateFlipController()
        {
            if (player.position.x > enemy.transform.position.x && enemy.facingDir == -1)
                enemy.Flip();
            else if (player.position.x < enemy.transform.position.x && enemy.facingDir == 1)
                enemy.Flip();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private bool CanAttack()
        {
            if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
            {
                enemy.attackCooldown = Random.Range(enemy.minattackCooldown, enemy.maxattackCooldown);
                enemy.lastTimeAttacked = Time.time;
                return true;
            }

            return false;
        }

        private bool CanJump()
        {
            if (enemy.GroundBehind() == false || enemy.WallBehind() == true)
                return false;

            if(Time.time >= enemy.lastTimeJumped + enemy.jumpCooldown)
            {
                enemy.lastTimeJumped = Time.time;
                return true;
            }
            return false;
        }
    }
}