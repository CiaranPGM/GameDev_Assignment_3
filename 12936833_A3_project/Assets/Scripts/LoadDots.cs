using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDots : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerupDots;

    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerupDots = new GameObject[5];
        for (int i = 0; i < powerupDots.Length; i++)
        {
            powerupDots[i] = powerUp;
        }
        Instantiate(powerupDots[0], new Vector2((float)11.5, 13), Quaternion.identity); //Top right dot
        Instantiate(powerupDots[1], new Vector2((float)-11.5, 13), Quaternion.identity);
        Instantiate(powerupDots[2], new Vector2((float)-11.5, -13), Quaternion.identity);
        Instantiate(powerupDots[3], new Vector2((float)11.5, -13), Quaternion.identity);
        Instantiate(powerupDots[4], new Vector2(0, (float)-2.6), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
