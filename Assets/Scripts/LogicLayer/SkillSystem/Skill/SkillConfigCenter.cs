using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConfigCenter : MonoBehaviour
{
    public static SkillConfig LoadSkillConfig(int skillId) {
        return Resources.Load<SkillConfig>(AssetPathConfig.SKILL_CONFIG + skillId);
    }
}
