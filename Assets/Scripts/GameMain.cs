using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {
    private void Awake() {
        WorldManager.Initialize();
        List<HeroData> playerHeroList = new List<HeroData>();
        List<HeroData> enemyHeroList = new List<HeroData>();
        List<int> heroIdList = new List<int> { 101, 102, 103, 104, 105, 501, 502, 503, 504, 505 };
        for (int i = 0; i < heroIdList.Count; i++) {
            HeroData heroData = new HeroData();
            if (i < 5) {
                heroData.id = heroIdList[i];
                heroData.seatid = i;
                playerHeroList.Add(heroData);
            } else {
                heroData.id = heroIdList[i];
                heroData.seatid = i - 5;
                enemyHeroList.Add(heroData);
            }
        }
        WorldManager.CreateBattleWorld(playerHeroList, enemyHeroList);
    }

    private void Update() {
        WorldManager.OnUpdate();
    }

    private void OnDestroy() {
        WorldManager.DestroyWorld();
    }
}
