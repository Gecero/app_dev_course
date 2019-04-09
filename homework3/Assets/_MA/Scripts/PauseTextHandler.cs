using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTextHandler : MonoBehaviour
{
    private TextMesh tm;
    private PauseObject po;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        po = GetComponent<PauseObject>();
        tm.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        po.init(onPause, onUnpause);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void onPause() {
        tm.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void onUnpause() {
        tm.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
