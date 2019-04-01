using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AdventureGameController : MonoBehaviour {

    public Text textComponent;
    public Text TextOption1;
    public Text TextOption2;  

    public Button Option1;
    public Button Option2;

    public Image CatSprite;

    public AudioSource BadMeow;
    public AudioSource GoodMeow;

    public State startingState;
    public State state;
    Animator animator;

    public static CanvasSingleton Canvas;

    public static AdventureGameController instance = null;

    public int MoralityThreshold;

    private int MoralityLevel;

    public State[] nextStates;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);       
    }

    // Use this for initialization
    void Start () {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();

        state = startingState;
        UpdateStateContent();      
	}

    private void ManageState(bool ChoiceMorality)
    {
        animator.SetTrigger("Transition");

        // Check choice morality and update accordingly
        if(ChoiceMorality)
        {
            // if not on final question assign sprite based on question morality
            if(!state.GetIsFinalQuestion())
            {
                CatSprite.sprite = state.GoodChoiceSprite;
            }

            GoodMeow.Play();

            MoralityLevel += state.MoralPoints;
        }
        else
        {
            // if not on final question assign sprite based on question morality
            if (!state.GetIsFinalQuestion())
            {
                CatSprite.sprite = state.BadChoiceSprite;
            }

            BadMeow.Play();

            MoralityLevel -= state.MoralPoints;
        }

        nextStates = state.GetNextStates();

        if(state.IsNextScene)
        {
            SceneManager.LoadScene(state.SceneName);
            CanvasSingleton.CanvasInstance.gameObject.SetActive(false);
        }
        else if(nextStates.Length != 0)
        {
            if(state.GetIsFinalQuestion())
            {
                if(MoralityLevel >= MoralityThreshold)
                {
                    CatSprite.sprite = state.GoodChoiceSprite;

                    state = nextStates[0];
                    
                    Option1.gameObject.SetActive(false);
                    Option2.gameObject.SetActive(false);
                }
                else
                {
                    CatSprite.sprite = state.BadChoiceSprite;

                    state = nextStates[1];                   

                    Option1.gameObject.SetActive(false);
                    Option2.gameObject.SetActive(false);
                }

                UpdateStateContent();
            }
            else
            {
                state = nextStates[0];

                // Update text from state
                Invoke("UpdateStateContent", 0.3f);
            }            
        }        
    }

    public void UpdateStateContent()
    {
        textComponent.text = state.GetStateStory();
        TextOption1.text = state.GetOption1();
        TextOption2.text = state.GetOption2();
    }

    public void SelectOption1()
    {
        ManageState(state.GetOption1Morality());
    }

    public void SelectOption2()
    {
        ManageState(state.GetOption2Morality());
    }

    public void ShowCanvas()
    {
        CanvasSingleton.CanvasInstance.gameObject.SetActive(true);
    }
}
