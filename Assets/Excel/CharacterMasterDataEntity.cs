using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterMasterDataEntity// : MonoBehaviourは付けない
{
    //publlicでExcel 1データの１行目と同じパラメータ
    public string ID;
    public int HpMax;
    public int HpMin;
    public int DistanceX;
    public int DistanceY;
    public int JumpTime;

}
