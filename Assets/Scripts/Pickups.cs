using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    public int coins = 0;
    public int coinAmount = 1;

    public Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "COINS : 0";
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            
            coins++;
            scoreText.text = "COINS : " + coins;
            Destroy(collision.gameObject);
        }
    }
}
