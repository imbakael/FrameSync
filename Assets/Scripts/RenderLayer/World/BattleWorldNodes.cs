using UnityEngine;

public class BattleWorldNodes : SingletonMono<BattleWorldNodes> {
    public Transform[] heroTransArr;
    public Transform[] enemyTransArr;
    public Transform HUDWindowTrans;
    public Camera camera3D;
    public Camera uiCamera;
}
