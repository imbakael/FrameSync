﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {
    private void Awake() {
        WorldManager.Initialize();
        var playerHeroList = new List<HeroData>();
        var enemyHeroList = new List<HeroData>();
        var heroIdList = new List<int> { 101, 102, 103, 104, 105, 501, 502, 503, 504, 505 };
        for (int i = 0; i < heroIdList.Count; i++) {
            var heroData = new HeroData();
            heroData.hp = 100;
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
