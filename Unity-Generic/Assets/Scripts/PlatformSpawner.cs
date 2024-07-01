using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;           // ������ ������ ���� ������
    public int count = 3;                       // ������ ������ ����

    public float timeBetSpawnMin = 1.25f;       // ���� ��ġ������ �ð� ���� �ּҰ�
    public float timeBetSpawnMax = 2.25f;       // ���� ��ġ������ �ð� ���� �ִ밪
    private float timeBetSpawn;                 // ���� ��ġ������ �ð� ����

    public float yMin = -3.5f;                  // ��ġ�� ��ġ�� �ּ� y��
    public float yMax = 1.5f;                   // ��ġ�� ��ġ�� �ִ� y��
    public float xPos = 20f;                    // ��ġ�� ��ġ�� x��

    private GameObject[] platforms;             // �̸� ������ ���ǵ�
    private int currentIndex = 0;               // ����� ���� ������ ����

    // �ʹݿ� ������ ���ǵ��� ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawntime;                // ������ ��ġ ����



    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            platforms[i].SetActive(false);
        }

        lastSpawntime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
            return;

        if(Time.time >= lastSpawntime + timeBetSpawn)
        {
            lastSpawntime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawn, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
