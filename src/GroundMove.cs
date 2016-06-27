using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        this.transform.Translate (-.13f, 0, 0);

        if (this.transform.position.x < -24.1f)
            this.transform.position = new Vector3 (24.2f, -4.5f, -1);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Plane")
            this.collider2D.isTrigger = true;
    }
}
