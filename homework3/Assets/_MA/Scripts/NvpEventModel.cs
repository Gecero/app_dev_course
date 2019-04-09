using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NvpEventModel : INvpEventModel
{

    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Dictionary<NvpGameEvents, List<Action<object, object>>> _eventCallbacks;




    // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public NvpEventModel()
    {
        _eventCallbacks = new Dictionary<NvpGameEvents, List<Action<object, object>>>();
    }

    ~NvpEventModel()
    {
        _eventCallbacks = null;
    }



    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback)
    {
        if (!_eventCallbacks.ContainsKey(e))
        {
            _eventCallbacks[e] = new List<Action<object, object>>();
        }

        _eventCallbacks[e].Add(callback);
    }


    public void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer)
    {
        if (!_eventCallbacks.ContainsKey(e)) return;

        if (!_eventCallbacks[e].Contains(observer)) return;

        _eventCallbacks[e].Remove(observer);
    }

    public void InvokeEvent(NvpGameEvents e, object sender, object eventArgs)
    {
        if (e != NvpGameEvents.OnDebugMsg)
        {
            this.InvokeEvent(NvpGameEvents.OnDebugMsg, this, e.ToString());
        }
        if (!_eventCallbacks.ContainsKey(e)) return;

        foreach (var observer in _eventCallbacks[e])
            observer(sender, eventArgs);
    }

    public void Reset()
    {
        _eventCallbacks = new Dictionary<NvpGameEvents, List<Action<object, object>>>();
    }
}

public enum NvpGameEvents
{
    OnDebugMsg,
    OnShowMessage,
    OnPauseObjectCheck
}
