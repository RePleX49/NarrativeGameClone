using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaController : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;

    protected Vector3 WorldPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
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
}
