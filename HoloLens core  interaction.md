HoloLens 中使用MTRK 

#### Introduction：

 MRTK-Unity is a Microsoft-driven project that provides a set of components and features, used to accelerate cross-platform MR app development in Unity. Here are some of its functions: 



## core  interaction

Learn about how to use MRTK to achieve some of the most widely used common interaction patterns in mixed reality.

- How to simulate input interactions in Unity editor?
- How to grab and move an object?
- How to resize an object?
- How to move or rotate an object with precision?
- How to make an object respond to input events?
- How to add visual feedback?
- How to add audio feedback?
- How to use HoloLens 2 style button prefabs?
- How to make an object follow you?
- How to make an object face you?

详细参考：https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/unity/mrtk-101



## 1、How to grab and move an object?

add  component  ——

Attach the **ObjectManipulator.cs** and **NearInteractionGrabbable.cs** scripts to make an object grabbable. ObjectManipulator supports both near and far interactions. You can grab and move an object with HoloLens 2's articulated hand tracking input(near), hand ray(far), motion controller's beam(far), and HoloLens gaze cursor and air-tap(far).



## 2、How to resize an object?

**ObjectManipulator.cs** supports two-handed scale/rotation. The script works with various input types, such as HoloLens 2's articulated hand input, HoloLens 1's gaze + gesture input, and Windows Mixed Reality immersive headset's motion controller input.



## 3、How to add visual feedback?

----

Assign **Interactable.cs** to an object. In the inspector, <u>add target object and create a new theme. Using Interactable's theme profiles</u>, you can easily add visual feedback to all available input interaction states.

 可以给定对象一个相应事件变化，（color）Default 、focus 、pressed、Grab...

Interactable provides various types of themes including the shader theme, which allows you to control properties of the shader per interaction state.

- [Learn more about Interactable in the MRTK documentation](https://microsoft.github.io/MixedRealityToolkit-Unity/Documentation/README_Interactable.html)

Another important building block for visual feedback is the **MRTK Standard Shader**. With MRTK Standard Shader, you can easily add visual feedback effects such as hover light and proximity light. Since MRTK Standard shader performs less computation than the Unity Standard shader, you can create a performant experience.

Create a new material and select the Shader 'Mixed Reality Toolkit > Standard'. Or you can pick one of the existing materials that use MRTK Standard Shader.



## 4、How to add audio feedback?

Add **AudioSource** to an object. Then, in the scripts that expose input events(e.g. Interactable.cs or PointerHandler.cs), assign the object with AudioSource to the event and select **AudioSource.PlayOneShot()**. You can use your audio clips or choose one from MRTK's audio assets.



##  5、How to use HoloLens 2 style button prefabs?

MRTK provides various types of HoloLens 2's shell (OS) style buttons, including visual feedback like proximity light, compressing box, and a ripple effect on the button surface that improve the user's confidence.

Button prefabs in MRTK：Examples of the button prefabs under `MRTK/SDK/Features/UX/Interactable/Prefabs` folder



## 6、How to make an object follow you?

<u>Assign **RadialView.cs** or</u> **Follow.cs** script to an object. It's part of the Solver script series that allows you to achieve various types of object positioning in 3D space. **SolverHandler.cs** will be automatically added. Below is an example of RadialView configuration to achieve 'lazy follow' tag-along behavior just like the Start menu in the HoloLens shell. You can specify the minimum/maximum distance and minimum/maximum view degrees. The example below shows positioning the object between 0.4 m and 0.8-m range within 15°. Adjust Lerp Time values to make the positional update faster or slower.



## 7、How to make an object face you?

Assign **Billboard.cs** script to an object. It will always face you, whatever your position. You can specify the pivot axis option.





## 8、How to make an component enable or disable?



https://unity3d.com/cn/learn/tutorials/topics/scripting/enabling-and-disabling-components?playlist=17117

教程代码实例：

示例：控制一个灯光组件component的enabled 和 able，

说明：在组件中enable是一个bool类型的标记，我们通过改变他的true和false 去变更组件是否可用的属性。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablelight : MonoBehaviour {
    private Light myLight;//定义一个灯光变量


    void Start ()
    {
        myLight = GetComponent<Light>();//获取脚本所在物体的灯光组件
    }


    void Update ()
    {
        //点击空格键切换灯光开关状态
        if(Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
```





## 9、Working with Unity's 3D Text (Text Mesh) and UI Text

Unity assumes all new elements added to a scene are one Unity Unit in size, or 100% transform scale. One Unity unit translates to about 1 meter on HoloLens. For fonts, the bounding box for a 3D TextMesh comes in by default at about 1 meter in height.

 *Blurry default text in Unity* 



 ![Working with Fonts in Unity](https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/unity/images/640px-hug-text-03.png) 

 Most visual designers use points to define font sizes in the real world. There are about 2835 (2,834.645666399962) points in 1 meter. Based on the point system conversion to 1 meter and Unity's default <u>**Text Mesh** font size of 13, the simple math of 13 divided by 2835 equals 0.0046</u> (0.004586111116 to be exact) which provides a good standard scale to start with (some may wish to round to 0.005). Scaling the text object or container to these values will not only allow for the 1:1 conversion of font sizes in a design program, but also provides a standard so you can maintain consistency throughout your experience. 







When adding a <u>**UI or canvas-based text**</u> element to a scene, the size disparity is greater still. The differences in the two sizes are about 1000%, which would bring the scale factor for UI-based text components to 0.00046 (0.0004586111116 to be exact) or 0.0005 for the rounded value.

![Unity UI Text with optimized values](https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/unity/images/hug-text-04-1000px.png)
*Unity UI Text with optimized values*

 ![Unity 3D Text Mesh with optimized values](https://docs.microsoft.com/zh-cn/windows/mixed-reality/develop/unity/images/hug-text-05-1000px.png)
*Unity 3D Text Mesh with optimized values* 





### The minimum legible font size

| Distance                             | Viewing angle | Text height   | Font size      |
| :----------------------------------- | :------------ | :------------ | :------------- |
| 45 cm (direct manipulation distance) | 0.4°-0.5°     | 3.14–3.9mm    | 8.9–11.13pt    |
| 2 m                                  | 0.35°-0.4°    | 12.21–13.97mm | 34.63-39.58 pt |

### The comfortably legible font size

| Distance                             | Viewing angle | Text height  | Font size     |
| :----------------------------------- | :------------ | :----------- | :------------ |
| 45 cm (direct manipulation distance) | 0.65°-0.8°    | 5.1-6.3 mm   | 14.47-17.8 pt |
| 2 m                                  | 0.6°-0.75°    | 20.9-26.2 mm | 59.4-74.2 pt  |



