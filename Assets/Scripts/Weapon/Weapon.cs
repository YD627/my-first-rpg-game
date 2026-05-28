using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackValue; // 攻击力
    public virtual void Attack()
    {
        // 这里可以添加攻击逻辑，例如播放攻击动画、检测敌人等
        Debug.Log("Weapon attacks with " + attackValue + " damage.");
    }
}
