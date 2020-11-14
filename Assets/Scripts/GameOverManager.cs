using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public UnderWorld underworld;       // Reference to the player's health.
	public float restartDelay = 10f;
	public PlayerController player;
    Animator anim;                          // Reference to the animator component.
	Animator playerAnim;
	float restartTimer;

    void Awake ()
    {
        // Set up the reference.
        anim = GetComponent <Animator> ();
		playerAnim = GetComponent<Animator> ();
    }


    void Update ()
    {
        // If the player has run out of health...
		if(underworld.over)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger ("GameOver");
			restartTimer += Time.deltaTime;
			playerAnim.SetBool("GameOver",true);
			player.enabled = false;
			if (restartTimer >= restartDelay) {
				//reload level

			}
        }
    }
}