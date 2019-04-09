using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NvpEventController : MonoBehaviour
{

    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private NvpEventModel _eventModel;
    private static NvpEventController _instance;




    // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public bool logGameEvents;




    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Awake()
    {
        _eventModel = new NvpEventModel();

        _instance = this;
    }




    // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public static void SubscribeToEvent(NvpGameEvents eventToSubscribeTo, Action<object, object> callback)
    {
        _instance._eventModel.SubscribeToEvent(eventToSubscribeTo, callback);
    }

    public static void UnsubscribeFromEvent(NvpGameEvents eventToUnsubscribeFrom, Action<object, object> callback)
    {
        _instance._eventModel.UnsubscribeFromEvent(eventToUnsubscribeFrom, callback);
    }

    public static void InvokeEvent(NvpGameEvents e, object sender, object eventArgs)
    {
        _instance._eventModel.InvokeEvent(e, sender, eventArgs);

        if (!_instance.logGameEvents) return;

        Debug.LogFormat("{0} called from {1}", e.ToString(), sender.GetType().ToString());
    }

    public static void Reset()
    {
        _instance._eventModel.Reset();
    }
}