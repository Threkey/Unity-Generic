using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;  // 장애물 오브젝트들

    private bool stepped = false;   // 플레이어 캐릭터가 밟았었는가

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if(Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
