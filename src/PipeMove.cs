using UnityEngine;
using System.Collections;

public class PipeMove : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        this.transform.Translate (-.13f, 0, 0);
        if (this.transform.position.x < -15.0f || !GlobalVariables.isStarted || GlobalVariables.needsMenu)
            GameObject.Destroy (this.gameObject);
    }
}
