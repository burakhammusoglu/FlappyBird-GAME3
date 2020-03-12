using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject skyOne;
    public GameObject skyTwo;
    public float backRoundSpeed = -1.5f;
    Rigidbody2D physicsOne;
    Rigidbody2D physicsTwo;
    float uzunluk = 0;
    public GameObject engel;
    public int kacAdetEngel = 0;
    public GameObject[] engeller;
    float degisimZaman = 0;
    int sayac = 0;
    bool oyunBıttı = true;
    void Start()
    {
        physicsOne = skyOne.GetComponent<Rigidbody2D>();
        physicsTwo = skyTwo.GetComponent<Rigidbody2D>();

        physicsOne.velocity = new Vector2(backRoundSpeed, 0);
        physicsTwo.velocity = new Vector2(backRoundSpeed, 0);

        uzunluk = skyOne.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdetEngel];
        for(int i = 0 ; i<engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20,-20),Quaternion.identity);
            Rigidbody2D fizik =engeller[i].AddComponent<Rigidbody2D>();
            fizik.gravityScale = 0;
            fizik.velocity = new Vector2(backRoundSpeed, 0);
        }
        
    }

    
    void Update()
    {
        if (oyunBıttı)
        {
            if (skyOne.transform.position.x <= -uzunluk)
            {
                skyOne.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (skyTwo.transform.position.x <= -uzunluk)
            {
                skyTwo.transform.position += new Vector3(uzunluk * 2, 0);
            }

            //------------------------------------------------//

            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f)
            {
                degisimZaman = 0f;
                float yPosition = Random.Range(-2f, 0.50f);
                engeller[sayac].transform.position = new Vector3(15f, yPosition);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }

            }
        }
        
    }

    public void gameOver()
    {
        for(int i = 0; i <engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity =Vector2.zero;
            physicsOne.velocity = Vector2.zero;
            physicsTwo.velocity = Vector2.zero;

        }
        oyunBıttı = false;
    }
}
