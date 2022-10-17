using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLogic : LogicObject {

    protected VInt hp;
    protected VInt atk;
    protected VInt def;
    protected VInt agl;
    protected VInt rage;

    public VInt HP { get { return hp; } }
    public VInt MaxHP { get; protected set; }
    public VInt Atk { get { return atk; } }
    public VInt Def { get { return def; } }
    public VInt Agl { get { return agl; } }
    public VInt Rage { get { return rage; } }
    public VInt MaxRage { get { return 100; } }

    public int ID => HeroData.id;
    public HeroData HeroData { get; private set; }
    public HeroRender HeroRender { get; private set; }
    public HeroTeamEnum HeroTeam { get; private set; }

    public HeroLogic(HeroData heroData, HeroTeamEnum heroTeam) {
        HeroData = heroData;
        HeroTeam = heroTeam;
        hp = heroData.hp;
        atk = heroData.atk;
        def = heroData.def;
        agl = heroData.agl;
        rage = heroData.atkRage;
        MaxHP = 100;
    }
    public override void OnCreate() {
        base.OnCreate();
        HeroRender = (HeroRender)RenderObj;
        //Debugger.Log("heroname = " + RenderObj.gameObject.name);
    }

    public override void OnLogicFrameUpdate() {
        base.OnLogicFrameUpdate();
    }

    public void DamageHP(VInt damageHp) {
        if (damageHp == 0) {
            return;
        }
        hp -= damageHp;
        if (hp <= 0) {
            hp = 0;
            HeroDeath();
        } else {
            PlayAnim("OnHit");
        }
        Debugger.Log("id = " + ID + ", 损失血量 = " + damageHp + ", 剩余血量 = " + hp);
#if RENDER_LOGIC
        float hpRate = hp.RawFloat / MaxHP.RawFloat;
        HeroRender.UpdateHPHud(damageHp.RawInt, hpRate);
#endif
    }

    private void HeroDeath() {
        
    }

    public void PlayAnim(string animName) {
#if RENDER_LOGIC
        HeroRender.PlayAnim(animName);
#endif
    }

    public override void OnDestroy() {
        base.OnDestroy();
    }
}
