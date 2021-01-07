## unity3d 各个目录的意思

 

# 1.首先，你得理解Unity中各个目录的意思？

我这里说的是移动平台（安卓举例），读，写。所谓读，就是你出大版本的包之后，这个只读的话，就一辈子就这些东西了，不会改变了，不会有其他资源来覆盖或者增加啦。

可写，就是可以加东西进去呗。可能是自己太笨，一开始没怎么注意这意思。竟然往StreamingAssets去实现资源更新（天啦撸）。

 

## Application.StreamingAssetsPath,

StreamingAssets目录必须在Assets根目录下，该目录下所有资源也会被打包到游戏里，不同于Resources目录，该目录下的资源不会进行压缩，同样是只读不可写的。
这里的只可读，不可写，就是除了出大版本的包（重新下载），这里面的东西永远不会变。

　　各平台StreamingAssets路径打印： 
　　Win：E:/myProj/Assets/StreamingAssets 
　　Mac : /myProj/Assets/StreamingAssets 
　　Andorid：jar:file:///data/app/com.myCompany.myProj-1/base.apk!/assets 
　　iOS: /var/containers/Application/E5543D66-83F3-476D-8A8F-49D5332B3763/myProj.app/Data/Raw

## Application.PersistentDataPath

　  应用程序安装后才会出现。该目录独特之处在于是可读，可写的，所以我们一般将下载的AssetBundle存放于此。
　　各平台PersistentDataPath路径打印： 
　　Win：C:/Users/lodypig/Appdata/LocalLow/myCompany/myProj 
　　Mac : /Users/lodypig/Library/Application Support/myCompany/myProj 
　　Andorid：/data/data/com.myCompany.myProj/files 
　　iOS: /var/mobile/Containers/Data/Appliction/A112252D-6B0E-459Z-9D49-CD3EAC6D47D/Documents

## Application.DataPath

　　应用程序目录，即Assets目录。使用Appliction.dataPath访问。只读不可写。
　　各平台DataPath路径： 
　　Win：E:/myProj/Assets 
　　Mac : /myProj/Assets/ 
　　Andorid：/data/app/com.myCompany.myProj-1/base.apk! 
　　iOS: /var/containers/Application/E5543D66-83F3-476D-8A8F-49D5332B3763/myProj.app/Data

综上，也就是说，要实现资源更新，你只有把资源下载到Application.PersistentDataPath目录下才可实现资源更新（增加或者替换），其他目录不可能实现。

 

# 2.理解上面三种目录的关系，Unity游戏加载的资源是如何分配的？（彼此的关系）

首先你得有一个资源服务器（FTP为例），因为StreamingAssets目录是只读的，我们想要实现热更新，StreamingAssets

目录里面的东西一旦第一个版本打出APK的包之后，这里的东西将永远不会变（只读）。由于PersistentDataPath目录是可读可写的，

所以游戏下载资源都会下载到这里面。这样就实现了资源的热更新。

![img](https://www.pianshen.com/images/533/7c1ad3ae8683fd8042eb2fecae63575d.png)

 

注解：绿色的代表流动，可以不断可以改变的资源。红色线代表，读取persistent目录没有的情况下，读StreamingAssets目录，所以，是永远不变的资源。（除非你去重新下载一个apk的包，就不是热更了）

# 3.如何加载本地的资源？

 首先优先判断PersistentDataPath目录下的资源是否存在，因为服务器上的资源都是下载到这里的，最新的资源通过下载到这里并且覆盖，这里的资源

能保持跟服务器一致。（雨松之前讲的UnityAssetBundle例子就是通过加载服务器上的，那个只是一个小案例，不能每次用哪下载到哪，每次都要下载，

这种方式是很不好用的，就第一次用的时候如果资源与服务器不一致，就下载到本地中，即PersistentDataPath目录。）

因为每个游戏一开始出大版本的时候，都会附带大量资源，就是放在StreamingAssets目录，所以，这里存放大量资源。这样减少下载的次数。

其实，换一种说法，PersistentDataPath完全是给StreamingAssets的补丁目录，我是这样理解的。当然，在项目运用中，都需要优先最先资源判断。

#  4.遇到的那些神神神.....坑？

  (1) 不要以为在PC端可以加载的路径，安卓也可以用。

　　我这边因为涉及到WWW加载，贴出我的。

　　这里主要是通过www 如何加载PersistentDataPath和StreamingAssets这两个目录。

　　Application.PersistentDataPath:

``

```c#
/// 
  /// 天呐，一个Per目录，还两种方法加载。这真的是最后我找出来最完美的，可以加载的，之前还有N种版本，就不提了，网上有，我是经过实测，Unity5.3.4版本
  /// 加载PC上安卓平台，加载PC上Standalone，加载安卓真机（APK包），这三个，都是可以加载的（WWW加载），
  /// 
  public` `static` `string` `PERSISTENT_PATH_DATABASE ``//= LGameConfig.LOCAL_URL_PREFIX + Application.persistentDataPath + "/DataBase/";
  {
    get
    {
      #if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
          return`  `"file:///"``+ Application.persistentDataPath + ``"/Test/"``;
      #else
             return`  `"file://"``+ Application.persistentDataPath + ``"/Test/"``;
      #endif
    }
  }
```

　　　　

　　Application.StreamingAssets:

`

```c#
public` `static` `string` `STREAMING_PATH_DATABASE
  {
    //这样写，因为安卓Unity平台是Application.isMobilePlatform==false， 而宏定义中又 ==UNITY_ANDROID。
     //因为我们项目中是需要同时在PC下安卓平台和PC下 Standard平台，哈哈
    get
    {
      if` `(!Application.isMobilePlatform)
      {
        return` `"file://"` `+ Application.dataPath + "/StreamingAssets"` `+ ``"/DataBase/"``;
      }
      else
      {
        return
#if UNITY_ANDROID
    Application.streamingAssetsPath+ ``"/DataBase/"``;
#else
   "file://"` `+ Application.dataPath + ``"/StreamingAssets"` `+ "/DataBase/"``;
#endif
      }
    }
```

`

　　这个加载地址，真的是精华，可能自己太笨，就是搞这个WWW加载安卓StreamingAssets目录，花了大把时间，因为网上，加载方式真的是尼玛一万种，要喷一下，这些人，不实际打到APK测一下，我MDGB呀，坑的我好惨。

 

　（2）不要以为在PC端可以用的方法，在安卓也可以用。

　　　

　　　　　　安卓上跟其他平台不一样，安装后，这些文件实际上是在一个Jar压缩包里，所以不能直接用读取文件的函数去读，而要用WWW方式
　　　　　　读取的代码(假设名为"文件.txt") 

　（3） 安卓资源路径加载，下载问题，真的是这次做AssetBundle最大的障碍。

（4）通过FTP和CDN下载资源的时候对应的 后缀是不同的。

 FTP下载 后面用  "/"  ，即可。

 CDN下载 后面用  "//" ,即可。

（5）不同的加载方式，加载的路径也是不同的。

具体我就不说了。

(6)记得加 加载文件的后缀名

安卓上跟其他平台不一样，安装后，这些文件实际上是在一个Jar压缩包里，所以不能直接用读取文件的函数去读，而要用WWW方式
1.读取的代码(假设名为"文件.txt") 

(7)加载方式，First In PersistentDataPath,Then StreamingAssets



`

```
IEnumerator LoadAnouncementText()
  ``{
    ``string` `strUrl = GetTxtPerststentUrl(anouncementText);
    ``WWW www = ``new` `WWW(strUrl);
    ``yield` `return` `www;
    ``if` `(www.error == ``null``)
    ``{
      ``mAnoucementText = ConvertByteToString(www.bytes);
    ``}
    ``else` `if` `(www.isDone)
    ``{
      ``string` `strPerUrl = GetTxtStreamUrl(anouncementText);
      ``www = ``new` `WWW(strPerUrl);
      ``yield` `return` `www;
      ``if` `(www.error == ``null``)
      ``{
        ``mAnoucementText = ConvertByteToString(www.bytes);
      ``}
      ``else` `if` `(www.isDone)
      ``{
        ``Debug.LogError(``"下载当前表出错"` `+ www.error.ToString());
      ``}
    ``}
  ``}
  string` `GetTxtStreamUrl(``string` `name)
  ``{
    ``return` `STREAMING_PATH_DATABASE + name + ``".txt"``;
  ``}
   ``string` `GetTxtPerststentUrl(``string` `name)
  ``{
    ``return` `PERSISTENT_PATH_DATABASE + name + ``".txt"``;
```

`



![复制代码](https://www.pianshen.com/images/134/69c5a8ac3fa60e0848d784a6dd461da6.gif)

```
 string GetScenePath(string fileName)
    {
       string path =DataUrl.GetFilePersistentUrl(fileName)+".unity3d";
       // string path= DataUrl.LOCAL_URL_PREFIX + Application.dataPath + "/StreamingAssets/" + "Scene_Main" + ".unity3d";
        //读取Per目录的时候不需要加prefix,但是读取Streaming目录时候需加上prefix
        bool isPersistentDataPath = System.IO.File.Exists(path);
        if (!isPersistentDataPath)
        {
            path =  DataUrl.GetFileStreamingUrl(fileName)+ ".unity3d";
            if (!System.IO.File.Exists(path))
            {
                Debug.LogError("Per，Stream目录 scene bundle都不存在");
                return null;
            }
        }

        return DataUrl.LOCAL_URL_PREFIX+ path;
    }

DataUrl.cs
public static string GetFilePersistentUrl(string path)
    {
        return Application.persistentDataPath+"/" + path;
    }

    public static string GetFileStreamingUrl(string path)
    {
        return Application.streamingAssetsPath+"/" + path;
    }
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    public static readonly string LOCAL_URL_PREFIX = "file:///";
#else
    public static readonly string LOCAL_URL_PREFIX="file://";
#endif
```