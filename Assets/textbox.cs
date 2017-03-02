using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textbox : MonoBehaviour {

    //Reference to the text componenet 
    public GameObject txtchild;
    Text text;

    //The complete string of the text
    string fulltxt = "";
    //The actual text being displayed
    string displaytxt = "";
    //The index of the next character to add 
    int txtindex = 0;

    //Set true when the characters are done being added
    bool text_done = false;
    //Timer variables that affect character speed
    int text_speed = 5;
    int text_timer = 0;

    //Reference to the current scene of the game
    scenescript current_scene;

	//Run once at start of object
    void Start() {
        //Assign references and initialize text
        text = txtchild.GetComponent<Text>();
        current_scene = gameObject.GetComponent<scenescript>();
        fulltxt = current_scene.Get_Dialogue();
        Assign_Text();
    }

    //Run every frame
    void Update() {
        //Character by character scroll
        if(!text_done) {
            text_timer += 1;

            //Make text go faster when pressed
            if (Input.GetKey("z")){text_speed = 1;}
            else {text_speed = 4;}

            if (text_timer >= text_speed) {
                //Advance text, also check to see if text is done advancing
                text_done = !Character_Scroll();
                Assign_Text();
                text_timer = 0;
            }
        }
        //Once text is done, wait for player input to advance
        else {
            //If there is a choice, wait till a selection is made, then change dialogue accordingly 
            if (current_scene.Get_Choice())
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    current_scene.Change_Dialogue(0);
                    Next_Text();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    current_scene.Change_Dialogue(1);
                    Next_Text();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    current_scene.Change_Dialogue(2);
                    Next_Text();
                }
            }
            //Otherwise, simply wait for the player to advance the text
            else if (Input.GetKeyDown("z")) { Next_Text();}
        }
    }



    //Change the text to the next one in the scene
    void Next_Text() {
        //Move to the next text
        current_scene.index += 1;
        fulltxt = current_scene.Get_Dialogue();
        //Reset text variables
        text_done = false;
        text_timer = 0;
        txtindex = 0;
        displaytxt = "";
    }

    //Give the string to the textbox
    void Assign_Text() {
        text.text = displaytxt;
    }

    //Add the next character of the dialogue to the display text
    bool Character_Scroll() {
        displaytxt += fulltxt[txtindex];
        txtindex += 1;
        //Return false when the text is finished updating
        return (txtindex < fulltxt.Length);
    }


		
	

}
