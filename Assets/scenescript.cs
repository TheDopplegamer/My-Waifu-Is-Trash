using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class scenescript : MonoBehaviour {

    //The line class holds all the data on a particular line of dialogue
    public class line {
        //The string that holds the actual dialogue 
        public string dialogue;
        //Whether or not this line triggers a response from the player
        public bool is_choice;
        //The person speaking
        public string speaker;

        //The love-lust value modifiers for the cast
        public int baley_love = 0;
        public int baley_lust = 0;
        public int dumphrey_love = 0;
        public int dumphrey_lust = 0;
        public int presston_love = 0;
        public int presston_lust = 0;
        public int rusty_love = 0;
        public int rusty_lust = 0;
        public int trashley_love = 0;
        public int trashley_lust = 0;
        public int trashton_love = 0;
        public int trashton_lust = 0;

        //If we want to run a special script at this point, put it here 
        public Component script; 
    }


    //Dialogue is held in a list of lists, with the current list indicating where we are on the dialogue tree
    List<List<line>> dialogue = new List<List<line>>();
    //Keeps track of which list in dialogue we are on
	public List<line> current_dialogue = new List<line>();
    //Keeps track of our overall position in the story length-wise
    public int index;
	
	
    //Add a line to a spot in the dialoguem, use the dialogue tree for reference for index
    void Add_Line(int ind, line l) {
        if (ind > dialogue.Count){
            dialogue.Add(new List<line>());
            dialogue[dialogue.Count - 1].Add(l);
        }
        else {
            dialogue[ind].Add(l);
        }
    }


    //Constructor for the line class, simply assign the parameters to a new instance of a line and return the result
    line Line(string d,bool c,string s,int blo,int blu,int dlo,int dlu,int plo,int plu,int rlo,int rlu,int tllo,int tllu,int ttlo,int ttlu,Component scr) {
        line nl = new line();
        nl.dialogue = d;
        nl.is_choice = c;
        nl.speaker = s;
        nl.baley_love = blo;
        nl.baley_lust = blu;
        nl.dumphrey_love = dlo;
        nl.dumphrey_lust = dlu;
        nl.presston_love = plo;
        nl.presston_lust = plu;
        nl.rusty_love = rlo;
        nl.rusty_lust = rlu;
        nl.trashley_love = tllo;
        nl.trashley_lust = tllu;
        nl.trashton_love = ttlo;
        nl.trashton_lust = ttlu;
        nl.script = scr;
        return nl;
    }

    //Switch to a different dialogue list
    public void Change_Dialogue(int d) {
        current_dialogue = dialogue[d];
    }


    public bool Get_Choice() {
        return current_dialogue[index].is_choice;
    }

    //Returns the string in the current list at the current index
    public string Get_Dialogue() {
        return current_dialogue[index].dialogue;
    }

    //TEST 
    void Start() {
        

        Change_Dialogue(0);
    }


}
