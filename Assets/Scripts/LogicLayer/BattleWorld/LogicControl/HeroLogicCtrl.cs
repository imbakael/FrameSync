using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroTeamEnum {
    None,
    Self,
    Enemy
}

public class HeroLogicCtrl : ILogicBehaviour {
    public void OnCreate() {
        
    }

    public void OnCreate(List<HeroData> playerHeroList, List<HeroData> enemyHeroList) {
#if CLIENT_LOGIC
        CreateHeroByList(playerHeroList, BattleWorldNodes.Instance.heroTransArr, HeroTeamEnum.Self);
        CreateHeroByList(enemyHeroList, BattleWorldNodes.Instance.enemyTransArr, HeroTeamEnum.Enemy);
#else
        CreateHeroByList(playerHeroList, null, HeroTeamEnum.Self);
        CreateHeroByList(enemyHeroList, null, HeroTeamEnum.Enemy);
#endif
    }

    public void CreateHeroByList(List<HeroData> heroList, Transform[] parents, HeroTeamEnum heroTeam) {
        foreach (HeroData item in heroList) {
            GameObject hero = ResourceManager.Instance.LoadObject("Prefabs/Hero/" + item.id,
                parents[item.seatid], true, false
                
                , true);
        }
    }

    public void OnDestroy() {
        
    }

    public void OnLogicFrameUpdate() {
        
    }
}