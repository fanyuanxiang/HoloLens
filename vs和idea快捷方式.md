[![复制代码](https://common.cnblogs.com/images/copycode.gif)](https://common.cnblogs.com/images/copycode.gif)

```
快捷搜索：Ctrl+F (Match Case:区分大小写，Words:全字匹配，Regex:正则匹配)

批量替换：Ctrl+R

全局搜索：Ctrl+N

转到定义：F4注释：选中之后按Ctrl+/（1：二次取消注释）（2：块注释Ctrl+Shift+/）（3：在一个方法或类的开头，输入/**，然后按回车,自动根据参数和返回值生成注释模板）

查找所有引用：鼠标选择代码Alt+F7(也可以鼠标右键Find Usages)

快捷添加包：鼠标选中到未添加包的代码然后 Alt+Enter回车

全局重命名：Shift+F6

快速给变量构建Getter,Setter，快速给变量构建构造函数：选中变量然后Alt+Insert(也可以鼠标右键Generate)
回到上一步：ctrl+alt+左
回到下一步：ctrl+alt+右 
运行项目：Shift+F10 
启动调试：Shift+F9 
具体调试(快捷键后面三个我一般习惯用鼠标点击)： {F9：跳到下一个断点，如果没有就执行程序到结束
F8：step over 点击红色箭头指向的按钮，程序向下执行一行（如果当前行有方法调用，这个方法将被执行完毕返回，然后到下一行） 
F7：step into 点击红色箭头指向的按钮，程序向下执行一行。如果该行有自定义方法，则运行进入自定义方法（不会进入官方类库的方法） Alt+Shift+F7：force step into 该按钮在调试的时候能进入任何方法。 Shift+F8：step out 如果在调试的时候你进入了一个方法(如f2())，并觉得该方法没有问题，你就可以使用stepout跳出该方法，返回到该方法被调用处的下一行语句。 
Ctrl+F2：停止调试 
}
```

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](https://common.cnblogs.com/images/copycode.gif)

 **Visual Studio：**

[![复制代码](https://common.cnblogs.com/images/copycode.gif)](https://common.cnblogs.com/images/copycode.gif)

```
快捷搜索：Ctrl+F (Match Case:区分大小写，Words:全字匹配，Regex:正则匹配)

批量替换：Ctrl+H

全局搜索：Ctrl+Shift+F

转到定义：F12

注释：
Ctrl + E + C （注释）　　<=>　　 Ctrl + K + C （注释）
Ctrl + E + U （取消注释）　　<=>　　Ctrl + K + U （取消注释）
在一个方法或类的开头，输入///,自动根据参数和返回值生成注释模板
查找所有引用：Shift+F12(也可以鼠标右键)

快捷添加包：鼠标移动到需要添加引用的代码，会有有一个光标选择或者选中需要添加引用的代码Ctrl+.

全局重命名：Ctrl+R(也可以鼠标右键)

快速给变量构建Getter,Setter:选中代码然后Ctrl+R+E(因为C#有get;set简写，所以感觉不太实用)

回到上一步：ctrl+-

回到下一步：ctrl+Shift+-

运行项目：Shift+F5

启动调试：F5

具体调试(快捷键后面三个我一般习惯用鼠标点击)： 
{
F5：跳到下一个断点，如果没有就执行程序到结束

F10：逐过程（不进入函数内部，直接获取函数运行结果）

F11：逐语句（会进入函数），如果想跳出函数按shift+F11，如果对某个函数的使用定义不清楚，按F12转到定义。

F9：添加断点或取消断点（或者点击代码行最左边的灰色行）
}
```