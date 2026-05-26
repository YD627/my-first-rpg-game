using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAngent;
    private bool haveInteracted = false; // 标记是否已经交互过
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAngent = playerAgent;
        playerAgent.stoppingDistance = 2f; // 设置停止距离，确保玩家在交互范围内停下
        // 设置玩家的目标位置为碰撞点
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
    }
    private void Update()
    {
        if (playerAngent != null && haveInteracted == false && playerAngent.pathPending == false) 
        {
            if(playerAngent.remainingDistance <= playerAngent.stoppingDistance)
            {
                Interact();
                haveInteracted = true; // 标记已经交互过，避免重复交互
            }
        }
    }

    protected virtual void Interact()
    {
        // 这里可以添加交互逻辑，例如打开门、拾取物品等
        Debug.Log("Interacted with " + gameObject.name);
    }
}
