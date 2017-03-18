using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class scenescript : MonoBehaviour {

    //The line class holds all the data on a particular line of dialogue
    [System.Serializable]
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
        public int effect;

        public string choice_1;
        public string choice_2;
        public string choice_3;

    }


    //Dialogue is held in a list of lists, with the current list indicating where we are on the dialogue tree
    List<List<line>> dialogue = new List<List<line>>();
    //Keeps track of which list in dialogue we are on
	public List<line> current_dialogue = new List<line>();
    //Keeps track of our overall position in the story length-wise
    public int index;

    //Reference to the actor objects
    public GameObject actor_left;
    public GameObject actor_right;

    SpriteRenderer right_actor_sprite;

    blackboxfade fade_box;

    textbox text_box;

    void Awake() {

        fade_box = GameObject.Find("black_box").GetComponent<blackboxfade>();
        text_box = GameObject.Find("TextBox").GetComponent<textbox>();
        right_actor_sprite = actor_right.GetComponent<SpriteRenderer>();
        string player_name = "Baka";

        dialogue.Add(new List<line>());
        dialogue.Add(new List<line>());
        dialogue.Add(new List<line>());

        //Blank canvas to add line of dialogue
        //Add_Line(true, 0, Line("", false, "???", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "",0));

        Add_Line(true, 0, Line(player_name+"....", false, "???", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line(player_name+"!!!\nWAKE UP!!!", false, "???", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 1));
        Add_Line(true, 0, Line("I awaken, and a small plastic trash can sits at the edge of my bed.", false, player_name, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("Gosh, I thought you were in a coma or something!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("1.) What the Fuck?\n2.) What are you doing in here?\n3.) Being woken by someone so beautiful, it’s like a fairytale", true, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(false, 0, Line("I’ll tell you what the fuck! Class starts in half an hour!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 1, Line("I live here dummy, you would know that if you ever left your room", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "",0));
        Add_Line(false, 2, Line(player_name+"! I… I… don’t mess with me like that! You’re leaving this room\nwhether you want to or not!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(true, 0, Line("It’s the first day of class, and I’ll be damned if you’re going to sleep\nall the time like you did over summer break. Or my name isn’t Trashley!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("1.) Seriously, what the Fuck?\n2.) But I like staying at home...\n3.) Looks like you'll have to make me...", true, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(false, 0, Line("Right?? I can’t believe you survived off of hot pockets for 3 months. But enough distractions!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 1, Line("Don’t we all? But being an asocial potato isn’t very healthy for a senior in high school.", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 2, Line("Grrr... I may be a tiny trash can, but I know how to kick your lazy ass in gear if I have to!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(true, 0, Line("Trashley throws me out of bed (somehow) with enough force to land on my ass.", false, player_name, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("Ok! Now that you’re out of bed, let’s set something straight. This is your last year of high school, and I’d try to make something out of it. Like dating somebody!I’m sure you can be attractive if you put your mind to it. Try saying something to woo me.", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("1.) *Kiss Trashley*\n2.) Umm, you have a nice… lid\n3.) You look stunning, like a plastic Beyonce", true, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(false, 0, Line("!!!!!That’s not what I meant!Dummy…I guess it wasn’t so bad though…Maybe we could…Kiss again ?", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, "", "", "", 0));
        Add_Line(false, 1, Line("Thank you! I polished it this morning You might have hope yet! That bar above me gauges my feelings for you, and if you max it out something good will happen!", false, "Trashley",      0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 2, Line("Ah! I… Umm…"+ player_name+"... Jeez that was sweet of you. The… uh bar above me gauges… how I – OR ANYONE ELSE Feels about you.If you max it out something good will.” happen!", false, "Trashley",  0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, "", "", "", 0));

        Add_Line(true, 0, Line("*HONK HONK*", false, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(true, 0, Line("OH GOSH!That must be Baley outside to pick me up. Don’t forget what I said about trying to make some more friends.  Bye!", false, "Trashley", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 2));
        Add_Line(true, 0, Line("1.) Are… are all the dateable people in this game trash cans?\n2.) I should probably get dressed\n3.) Time for another nap", true, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(false, 0, Line("Yes, yes they are. That’s the point of this game, man I can ask some dumb questions sometimes.", false, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 1, Line("I find a handy pile of dirty jeans and hoodies and put them on. Good enough!", false, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));
        Add_Line(false, 2, Line("I jump back into bed but OWCH there appears to be a nest of scorpions that moved in. I guess the developers want me to go to school.", false, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Add_Line(true, 0, Line("Time to get going! But man class starts in 15 minutes. How should I get there?", false, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", 0));

        Change_Dialogue(0);
    }
	
    //Add a line to a spot in the dialoguem, use the dialogue tree for reference for index
    void Add_Line(bool only,int ind, line l) {
        if(ind > 2) {
            ind = 2;
        }
        if (!only)
        {
            dialogue[ind].Add(l);
        }
        else {
            dialogue[0].Add(l);
            dialogue[1].Add(l);
            dialogue[2].Add(l);
        }
    }


    //Constructor for the line class, simply assign the parameters to a new instance of a line and return the result
    line Line(string d,bool c,string s,int blo,int blu,int dlo,int dlu,int plo,int plu,int rlo,int rlu,int tllo,int tllu,int ttlo,int ttlu,string c1,string c2,string c3,int e) {
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
        nl.choice_1 = c1;
        nl.choice_2 = c2;
        nl.choice_3 = c3;
        nl.effect = e;
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

    public string Get_Speaker() {
        return current_dialogue[index].speaker;
    }

    //TEST 
    void Start() {
        
    }

    void FixedUpdate() {
        Select_Effect(current_dialogue[index].effect);
    }

    public void Select_Effect(int script_index) {
        if(script_index == 0) {}
        else if(script_index == 1) {
            Trigger_Fade_In();
        }
        else if (script_index == 2)
        {
            Fade_Out_Right();
        }
        else if (script_index == 3)
        {
            Trigger_Fade_In();
        }

    }


    void Trigger_Fade_In() {
        fade_box.dir = -0.005f;
        fade_box.Fade_In();
    }

    void Fade_Out_Right() {
        if (text_box.text_done)
        {
            text_box.locked = true;
            right_actor_sprite.color = new Color(1f, 1f, 1f, right_actor_sprite.color.a - 0.01f);
            if (right_actor_sprite.color.a < 0f)
            {
                right_actor_sprite.sprite = null;
                right_actor_sprite.color = new Color(1f, 1f, 1f, 1f);
                text_box.Next_Text();
            }
        }
    }



}
