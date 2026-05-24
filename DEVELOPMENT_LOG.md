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