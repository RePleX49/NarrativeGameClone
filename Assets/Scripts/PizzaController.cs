using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PizzaController : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    private SpawnToppingScript ToppingSpawnerScript;

    protected Vector3 WorldPos;

    private int VeggiesOnPizza;
    private int ToppingsOnPizza;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        ToppingSpawnerScript = GameObject.Find("ToppingSpawner").GetComponent<SpawnToppingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = WorldPos;
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 MousePos = new Vector2();
        WorldPos = new Vector3();

        MousePos.x = currentEvent.mousePosition.x;
        MousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        WorldPos = cam.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, cam.nearClipPlane));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Veggie"))
       {           
            if (!collision.gameObject.GetComponent<ToppingScript>().bIsAttached)
            {
                collision.gameObject.transform.SetParent(this.gameObject.transform);
                collision.gameObject.GetComponent<ToppingScript>().Deactivate();

                ToppingsOnPizza++;
                VeggiesOnPizza++;

                CheckGameOverStatus();
                Debug.Log(ToppingsOnPizza);
            }            
       }
       else if (collision.gameObject.CompareTag("Anchovie"))
       {           
            if (!collision.gameObject.GetComponent<ToppingScript>().bIsAttached)
            {
                collision.gameObject.transform.SetParent(this.gameObject.transform);
                collision.gameObject.GetComponent<ToppingScript>().Deactivate();

                ToppingsOnPizza++;

                CheckGameOverStatus();
                Debug.Log(VeggiesOnPizza);
            }         
       }
    }

    private void CheckGameOverStatus()
    {
        if(VeggiesOnPizza > 6)
        {
            ToppingSpawnerScript.GameOver();
            AdventureGameController.instance.ShowCanvas();
            AdventureGameController.instance.state = AdventureGameController.instance.nextStates[1];
            AdventureGameController.instance.UpdateStateContent();
            SceneManager.LoadScene("Interview");
        }
        else if(ToppingsOnPizza > 19)
        {
            ToppingSpawnerScript.GameOver();
            AdventureGameController.instance.ShowCanvas();
            AdventureGameController.instance.state = AdventureGameController.instance.nextStates[0];
            AdventureGameController.instance.UpdateStateContent();
            SceneManager.LoadScene("Interview");
        }
    }
}
