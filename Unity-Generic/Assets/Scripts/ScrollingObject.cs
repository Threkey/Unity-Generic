using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10.0f;

    BoxCollider2D backgroundCollider;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //scroll();
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width)
        {
            Reposition();
        }

        if (GameManager.instance.isGameover)
        {
            speed = 0f;
        }
    }

    void scroll()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -width)
        {
            transform.position = Vector3.right * width;
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
