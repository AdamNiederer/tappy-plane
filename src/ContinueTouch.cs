using UnityEngine;
using System.Collections;

public class ContinueTouch : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }

    void Update () {
        #if UNITY_ANDROID
        if (Input.touchCount>0 && GlobalVariables.needsMenu)
        {
            foreach(Touch T in Input.touches)
            {
                if(T.phase == TouchPhase.Began && guiTexture.HitTest(T.position))
                {
                    GlobalVariables.isStarted = false; //Resets the Menus
                    GlobalVariables.needsMenu = false;
                    GlobalVariables.Points = 0;
                    GameObject.Find ("Plane").rigidbody2D.gravityScale = 0;				//Resets the Plane
                    GameObject.Find ("Plane").rigidbody2D.velocity = new Vector2(0, 0); //
                    GameObject.Find ("Plane").transform.position = new Vector3(0, 0, 0);//
                    GameObject.Find ("Plane").transform.rotation = Quaternion.identity; //
                    GameObject.Find ("Ground1").collider2D.isTrigger = false;
                    GameObject.Find ("Ground2").collider2D.isTrigger = false;
                }
            }
        }

        #endif

        #if UNITY_STANDALONE
        if(GlobalVariables.needsMenu && (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && guiTexture.HitTest(Input.mousePosition))))
        {
            GlobalVariables.isStarted = false; //Resets the Menus
            GlobalVariables.needsMenu = false;
            GlobalVariables.Points = 0;

            GameObject.Find ("Plane").rigidbody2D.gravityScale = 0;				//Resets the Plane
            GameObject.Find ("Plane").rigidbody2D.velocity = new Vector2(0, 0); //
            GameObject.Find ("Plane").transform.position = new Vector3(0, 0, 0);//
            GameObject.Find ("Plane").transform.rotation = Quaternion.identity; //

            GameObject.Find ("Ground1").collider2D.isTrigger = false;
            GameObject.Find ("Ground2").collider2D.isTrigger = false;
        }
        #endif
    }
}
