using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager {

    private static BattleWorld battleWorld;
    public static void Initialize() {

    }

    public static void CreateBattleWorld(List<HeroData> playerHeroList, List<HeroData> enemyHeroList) {
        battleWorld = new BattleWorld();
        battleWorld.OnCreateWorld(playerHeroList, enemyHeroList);
    }

    public static void OnUpdate() {
        if (battleWorld != null) {
            battleWorld.OnUpdate();
        }
    }

    public static void DestroyWorld() {
        battleWorld.OnDestroyWorld();
    }
}
