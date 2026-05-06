using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeathBringerTrigger : Enemy_AnimationTriggers
{
    private Enemy_DeathBringer enemyDeathBringer => GetComponentInParent<Enemy_DeathBringer>();
    private void Relocate() => enemyDeathBringer.FindPosition();

    private void MakeInvisble() => enemyDeathBringer.fx.MakeTransParent(true);
    private void MakeVisble() => enemyDeathBringer.fx.MakeTransParent(false);


}
