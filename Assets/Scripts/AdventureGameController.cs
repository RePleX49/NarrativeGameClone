using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureGameController : MonoBehaviour {

    public Text textComponent;
    public Text TextOption1;
    public Text TextOption2;  

    public Button Option1;
    public Button Option2;
    public Button RestartButton;

    public Image CatSprite;

    public State startingState;
    State state;

    public int MoralityThreshold;

    private int MoralityLevel;

    // Use this for initialization
    void Start () {
        RestartButton.gameObject.SetActive(false);

        state = startingState;
        textComponent.text = state.GetStateStory();
        TextOption1.text = state.GetOption1();
        TextOption2.text = state.GetOption2();
	}

    private void ManageState(bool ChoiceMorality)
    {
        if(ChoiceMorality)
        {
            if(!state.GetIsFinalQuestion())
            {
                CatSprite.sprite = state.GoodChoiceSprite;
            }
            
            MoralityLevel++;
        }
        else
        {
            if(!state.GetIsFinalQuestion())
            {
                CatSprite.sprite = state.BadChoiceSprite;
            }           
        }

        var nextStates = state.GetNextStates();
        if(nextStates.Length != 0)
        {
            if(state.GetIsFinalQuestion())
            {
                if(MoralityLevel >= MoralityThreshold)
                {
                    CatSprite.sprite = state.GoodChoiceSprite;

                    state = nextStates[0];
                    
                    Option1.gameObject.SetActive(false);
                    Option2.gameObject.SetActive(false);
                    RestartButton.gameObject.SetActive(true);
                }
                else
                {
                    CatSprite.sprite = state.BadChoiceSprite;

                    state = nextStates[1];                   

                    Option1.gameObject.SetActive(false);
                    Option2.gameObject.SetActive(false);
                    RestartButton.gameObject.SetActive(true);
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

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
