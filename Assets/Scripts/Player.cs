using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float jumpForce = 8f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;
    public GameObject failMenuUI;
    
	public string currentColor;
	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

    public static Player instance;

	void Start ()
	{
        rb.gravityScale = 0f;
		SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
            rb.gravityScale = 3f;
			rb.velocity = Vector2.up * jumpForce;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            failMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.gameObject.CompareTag("CollectCoin"))
        {
            Destroy(col.gameObject);
            return;
        }


        if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER!");
            failMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }


    }

	public void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}
}
