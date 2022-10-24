using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfig", menuName = "SkillConfig", order = 0)]
public class SkillConfig : ScriptableObject {
    public Sprite skillIcon;
    public int skillId;
    public string skillName;
    public int needRageValue = 100;
    public int skillShakeBeforeTimeMs;
    public int skillAttackDurationMs;
    public int skillShakeAfterTimeMs;
    public SkillType skillType;
    public TargetType targetType;
    public SkillAttackType skillAttackType;
    public DamageType damageType;
    public int damagePercentage;

    // 渲染层数据
    public string bullet;
    public string skillAnim;
    public AudioClip skillAudio;
    public string skillEffect;
    public string skillHitEffect;
    public int[] addBuffs;
    public string skillDes;
}

public enum SkillType {
    MoveToAttack,
    MoveToEnemyCenter,
    MoveToCenter,
    Chant,
   Ballistic
}

public enum TargetType {
    None,
    Teammate,
    Enemy
}

public enum SkillAttackType {
    SingleTarget,
    AllHero,
    BackRowHero,
    FrontRowHero,
    SamColumnHero
}

public enum DamageType {
    None,
    NormalDamage,
    RealDamage,
    AtkPercentage,
    HpPercentage
}
