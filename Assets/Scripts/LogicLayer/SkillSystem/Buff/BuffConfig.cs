using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "BuffConfig", menuName = "BuffConfig", order = 0)]
public class BuffConfig : ScriptableObject {

    public Sprite buffIcon;
    public int buffId;
    public string buffName;
    public int maxStack;
    public int buffDurationTimeMs;
    public int buffDurationRound;
    public int buffTriggerIntervalMs;
    public int buffTriggerProbability;

    public BuffType buffType;
    public BuffState buffState;
}

public enum BuffType {
    DamageBuff, // 伤害
    Buff, // 增益
    Debuff, // 减益
    Control // 控制
}

public enum BuffState {
    None,
    PercentageReduceDamage,
    DamageDeepening,
    HpRecoveryIncrease,
    HpRecoveryReduce,
    Burn,
    Purify,
    Forzen
}

public enum BuffTriggerType {

}
