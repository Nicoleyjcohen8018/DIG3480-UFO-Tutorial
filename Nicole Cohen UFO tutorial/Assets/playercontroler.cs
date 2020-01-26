using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private int count;
    public Text CountText;
    public Text WinText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        WinText.text = ""
        ;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        float moveHorizorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizorizontal,moveVertical);
        rb2d.AddForce(movement * speed);     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You win!!! Game created by Nicole Cohen!!!";
        }
    }
}
