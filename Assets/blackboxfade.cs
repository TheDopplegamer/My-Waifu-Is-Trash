using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackboxfade : MonoBehaviour {

    SpriteRenderer sprite;
    textbox the_box;

    public float dir = 0;
    float trans = 1.0f;

	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        the_box = GameObject.Find("TextBox").GetComponent<textbox>();
	}
	
	// Update is called once per frame
	void Update () {
        //Fade_In();
        //Fade_Out();
        sprite.color = new Color(1f, 1f, 1f, trans);
	}

    public void Fade_In() {
        if (the_box.text_done)
        {
            the_box.locked = true;
            if (dir < 0)
            {
                trans += dir;
                if (trans < 0)
                {
                    trans = 0f;
                    dir = 0;
                    the_box.Next_Text();
                }
            }
        }
    }

    public void Fade_Out()
    {
        if (dir > 0)
        {
            trans += dir;
            if (trans > 1.0f)
            {
                trans = 1.0f;
                dir = 0;
                the_box.Next_Text();
            }
        }
    }
}
