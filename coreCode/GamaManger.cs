using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManger : MonoBehaviour
{

    // SceneA.
    // SceneA is given the sceneName which will
    // load SceneB from the Build Settings   这里需要在setting 中添加相关的场景进来


    //绑定按钮点击触发该函数，进行加载初始化scene 数据 并达到跳转的效果。   这是C# 6 的lambda 语法表表达形式
    public void OnStartGame(string ScneName) =>

         //Application.LoadLevel(ScneName);//读取场景通过scneName   这是相关unity 5.6 之前版本的函数。
         SceneManager.LoadScene(ScneName);
}
