using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour {

    GameObject Pipe;
    bool hasSpawned = false;

    // Use this for initialization
    void Start () {
        Pipe = Resources.Load<GameObject> ("Pipe Set");
    }

    // Update is called once per frame
    void Update () {

        #region spawncode
        if(Mathf.Sin(Time.time * 4) > .9 && !hasSpawned)
        {
            hasSpawned = true;
            Instantiate(Pipe, new Vector3(20, 4*Random.value - 2f, 0), Quaternion.identity);
        }

        if(Mathf.Sin(Time.time * 4) < .1 && hasSpawned)
        {
            hasSpawned = false;
        }
        #endregion
    }
}
