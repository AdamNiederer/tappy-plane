using UnityEngine;
using System.Collections;

public class MenuAnimator: MonoBehaviour {

    bool isActive = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (GlobalVariables.needsMenu && !isActive) {
            isActive = true;
            this.animation.Play("Loser Fly-In");
        }

        if (!GlobalVariables.needsMenu && isActive) {
            isActive = false;
            this.animation.Play("Loser Fly-Out");
        }

    }
}
