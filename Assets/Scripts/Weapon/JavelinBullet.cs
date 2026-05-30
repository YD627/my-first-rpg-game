using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == Tag.Player) { return; }
        rb.velocity = Vector3.zero;
        rb.isKinematic = true; // 使子弹停止运动
        collider.enabled = false; // 禁用碰撞体，防止再次触发碰撞事件

        Destroy(this.gameObject, 2f); // 2秒后销毁子弹对象
    }
}
