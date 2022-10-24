using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillState {
    None,
    ShakeBefore,
    ShakeAfter,
}

public class Skill {
    
    public int SkillId { get; private set; }
    private HeroLogic skillOwner;
    private bool isNormalAtk;
    public SkillState SkillState { get; private set; }

    public Skill(int skillId, LogicObject skillOwner, bool isNormalAtk) {
        SkillId = skillId;
        skillOwner = (HeroLogic)skillOwner;
        this.isNormalAtk = isNormalAtk;
    }

    public void ReleaseSkill() {
        SkillShakeBefore();
        PlaySkillAnim();
        MoveToTarget();
    }

    public void SkillShakeBefore() {
        SkillState = SkillState.ShakeBefore;
    }

    public void PlaySkillAnim() {

    }

    public void MoveToTarget() {

    }

    public void SkillTrigger() {

    }

    public void CreateSkillEffect() {

    }

    public void AddBuff() {

    }

    public void SkillShakeAfter() {

    }

    public void MoveToSeat() {

    }

    public void SkillEnd() {

    }
}
