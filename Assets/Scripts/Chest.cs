using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int CoinsAmount;

    //references
    public Sprite newSprite;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Fighter" && other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().getCoin(CoinsAmount);
            Gamemanager.instance.ShowText($"+ {CoinsAmount} Coins", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            sr.sprite = newSprite;

        }
    }
}
