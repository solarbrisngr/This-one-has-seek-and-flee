using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;
    public GameObject hitbox;

	void OnTriggerEnter ()
	{
        if (hitbox.tag == "Player")
        {
            gameManager.CompleteLevel();

        }
    }

}
