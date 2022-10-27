using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffLogic : LogicObject
{
    public BuffConfig BuffConfig { get; private set; }

    public int BuffId { get; private set; }
    protected LogicObject owner;
    public HeroLogic ownerHero;
    public HeroLogic targetHero;
    protected LogicObject target;

    public BuffLogic(int buffId, LogicObject owner, LogicObject target) {
        BuffId = buffId;
        this.owner = owner;
        this.ownerHero = owner as HeroLogic;
        this.target = target;
        this.targetHero = target as HeroLogic;
    }

    public override void OnCreate() {
        base.OnCreate();
        objectState = LogicObjectState.Survival;
        BuffConfig = SkillConfigCenter.LoadBuffConfig(BuffId);
    }

    public override void OnLogicFrameUpdate() {
        base.OnLogicFrameUpdate();
        if (objectState == LogicObjectState.Survival) {
            switch (BuffConfig.triggerType) {
                case BuffTriggerType.OneDamageRealTime:
                    if (BuffConfig.buffDurationTimeMs == 0 && BuffConfig.buffTriggerIntervalMs == 0) {
                        TriggerBuff();
                        AddBuffEffect();
                        if (BuffConfig.buffDurationRound == 0) {
                            objectState = LogicObjectState.Death;
                        } else {
                            objectState = LogicObjectState.SurvivalWaiting;
                        }
                    } else {

                    }
                    break;
                case BuffTriggerType.MultiDamageRealTime:
                    break;
                case BuffTriggerType.DamgeRoundStart:
                    break;
                case BuffTriggerType.DamgeRoundEnd:
                    break;
            }
        }
    }

    public void TriggerBuff() {
        if (BuffConfig.damageType != BuffDamageType.None) {
            VInt damage = BattleRule.CalculateDamgae(BuffConfig, (HeroLogic)owner, (HeroLogic)target);
            HeroLogic targetHero = (HeroLogic)target;
            targetHero.BuffDamage(damage, BuffConfig);
        }
    }

    public void AddBuffEffect() {

    }

    public override void OnDestroy() {
        objectState = LogicObjectState.Death;
        RenderObj?.OnRelease();
        BuffManager.Instance.DestroyBuff(this);
    }
}
