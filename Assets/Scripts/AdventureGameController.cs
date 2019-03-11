using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGameController : MonoBehaviour {

    public Text textComponent; //SerializeField makes variable editable in inspector
    public Text TextOption1;
    public Text TextOption2;
    public State startingState;

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

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if(nextStates.Length != 0)
        {
            state = nextStates[0];

            // Update text from state
            textComponent.text = state.GetStateStory();
            TextOption1.text = state.GetOption1();
            TextOption2.text = state.GetOption2();
        }        
    }

    public void SelectOption()
    {
        ManageState();
    }
}
