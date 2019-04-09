using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public List<PauseObject> objectsToPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            NvpEventController.InvokeEvent(NvpGameEvents.OnPauseObjectCheck, this, null);
            
        }

    }
}
