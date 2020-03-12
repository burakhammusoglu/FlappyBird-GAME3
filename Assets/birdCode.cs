using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdCode : MonoBehaviour
{
    public Sprite[] birdSprite;
    SpriteRenderer spriteRenderer;
    bool nextBackControl = true;
    float birdAnimationTime = 0;
    int birdCounter;
    Rigidbody2D physics;
    int puan = 0;
    bool gameOver = true;
    public Text soccerText;
    gameController gameControl;
    AudioSource [] ses;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        physics = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("gamecontroltag").GetComponent<gameController>();
        ses=GetComponents<AudioSource>();
    }

    
    void Update()
    {
        birdController();
        Animasyon();
    }
    void Animasyon()
    {
        birdAnimationTime += Time.deltaTime;
        if (birdAnimationTime>0.3f)
        {
            birdAnimationTime = 0;
            if (nextBackControl)
            {
                spriteRenderer.sprite = birdSprite[birdCounter];
                birdCounter++;
                if (birdCounter == birdSprite.Length)
                {
                    birdCounter--;
                    nextBackControl = false;
                }
            }
            else
            {
                birdCounter--;
                spriteRenderer.sprite = birdSprite[birdCounter];
                if (birdCounter==0)
                {
                    birdCounter++;
                    nextBackControl = true;
                }
            }
        }
        

    }sdfsdfs
    void birdController()
    {
        if (Input.GetMouseButtonDown(0) && gameOver)
        {
            physics.velocity = new Vector2(0, 0); // hiz(yerçekimi)0 yaptık
            physics.AddForce(new Vector2(0, 200));//sonra kuvvet uyguladık
            ses[0].Play();
        }
        if (physics.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45); // zıplarken yukarı bakmasını yaptık
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45); // düşerkende aşağıya bakmasını sağladık
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puantag")
        {
            puan++;
            soccerText.text = "puan=" + puan;
            Debug.Log(puan);
            ses[1].Play();
        }
        if (col.gameObject.tag== "engeltag")
        {
            ses[2].Play();

            gameOver = false;
            gameControl.gameOver();
        }
    }

}
