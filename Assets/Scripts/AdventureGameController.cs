using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGameController : MonoBehaviour {

    public Text textComponent;
    public Text TextOption1;
    public Text TextOption2;
    public Image CatSprite;
    public State startingState;

    public int MoralityThreshold;

    private int MoralityLevel;

    State state;

	// Use this for initialization
	void Start () {
        state = startingState;
        textComponent.text = state.GetStateStory();
        TextOption1.text = state.GetOption1();
        TextOption2.text = state.GetOption2();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void ManageState(bool ChoiceMorality)
    {
        if(ChoiceMorality)
        {
           // CatSprite.sprite = state.GoodChoiceSprite;
            MoralityLevel++;
        }
        else
        {
           // CatSprite.sprite = state.BadChoiceSprite;
        }

        var nextStates = state.GetNextStates();
        if(nextStates.Length != 0)
        {
            if(state.name == "Question6")
            {
                if(MoralityLevel >= MoralityThreshold)
                {
                    state = nextStates[0];
                }
                else
                {
                    state = nextStates[1];
                }

                textComponent.text = state.GetStateStory();
                TextOption1.text = state.GetOption1();
                TextOption2.text = state.GetOption2();
            }
            else
            {
                state = nextStates[0];

                // Update text from state
                textComponent.text = state.GetStateStory();
                TextOption1.text = state.GetOption1();
                TextOption2.text = state.GetOption2();
            }            
        }        
    }

    public void SelectOption1()
    {
        ManageState(state.GetOption1Morality());
    }

    public void SelectOption2()
    {
        ManageState(state.GetOption2Morality());
    }
}
