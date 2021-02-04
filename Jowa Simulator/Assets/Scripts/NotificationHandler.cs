using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationHandler : MonoBehaviour
{
    private System.TimeSpan interval;
    private void BuildDefaultNotifChannel()
    {
        string channel_id = "default";
        string title = "Default Channel";
        Importance importance = Importance.Default;
        string desc = "Default channel for this game";

        AndroidNotificationChannel channel = new AndroidNotificationChannel(channel_id, title, desc, importance);
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    private void BuildRepeatNotifChannel()
    {
        string channel_id = "repeat";
        string title = "Repeat Channel";
        Importance importance = Importance.Default;
        string desc = "Channel for repeat notifs";

        AndroidNotificationChannel channel = new AndroidNotificationChannel(channel_id, title, desc, importance);
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void Awake()
    {
        BuildDefaultNotifChannel();
        BuildRepeatNotifChannel();
    }

    private void Start()
    {
        interval = new System.TimeSpan(2, 0, 0);
    }

    public void ChangeInterval()
    {
        Debug.Log("Notification interval changed!");
        interval = new System.TimeSpan(0, 0, 10);
    }

    public void SendDefaultNotif()
    {
        string title = "Attention!";
        string text = "Don't forget to give your jowa a visit. Play Jowa Simulator now!";

        System.DateTime firetime = System.DateTime.Now.AddSeconds(10);

        Debug.Log("Sending default notification!");
        AndroidNotification notif = new AndroidNotification(title, text, firetime);
        AndroidNotificationCenter.SendNotification(notif, "default");
    }

    public void SendRepeatNotif()
    {
        string title = "Jowa in distress!";
        string text = "Your jowa is in trouble from your rivals! Play Jowa Simulator now!";

        System.DateTime firetime = System.DateTime.Now.AddSeconds(10);
        //System.TimeSpan interval = new System.TimeSpan(2, 0, 0);

        Debug.Log("Sending repeat notification!");
        AndroidNotification notif = new AndroidNotification(title, text, firetime, interval);
        AndroidNotificationCenter.SendNotification(notif, "repeat");
    }

    /*private void OnApplicationPause()
    {
        SendRepeatNotif();
    }*/

    /*private void OnApplicationQuit()
    {
        SendRepeatNotif();
    }*/
}
