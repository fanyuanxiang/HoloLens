using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeformat : MonoBehaviour
{
    private Text CurrrentTimeText;
    private int hour;
    private int minute;
    private int second;
    private int year;
    private int month;
    private int day;

    // Use this for initialization
    void Start()
    {
        //it  will get current Text object when scene was started ;
        //默认获取当前TextGamneobject （text对象是emptyobject 添加component组件实现的，因此在这里获取对象的component即可以获得到对象的数据）
        CurrrentTimeText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //获取当前时间
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;

        //格式化显示当前时间
        CurrrentTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}/{4:D2}/{5:D2}", hour, minute, second, year, month, day);

#if UNITY_EDITOR
        Debug.Log("W now " + System.DateTime.Now);     //当前时间（年月日时分秒）
        Debug.Log("W utc " + System.DateTime.UtcNow);  //当前时间（年月日时分秒）
#endif
    }
}
