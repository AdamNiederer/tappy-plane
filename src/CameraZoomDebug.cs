using UnityEngine;
using System.Collections;

public class CameraZoomDebug : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }

    void Update () {
        #if UNITY_STANDALONE
        if(Input.GetMouseButtonDown(1))
        {
            if(this.camera.orthographicSize == 5f)
                this.camera.orthographicSize = 3f;
            else
                this.camera.orthographicSize = 5f;
        }
        #endif
    }
}
