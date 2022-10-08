using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWorld {

    public HeroLogicCtrl heroLogic;
    public RoundLogicCtrl roundLogic;

    private float accLogicRuntime;
    private float nextLogicFrameTime;
    private float deltaTime;

    public void OnCreateWorld(List<HeroData> playerHeroList, List<HeroData> enemyHeroList) {
        heroLogic = new HeroLogicCtrl();
        roundLogic = new RoundLogicCtrl();
        heroLogic.OnCreate(playerHeroList, enemyHeroList);
        roundLogic.OnCreate();
    }
      
    public void OnUpdate() {
#if CLIENT_LOGIC
        accLogicRuntime += Time.deltaTime;
        while (accLogicRuntime > nextLogicFrameTime) {
            OnLogicFrameUpdate();
            nextLogicFrameTime += LogicFrameSyncConfig.LogicFrameIntvertal;
            LogicFrameSyncConfig.LogicFrameId++;
        }
        deltaTime = (accLogicRuntime + LogicFrameSyncConfig.LogicFrameIntvertal - nextLogicFrameTime) / LogicFrameSyncConfig.LogicFrameIntvertal;
    }
#else
        OnLogicFrameUpdate();
#endif

    public void OnLogicFrameUpdate() {
        heroLogic?.OnLogicFrameUpdate();
        roundLogic?.OnLogicFrameUpdate();
    }

    public void OnDestroyWorld() {
        heroLogic.OnDestroy();
        roundLogic.OnDestroy();
    }
}