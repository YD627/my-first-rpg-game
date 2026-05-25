using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10.0f; // 摄像机缩放速度

    private Vector3 offset; // 摄像机与玩家之间的偏移量
    private Transform playerTransform;  // 玩家位置
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 每帧更新摄像机位置，使其跟随玩家
        transform.position = playerTransform.position + offset;

        // 获取鼠标滚轮输入
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView -= scrollInput * zoomSpeed; // 根据滚轮输入调整摄像机的视野
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 32, 80);
    }
}
