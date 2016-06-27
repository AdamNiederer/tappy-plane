using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

    // Use this for initialization
    void Start () {
        if (this.name == "Background1")
            this.transform.Translate (24, 0, 1);
        if (this.name == "Background2")
            this.transform.Translate (-0, 0, 1);
        if (this.name == "Background3")
            this.transform.Translate (-24, 0, 1);
    }

    // Update is called once per frame
    void Update () {

        this.transform.Translate (-.12f, 0, 0); //Scrolling Speed; Rest of script remains unhampered by this!
        if (this.transform.position.x < -48.0f)
            this.transform.Translate (72, 0, 1);

    }
}
