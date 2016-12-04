using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Vector3 startPos;
	public GameObject[] pickups;

    private Rigidbody rb;
    private int count;
    private bool winStatus;

	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString ();
        winText.text = "";
        winStatus = false;
        startPos = transform.position;
        pickups = GameObject.FindGameObjectsWithTag("Pick Up");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement*speed);
	}

	void Update()
	{
		if (transform.position.y < -10)  //if the ball falls off the map, reset its position and make all pickups once again active
		{
			transform.position=startPos;		//teleport ball and stop its velocity and rotation
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;

			if (!winStatus) // reset score & balls if the player hasn't already won
			{
				count = 0;	// clear score, start over
				countText.text = "Count: " + count.ToString ();  // display new score

				foreach (GameObject go in pickups) // reset all pickups to active
				{
	            	go.SetActive(true);
	            }
            }
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
                count = count + 1;
                countText.text = "Count: " + count.ToString();
                if (count >= 13)
				{
				winText.text = "You Win!";
				winStatus = true;
                }
		}
	}
}
