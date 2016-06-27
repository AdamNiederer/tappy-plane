using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

    public bool isActive = false;

    public void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (GlobalVariables.needsMenu && !isActive) {

            isActive = true;
            this.guiText.text = "Score: " + GlobalVariables.Points.ToString ();	//update scoretext

            GameObject.Find ("BronzeMedal").guiTexture.color = GlobalVariables.Points < 50 ? Color.black : Color.grey; //Update Medals
            GameObject.Find ("SilverMedal").guiTexture.color = GlobalVariables.Points < 150 ? Color.black : Color.grey; //
            GameObject.Find ("GoldMedal").guiTexture.color = GlobalVariables.Points < 500 ? Color.black : Color.grey;   //
        }

        if (!GlobalVariables.needsMenu && isActive) {
            isActive = false;
        }

    }
}
