using UnityEngine;
using System.Collections;

public class CosinusoidalFloat : MonoBehaviour {

    bool hasDone = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        this.transform.Translate (this.transform.position.x > 0 ? 0.003f * Mathf.Cos (Time.time * 2) : -0.003f * Mathf.Cos (Time.time * 2), 0, 0);

        if (GlobalVariables.isStarted && !hasDone) {
            this.transform.Translate(0, 0, -100);
            hasDone = true;
        }

        if (!GlobalVariables.isStarted && hasDone) {
            this.transform.Translate(0, 0, 100);
            hasDone = false;
        }

    }
}
