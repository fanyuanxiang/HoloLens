MicroSoft Hololens  2   dev



初始准备：

- 一台 Windows 10 电脑，其中已[安装](https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/install-the-tools)并配置正确的工具
- [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk/) 10.0.18362.0 或更高版本
- 一个[针对开发配置](https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/platform-capabilities-and-apis/using-visual-studio#enabling-developer-mode)的 HoloLens 2 设备
- [Unity Hub](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html)，其中已安装 Unity 2019 LTS 并添加了通用 Windows 平台生成支持模块







### hololens开发：





创建相应的 HoloLens项目unity3d 项目，

1.配置相关player  ：package name 命名给定唯一，不然后面项目会出现包的overwrite 覆盖  等；

使用Windows Mixed Reality 的sdk 开发包。

![1609384271085](C:\Users\fyxdd\AppData\Roaming\Typora\typora-user-images\1609384271085.png)





2.universal Windows Platform 设定![1609384125484](C:\Users\fyxdd\AppData\Roaming\Typora\typora-user-images\1609384125484.png)

默认设定后面发布在HoloLens上时候使用Architectural 使用ARM架构，



3。道路MRTK 相关的基础包：

![1609384380077](C:\Users\fyxdd\AppData\Roaming\Typora\typora-user-images\1609384380077.png)

首先导入Foundation基础包，配置相关的MRTK设定。





#### HoloLens  开发中使用simulation ：

1.show left hand -- hold on shift（left）

2.show right hand -- hold on space bar

3.move hand forward and backward ---middle  scroll

4.select ,air tap or pinch --mouse left click.

---

pointers :



Near Pointers：Poke （按）、Grap（抓取）

 Far Pointers ：Controller Ray（控制光线）   、Gaze（凝视） 、gesture（手势） 、voice （声控）



 

