using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleton : MonoBehaviour
{
    public static CanvasSingleton CanvasInstance= null;
    // Start is called before the first frame update
    void Awake()
    {
        if (CanvasInstance == null)
        {
            CanvasInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (CanvasInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
