using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Now deriving from ScriptableObject class
//CreateAssetMenu creates a tab for this class in the Create contextual tab
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] string Option1;
    [SerializeField] string Option2;
    [SerializeField] State[] nextStates;
	
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
}
