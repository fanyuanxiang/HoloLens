using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConsoleApp2;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

public class urlLoad : MonoBehaviour
{

    private void Start()
    {

        //测试绑定的text 数据
        //text.text = "dafdafa";

        //我们的接口
        string url = "http://210.12.220.75:15003/iotserver/area/detail/198";

        //调用自己封装的函数获取token
        string token = HttpUitls.GetToken();
        //Console.WriteLine("token:" + token);
        Debug.Log("token =" + token);

        //调用直接封装的函数获取后天返回的字符串对象
        string result = HttpUitls.GetWithToken(token, url);

        //从后台获取到的数据string 将字符串对象转换成json数据格式
        //Console.WriteLine("result=" + result);
        JObject jObject = (JObject)JsonConvert.DeserializeObject(result);
        //获得返回对象json
        Console.WriteLine("json=" + jObject);

        //获得指定json数据对象中的数据
        string data = jObject["data"].ToString();
        //Console.WriteLine("data===" + data);
        string createBy = jObject["data"]["ws"]["createBy"].ToString();
        //Console.WriteLine("createBy====" + createBy);
       // Debug.Log("create=" + createBy);


        //给ui面板传入相关数据
        Text Twsname = GameObject.Find("wsname").GetComponent<Text>();
        string wsname = jObject["data"]["ws"]["wsname"].ToString();
        Debug.Log(wsname);
        Twsname.text = " " + wsname;

        Text Taddress = GameObject.Find("address").GetComponent<Text>();
        string address = jObject["data"]["ws"]["address"].ToString();
        Taddress.text = " " + address;

        Text Tarea = GameObject.Find("area").GetComponent<Text>();
        string area = jObject["data"]["ws"]["area"].ToString();
        Tarea.text = " " + area;

        Text Ttype = GameObject.Find("type").GetComponent<Text>();
        string type = jObject["data"]["ws"]["type"].ToString();
        Ttype.text = " " + type;

      

    }
    // Update is called once per frame
    void Update()
    {

    }
}
