using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {

    bool Holding = false;
    Sprite BandSprite;
    /* N.B. from the future: I vaguely remember making a parodical
       copy of this game to commemorate something in band because it
       was somehow significant. I think this code is from that build.
       It may need some modification to properly build for a general
       case. */
    Sprite PlaneSprite;

    void Start () {
        this.rigidbody2D.gravityScale = 0;

        BandSprite = Resources.Load ("planeRed3", typeof(Sprite)) as Sprite;
        PlaneSprite = Resources.Load ("GodWhy", typeof(Sprite)) as Sprite;
    }

    void Update () {
        #if UNITY_ANDROID
        if (!GlobalVariables.needsMenu)
        {
            if(Input.touchCount == 0 && Holding == true) Holding = false;

            if(Input.touchCount > 0 && GlobalVariables.isStarted == false)
            {
                if(!Holding)
                {
                    Holding = true;
                    GlobalVariables.isStarted = true;
                    this.rigidbody2D.gravityScale = 3;
                    this.rigidbody2D.AddForce(new Vector2(0, 500));
                    this.animation.Play ("Plane Tap");
                }
            }

            if(Input.touchCount > 0 && !GlobalVariables.isStarted == false)
            {
                if(!Holding)
                {
                    Holding = true;
                    this.rigidbody2D.velocity = new Vector2(0, 0);  // Makes Plane go up
                    this.rigidbody2D.AddForce(new Vector2(0, 500)); //
                    this.animation.Stop ("Plane Tap"); // Plays animation
                    this.animation.Play ("Plane Tap"); //
                }
            }
        }
        #endif

        #if UNITY_STANDALONE
        //BAND SPECIAL ---------------------------------------------------------------------------------------------------------

        if(GlobalVariables.creditsOpen)
            this.GetComponent<SpriteRenderer>().sprite = BandSprite;
        else
            this.GetComponent<SpriteRenderer>().sprite = PlaneSprite;

        //BAND SPECIAL ---------------------------------------------------------------------------------------------------------
        // N.B. from the future: ^ I think you need to delete this and the PlaneSprite texture to properly build this
        if(!GlobalVariables.needsMenu)
        {
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && GlobalVariables.isStarted == false && !Holding)
            {
                Holding = true;
                GlobalVariables.isStarted = true;
                this.rigidbody2D.gravityScale = 3;
                this.rigidbody2D.AddForce(new Vector2(0, 500));
                this.animation.Play ("Plane Tap");
            }

            if((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))) Holding = false;

            if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !GlobalVariables.isStarted == false && !Holding)
            {
                this.rigidbody2D.velocity = new Vector2(0, 0);  // Makes Plane go up
                this.rigidbody2D.AddForce(new Vector2(0, 500)); //
                this.animation.Stop ("Plane Tap"); // Plays animation
                this.animation.Play ("Plane Tap"); //
            }
        }
        #endif

    }


    void OnCollisionEnter2D(Collision2D col) {
        this.animation.Stop ();              // WE'RE GOING DOWN
        this.animation.Play ("Plane Death"); //

        GlobalVariables.needsMenu = true; // Calls down the menu & updates it

        Holding = true; // Prevents accidental input
    }

    void OnTriggerEnter2D(Collider2D col) {
        GlobalVariables.Points += 1; // Yay points
    }

}
