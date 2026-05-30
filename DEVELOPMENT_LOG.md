# 我的第一款RPG游戏 - 开发日志

## 2026-05-23
完成[01]:成功创建了项目并同步到了Github仓库中

完成[02]:成功导入素材

完成[03]:成功创建了基础的游戏场景

## 2026-05-24
完成[04]:设置了场景的灯光颜色并添加了雾效

完成[05]:为主相机添加PostProcessing效果
- PostProcessing是Unity提供的一种在渲染完成后对图像进行处理的技术，例如添加模糊、锐化、抗锯齿等效果。
- 要个相机设置一个Layer
- Post Processing Layer 设置后处理的层
- Post Processing Volume 设置后处理使用的配置文件
- Post Processing Profile 设置后处理的配置文件

完成[06]:添加NavigationMesh自动导航
- 对于一个障碍物，我们不想其表面会被导航到，可以添加NavMeshModifier组件并启用其中的Override Area属性。接着选取Area Type为Not Walkable。

## 2026-05-25
1. 了解RPG中玩家的移动方式，通过检查鼠标点击位置来确定玩家的移动方向。要给玩家添加NavMesh Agent组件。
2. 实现玩家的移动功能，当玩家点击鼠标时，玩家会向点击位置移动。
```C#
if(Input.GetMouseButtonDown(0))
{
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
}
```
在上面的代码中Input.mousePosition将屏幕坐标转换为射线，然后返回射线对象。

接着做射线检测，检测射线是否击中了场景中的物体。
```C#
bool isCollide = Physics.Raycast(ray, out RaycastHit hit);
if(isCollide)
{
    playerAgent.SetDestination(hit.point);
}
```
在上面的代码中Physics.Raycast方法用于检测射线是否击中了场景中的物体。如果击中了物体，hit.point会返回击中的物体的点。

完成[07]:实现了玩家的移动功能，并为其添加了简单的眼睛和嘴巴

完成[08]:实现了相机跟随玩家的功能
- 通过脚本初始相机和玩家的位置偏移offset，然后不断的在update中更新相机的位置。
- 相机的位置会根据玩家的位置和偏移offset来计算，确保相机始终跟随玩家。

完成[09]:相机视野的缩放
- 通过Input.GetAxis("Mouse ScrollWheel")获取鼠标滚轮的滚动值。
- 根据滚动值，相机的视野会进行缩放。
- 相机的视野范围在32到80之间，避免相机的视野过小或过大。

完成[10]:创建交互父类InteractableObject
- 创建公共交互函数OnClick()：当玩家点击交互物体时，会调用该函数。目前是移动玩家到交互物体的位置并调用Interact函数。
- 创建虚函数Interact()：用于子类重写，实现具体的交互逻辑。目前是打印出交互物体的名称。
- 修改PlayerMove中的代码
```C#
// 根据碰撞物体的标签执行不同的操作
switch (hit.collider.tag)
{
    case "Ground":
        // 如果碰撞了地面，设置玩家的目标位置为碰撞点
        playerAgent.SetDestination(hit.point);
        break;
    case "Interactable":
        // 如果碰撞了可交互物体，调用该物体的交互方法
        hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
        break;
    default:
        break;
}
```

## 2026-05-26
完成[11]:创建了可拾取物品类PickAbleObject和NPC类NPCObject，均继承自InteractableObject。

完成[12]:优化了玩家与可交互物的交互实机，只有当玩家停下移动时，才会调用交互方法。

完成[13]:通过Font Asset Creator(TextMeshPro)创建了自定义字体，让游戏文本支持中文。   


## 2026-05-27
完成[14]:完成了对话框UI的脚本，包括对话框的显示和隐藏。此外还实现了对话框中的继续按钮的点击事件。

完成[15]:将DiaLogueUI类设置为单例模式，确保在游戏过程中只有一个对话框实例。
单例模式是一种设计模式，用于确保一个类只有一个实例，并且提供一个全局访问点。
- 优点:
    1. 方便访问：无需传递引用
    2. 节省内存：只有一个实例
    3. 统一管理：集中控制全局状态
- 缺点:
    1. 全局状态：可能导致代码耦合度高
    2. 测试困难：单例可能使单元测试复杂
    3. 滥用风险：不是所有情况都适合用单例

完成[16]:为玩家添加了第一把武器Scythe，并为镰刀添加了闲置动画WeaponScythe_Idle。该动画是用unity自带的Animation组件实现的。

## 2026-05-28
完成[17]:为镰刀武器添加了攻击动画WeaponScythe_Attack。
- 该动画是用unity自带的Animation组件实现的。
- 动画的播放是在PlayerMove中的OnClick函数中调用的。

完成[18]:创建了武器类Weapon，用于管理武器的属性和行为。
- 包含武器的伤害值和攻击方法。
- 目前实现了播放武器攻击动画的功能。

完成[19]:创建了镰刀和标枪两个武器子类，均继承自Weapon类。
- 镰刀类中实现了攻击方法，用于播放镰刀的攻击动画。并添加了OnTriggerEnter方法，用于检测是否攻击到了敌人。此外在镰刀的MeshCollider中要开启IsTrigger属性。还要给镰刀添加Rigidbody组件(关闭重力，开启Kinematic属性)。

完成[20]:创建PlayerAttack类，用于管理玩家的攻击行为。
- 包含一个Weapon对象，用于存储当前使用的武器。
- 点击空格时会检测是否有武器，如果有则调用武器的攻击方法。

完成[21]:创建了标枪Javelin的预制体并通过Instantiate方法实例化。
- 通过一个空物体作为标枪的父类用于管理标枪的位置和旋转。同时给这个父类挂载标枪类，在标枪类中实现实例化生成并发射标枪的代码
```C#
public GameObject bulletPrefab; // 标枪的子弹预制体
public float bulletSpeed;
public override void Attack()
{
    // 实例化标枪的子弹
    GameObject bulletGo = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation); 
    bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
}
```

## 2026-05-30
完成[22]:实现了一个名为ItemScriptObject的脚本，用于管理物品的属性和行为。
包含：
- 物品ID
- 物品名字
- 物品类型(武器、消耗品)
- 物品描述
- 物品属性列表(Hp, Energy, MentalValue, Speed, Attack)
- 物品图标
- 物品预制体

完成[23]:创建了一个ItemDBSO的脚本，用于管理物品数据库。
- 包含一个ItemScriptObject数组，用于存储所有物品的属性和行为。

完成[24]:创建了一个Tag类，用于管理物品的标签。
- 常量定义Tag标签的字符串，方便别的脚本中使用。

完成[25]:通过截图创建了物品的图标。