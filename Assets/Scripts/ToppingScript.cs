using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool bIsAttached;

    [SerializeField] float fallRate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float RandFallRate = (fallRate + Random.Range(1.5f, 2.5f));
        Vector2 newPos = new Vector2(rb.position.x, rb.position.y - (RandFallRate * Time.deltaTime));
        rb.position = newPos;
    }

    public void Deactivate()
    {
        bIsAttached = true;
    }
}
