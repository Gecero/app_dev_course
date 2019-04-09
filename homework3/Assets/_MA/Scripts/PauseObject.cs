using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseObject : MonoBehaviour
{
    private List<Action> onPauseEventHandlers = new List<Action>();
    private List<Action> onUnpauseEventHandlers = new List<Action>();
    public bool pause = false;
    private bool autoCheck = false;
    public void init(Action onPause, Action onUnpause) {
        onPauseEventHandlers.Add(onPause);
        onUnpauseEventHandlers.Add(onUnpause);
    }

    void OnDisable() {
        NvpEventController.UnsubscribeFromEvent(NvpGameEvents.OnPauseObjectCheck, OnPauseObjectCheck);
    }

    // Start is called before the first frame update
    void Start()
    {
        NvpEventController.SubscribeToEvent(NvpGameEvents.OnPauseObjectCheck, OnPauseObjectCheck);
    }

    private void OnPauseObjectCheck(object s, object e)
    {
        togglePaused();
        Debug.LogFormat("{0}", e);
    }


    // Update is called once per frame
    void Update()
    {
        if(autoCheck) {
            check();
        }
    }

    public void check() {
        autoCheck = false;
        if(pause) {
            foreach(var a in onPauseEventHandlers)
                { 
                    a();
                }
            
        } else {
            foreach(var a in onUnpauseEventHandlers)
                {
                    a();
                
                }
        }
    }
    
    public void togglePaused() {
        autoCheck = true;
        pause = !pause; 
    }
}
