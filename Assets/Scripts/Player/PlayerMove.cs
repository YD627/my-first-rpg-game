using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 检测鼠标左键点击，并且确保点击不是在UI元素上
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 检查射线是否与任何物体碰撞
            bool isCollide = Physics.Raycast(ray, out RaycastHit hit);
            if(isCollide)
            {
                // 根据碰撞物体的标签执行不同的操作
                switch (hit.collider.tag)
                {
                    case Tag.Ground:
                        // 如果碰撞了地面，设置玩家的目标位置为碰撞点
                        playerAgent.stoppingDistance = 0f; // 设置停止距离为0，确保玩家直接移动到目标位置
                        playerAgent.SetDestination(hit.point);
                        break;
                    case Tag.Interactable:
                        // 如果碰撞了可交互物体，调用该物体的交互方法
                        hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
