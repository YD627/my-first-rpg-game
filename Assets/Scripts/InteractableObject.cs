using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    public void OnClick(NavMeshAgent playerAgent)
    {
        // 设置玩家的目标位置为碰撞点
        playerAgent.SetDestination(transform.position);

        Interact();
    }

    protected virtual void Interact()
    {
        // 这里可以添加交互逻辑，例如打开门、拾取物品等
        Debug.Log("Interacted with " + gameObject.name);
    }
}
