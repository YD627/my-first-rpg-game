using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public GameObject bulletPrefab; // 标枪的子弹预制体
    public float bulletSpeed;
    public override void Attack()
    {
        // 实例化标枪的子弹
        GameObject bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation); 
        bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
