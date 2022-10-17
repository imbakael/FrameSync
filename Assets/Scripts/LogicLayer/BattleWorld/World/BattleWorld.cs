using System.Collections.Generic;
using UnityEngine;

public class BattleWorld {

    public HeroLogicCtrl heroLogic;
    public RoundLogicCtrl roundLogic;

    private float accLogicRuntime;
    private float nextLogicFrameTime;
    public static float deltaTime;

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
#else
        OnLogicFrameUpdate();
#endif
        if (Input.GetKeyDown(KeyCode.Q)) {
            Debugger.Log("计时开始 ： " + Time.realtimeSinceStartup);
            heroLogic.heroList[0].PlayAnim("Attack");
            var moveTo = new MoveToAction(heroLogic.heroList[0], heroLogic.enemyList[0].LogicPosition, new VInt(1000), () => {
                Debugger.Log("计时结束 ： " + Time.realtimeSinceStartup);
                Debugger.Log("移动完成 = " + heroLogic.heroList[0].LogicPosition);
                SkillEffect effect = ResourceManager.Instance.LoadObject<SkillEffect>("Prefabs/SkillEffect/Effect_RenMa_hit");
                effect.SetEffectPos(heroLogic.enemyList[0].LogicPosition);
                heroLogic.enemyList[0].DamageHP(30);
            });
            ActionManager.Instance.RunAction(moveTo);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            var moveTo = new MoveToAction(heroLogic.heroList[0], new VInt3(BattleWorldNodes.Instance.heroTransArr[0].position), 1000, () => {
                Debugger.Log("移动完成 = " + heroLogic.heroList[0].LogicPosition);
            });
            ActionManager.Instance.RunAction(moveTo);
        }
    }

    public void OnLogicFrameUpdate() {
        heroLogic?.OnLogicFrameUpdate();
        roundLogic?.OnLogicFrameUpdate();
        ActionManager.Instance.OnLogicFrameUpdate();
    }

    public void OnDestroyWorld() {
        heroLogic.OnDestroy();
        roundLogic.OnDestroy();
    }
}