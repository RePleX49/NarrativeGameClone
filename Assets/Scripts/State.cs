using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Now deriving from ScriptableObject class
//CreateAssetMenu creates a tab for this class in the Create contextual tab
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10,14)] public string storyText;
    public string Option1;
    public string Option2;
    public bool bIsOption1Good;
    public bool bIsOption2Good;
    public State[] nextStates;
    public Sprite GoodChoiceSprite;
    public Sprite BadChoiceSprite;
	
    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public string GetOption1()
    {
        return Option1;
    }

    public string GetOption2()
    {
        return Option2;
    }

    public bool GetOption1Morality()
    {
        return bIsOption1Good;
    }

    public bool GetOption2Morality()
    {
        return bIsOption2Good;
    }
}
