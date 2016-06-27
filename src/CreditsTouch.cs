using UnityEngine;
using System.Collections;

public class CreditsTouch : MonoBehaviour {

    GameObject menu;

    // Use this for initialization
    void Start () {
        menu = GameObject.Find ("Credits Menu");
        menu.SetActive (false);
        GlobalVariables.creditsOpen = true; // fuck it this is for band anyway not gonna stay like that
    }

    // Update is called once per frame
    void Update () {

        #if UNITY_ANDROID

        if (Input.touchCount>0)
        {
            foreach(Touch T in Input.touches)
            {
                if(T.phase == TouchPhase.Began && guiTexture.HitTest(T.position))
                {
                    GlobalVariables.creditsOpen = !GlobalVariables.creditsOpen;
                    menu.SetActive(!menu.activeSelf);
                }
            }
        }

        #endif

        #if UNITY_STANDALONE

        if(Input.GetMouseButtonDown(0) && guiTexture.HitTest(Input.mousePosition))
        {
            GlobalVariables.creditsOpen = !GlobalVariables.creditsOpen;
            menu.SetActive(!menu.activeSelf);
        }

        #endif

    }
}
