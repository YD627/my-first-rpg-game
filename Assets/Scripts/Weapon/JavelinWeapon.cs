using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public GameObject bulletPrefab; // 标枪的子弹预制体
    public float bulletSpeed;
    private GameObject bulletGo; // 标枪的子弹实例
    private Collider bulletCollider; // 标枪子弹的碰撞体

    private void Start()
    {
        SpawBullet();
    }
    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null; // 解除子弹与武器的父子关系
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            // 发射时启用碰撞检测
            if (bulletCollider != null)
            {
                bulletCollider.enabled = true;
            }
            bulletGo = null;
            bulletCollider = null;
            Invoke("SpawBullet", 1f); // 1秒后生成新的标枪子弹
        }
        else
        {
            return;
        }
        
    }
    private void SpawBullet()
    {
        // 实例化标枪的子弹
        bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;
        // 获取子弹的碰撞器并禁用
        bulletCollider = bulletGo.GetComponent<Collider>();
        if (bulletCollider != null)
        {
            bulletCollider.enabled = false; // 生成时禁用碰撞
        }
    }
}
