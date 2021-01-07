# [Unity3D中JavaScript与C#对比](https://www.cnblogs.com/yangmingyu/p/6928222.html)

 第一个也是最容易区分的一点就是声明变量和方法。
JavaScript的脚本：

\1. private var cubeTransform; 

在C#中，同样的代码则会是：

\1. private Transform cubeTransform; 

这对方法同样适用，在C#中，一个方法什么值也没有返回，那么他的返回值为 void 类型，但是在JavaScript中则可以省略。

类的继承也是不同的。在JavaScript和C#中，方法是隐型并且不可重载，除非方法声明中添加虚拟关键字。不同的是C#只重载那些包含重载关键字的方法。而JavaScript不需要关键词，只要重载类方法就可继承他们。我们来看一个JavaScript类继承的例子：

\1. class Weapon extends Item 

\2. { 

\3.    //Class members and declarations 

\4. } 

在C#中，同样的代码则会是：

\1. public class Weapon : Item 

\2. { 

\3.    //Class members and declarations 

\4. } 

这就是这两种代码的主要区别，实际上他需要定义全部的东西，像执行产出代码，访问GameObject和组件，激光投射等等。还有一些其他的不同点，比如导入函数库的关键字（在JavaScript中用“Import”，在C#中使用“using”），但是这些声明和关键字的不同就比较容易明白了。

\1. //do this: 

\2. private var score:int; 

\3. //instead of this: 

\4. private var score; 

======================================================

使用JavaScript来获取GameObject很简单，你只需要调用Find（）静态方法，并把想要的GameObject的名称作为参数：

 

\1. private var pawnGO:GameObject; 

\2. function Awake() 

\3. { 

\4.   pawnGO = GameObject.Find("Pawn"); 

\5. } 

 

用C#也很相似：

 

\1. using UnityEngine; 

\2. using System.Collections; 

\3.  

\4. public class PawnGetter : MonoBehaviour 

\5. { 

\6.   private GameObject pawnGO; 

\7.  

\8.   void Awake () 

\9.   { 

\10.     pawnGO = GameObject.Find("Pawn"); 

\11.   } 

\12. } 

在不考虑两种语言的关键字和格式不同的情况下，代码是完全一样的（第一个代码的第四行和第二个代码的第八行是相同的）。不管代码是强类型还是弱类型，GameObject.Find（）方法总是会返回一个GameObject值。

 

 

现在，让我们看看如何获得一个GameObject上的组件。假设“PawnMover”组件赋给“Pawn”GameObject，让我们来看看如何使用JavaScript获得“PawnMover”组件：

\1. private var pawnGO:GameObject; 

\2. private var pmSC:PawnMover; 

\3. function Awake() 

\4. { 

\5.   pawnGO = GameObject.Find("Pawn"); 

\6.   pmSC = pawnGO.GetComponent("PawnMover"); 

\7. } 

基本上，要获得“PawnMover”组件，我们所需要做的就是从“Pawn”GameObject调用GetComponent（）方法，并把所需组件的名称作为参数。除了名称，我们也可以通过组件类型作为参数，但是像上面的例子我们用名字就行了。因为JavaScript是弱类型，返回值为组件，我们不需要把组件给PawnMover 类作为结果。在C#中也是一样的：

\1. using UnityEngine; 

\2. using System.Collections; 

\3.  

\4. public class PawnGetter : MonoBehaviour 

\5. { 

\6.   private GameObject pawnGO; 

\7.   private PawnMover pmSC; 

\8.  

\9.   void Awake() 

\10.   { 

\11.     pawnGO = GameObject.Find("Pawn"); 

\12.     //returns a CS0266 error 

\13.     pmSC = pawnGO.GetComponent("PawnMover");//<=returns a CS0266 error 

\14.     //this is the right way to do it when using C# 

\15.     pmSC = pawnGO.GetComponent< PawnMover >(); 

\16.   } 

\17. } 

用C#就不可能只是调用GetComponent（）方法并把该组件的名称作为参数了，这样他会导致错误CS0266，也就是说C#不能从一个类型隐型转换为另一个格式。因为C#属于强类型，我们不能把组件类型转换为PawnMover类型。我们需要调用一个方法传递这个类型，强制GetComponent（）方法返回“PawnMover”对象而不是组件。

======================================================

 

这系列第三节，解释JavaScript和C#在Unity3d游戏引擎中编程时有什么不同。建议你最好先去阅读第一和第二节，方便理解这节内容。

在第三节中，主要讲解用JavaScript和C#让一个GameObject向前移动有什么不同。现在我们来看一段使用JavaScript让一个GameObject向前移动的代码：

 

 

public var goTransform:Transform;

private var vel:int = 2;//how fast the game object is being moved 

 

 

function Awake() 

{

//get this GameObject's Transform

 goTransform = this.GetComponent(Transform);

}

 

 

// Update is called once per frame 

function Update() 

{

//moves the containing GameObject forward

goTransform.position.z = goTransform.position.z + vel;

}

把这个脚本的目的是在每一个更新周期使goTransform的z轴坐标增加来控制让goTransform向前移动的，现在让我们看看用C#编写代码会是什么样的：

using UnityEngine; 

using System.Collections;  

public class PawnMover : MonoBehaviour 

{

public Transform goTransform; 

private int vel = 2;//how fast the game object is being moved 

 

void Awake() 

  { 

​     //get this GameObject's Transform 

​    goTransform = this.GetComponent<Transform>(); 

  }  

// Update is called once per frame 

   void Update() 

  { 

​     //returns a CS1612 error 

​    goTransform.position.z=goTransform.position.z + vel;//<=returns a CS1612 error 

​     //this is the right way to do it when using C# 

goTransform.Translate(Vector3.forward * vel);//moves the containing GameObject forward 

 

  } 

} 

这里我们可以看到，在C#中不能像JavaScript脚本中那样直接改变goTransform的z轴坐标值来移动，这样会产生CS1612error，因为我们是要改变一个值而不是引用该值。为了避免这个错误，在用C#编写脚本时，我们用方法移动GameObejct，比如Translate()、 Rotate()、 RotateAround()等等。这些方法都是Transform类得公共成员变量。

=======================================================

 


     yielding pauses代码对于游戏编程是相当有用的，你可以用它更好的控制你游戏中的事件。无论是用JavaScript或C#都不能简单的中断Update（）方法。相信你已经猜到了，我们今天要议论的是这两种语言对此的解决方案有什么不同。我们这节中会给出这种解决方案的常用实例。现在我们来看看JavaScript是如何yield的：

 

 

private var textS:String; 

private var counter:float = 0; 

function Update () 

{ 

  //call the function that waits three seconds to execute 

  WaitThreeSeconds(); 

} 

//This function waits three seconds before executing 

function WaitThreeSeconds() 

{ 

  //Waits three seconds 

  yield WaitForSeconds(3); 

  //converts the counter to a String and stores its value in textS 

  textS = "Three seconds has passed, now I'm counting..."+counter.ToString(); 

  //add one to the counter 

  ++counter; 

} 

 

function OnGUI() 

{ 

  //The next line displays the first line of text 

  GUI.Label(new Rect(20,20,250,20), "I will start counting in 3 seconds."); 

  //Displays the counter 

  GUI.Label(new Rect(20,40,500,20),textS); 

} 

这个代码在屏幕上输出了两个文本，第一行会在开始不久就被渲染出来，第二行只会在暂停3秒后出现，yield代码只会执行一次，然后再正常执行Update（）循环（也就是说不会再等三秒在去执行一次WaitThreeSeconds（））。有一点要注意，我们知道能在函数内用yield，Update（）方法是不能被暂停的。

现在来看看C#代码：

using UnityEngine; 

using System.Collections; 

public class Yield : MonoBehaviour 

{ 

  private string textS; 

  private float counter = 0; 

  void Update () 

  { 

​    //doesn't generate an error but doesn't work either. 

​    WaitThreeSeconds();//<=does nothing 

​    //start the coroutine named WaitThreeSeconds 

​    StartCoroutine("WaitThreeSeconds");//<=right 

  } 

  //Waits three seconds before executing 

  IEnumerator WaitThreeSeconds() 

  { 

​    //Waits three seconds 

​    yield return new WaitForSeconds(3); 

​    //converts the counter to a String and stores its value in textS 

​    textS = "Three seconds has passed, now I'm counting..."+counter.ToString(); 

​    //add one to the counter 

​    ++counter; 

  } 

   

  void OnGUI() 

  { 

​    //The next line displays the first line of text 

​    GUI.Label(new Rect(20,20,250,20), "I will start counting in 3 seconds."); 

​    //Displays the counter 

​    GUI.Label(new Rect(20,40,500,20),textS); 

  } 

} 

主要区别就是我们在C#中不能把yield放在函数中使用，需要使用IEnumerator接口，之所以这样只是因为C#就是这么设计的（关于IEnumerator接口的更多信息可以在http://www.devarticles.com/c/a/C-Sharp/Interface-IEnumerable-and-IEnumerator-in-C-sharp/2/这里找到）我们不能像调用普通函数那样调用WaitThreeSeconds()，即便那么做也不会有任何反应的。所以我们的解决办法就是想调用协同那样调用WaitThreeSeconds()。（例如14行）

另外一个区别就是在21行，我们要用yield return new WaitForSeconds(3)来替换 yield WaitForSeconds(3)代码，因为我们用IEnumerator接口需要一个返回值。

====================================================

 


先来看点儿基础知识：何为射线投射？顾名思义，就是用程序模拟了一个现实生活中被打出的一道射线（“Ray”，译者：O(∩_∩)O哈哈~我的名字）。在游戏编程中相当有用，Raycast类可以返回源点到射线碰撞某物体的距离（有的时候被用作得到碰撞物体的名称）。Unity3D没有单独的Raycast类，它是被Physics, RaycastHit 和 Ray 功能分散的类。

我来举一个用JavaScript投射射线的例子：

 

//Creates a ray object 

private var ray : Ray; 

//creates a RaycastHit, to query informarion about the objects that are colliding with the ray 

private var hit : RaycastHit = new RaycastHit(); 

//Get this GameObject's transform 

private var capsTrans : Transform; 

 

function Awake() 

{ 

//get this Transform 

capsTrans = this.GetComponent(Transform); 

} 

// Update is called once per frame 

function Update () 

{ 

//recreate the ray every frame 

ray = new Ray(capsTrans.position, Vector3.left); 

//Casts a ray to see if something have hit it 

if(Physics.Raycast(ray.origin,ray.direction, hit, 10))//cast the ray 10 units in distance 

{ 

//Collision has happened, print the distance and name of the object into the console 

Debug.Log(hit.collider.name); 

Debug.Log(hit.distance); 

} 

else 

{ 

//the ray isn't colliding with anything 

Debug.Log("none") 

} 

} 

 

来看看它是如何工作的：

首先，我们需要创建一个射线对象（Ray object），并且每帧都要重新创建一次（例如第2和20行），该射线类具备如光线投射的方向和来源等属性。

然后，我们需要一个RaycastHit类对象，获取射线与其他GameObject的碰撞发生时的距离和一些其他的详细信息。

接下来，我们需要从Physics类中调用Raycast（）静态方法（例如23行），这个方法将实际的投射出一道射线，记录下射线源点、投射方向、RaycastHit 对象和距离这些参数，然后把距离和碰撞结果传递到RaycastHit对象。

乍一听起来可能有些乱，但是多尝试几回就熟练了（更多信息请查看http://unity3d.com/support/documentation/ScriptReference/Physics.Raycast.html），接下来看看C#代码：

 

using UnityEngine; 

using System.Collections; 

 

public class Raycast : MonoBehaviour 

{ 

//Creates a ray object 

private Ray ray; 

//creates a RaycastHit, to query informarion about the objects that are colliding with the ray 

private RaycastHit hit = new RaycastHit(); 

//Get this GameObject's transform 

private Transform capsTrans; 

 

void Awake() 

{ 

//get this Transform 

capsTrans = this.GetComponent<Transform>(); 

} 

// Update is called once per frame 

void Update () 

{ 

//recreate the ray every frame 

ray = new Ray(capsTrans.position, Vector3.left); 

//Casts a ray to see if something have hit it 

if(Physics.Raycast(ray.origin, ray.direction, out hit, 10))//cast the ray 10 units in distance 

{ 

//Collision has happened, print the distance and name of the object into the console 

Debug.Log(hit.collider.name); 

Debug.Log(hit.distance); 

} 

else 

{ 

//the ray isn't colliding with anything 

Debug.Log("none") 

} 

} 

} 

 

当投射射线时，这两种编程语言之间唯一的区别在第28行代码上。现在来看看我们怎么Out关键词来传递hit对象呢？因为在C#中Raycast（）方法需要RaycastHit参数做参考，这恰巧也是out关键词做的事情。所以我们用传递一个Raycast（）的参考来代替传递对象（就好像我们在JavaScript中做的那样）。（更多信息请参考http://msdn.microsoft.com/en-us/library/t3c3bfhx(v=vs.80).aspx）。