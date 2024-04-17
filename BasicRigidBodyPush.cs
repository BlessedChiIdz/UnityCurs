using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;
    private int Coin = 0;

	public TextMeshProUGUI coinText;
	public TextMeshProUGUI timer;
	private float time = 60;
	public TextMeshProUGUI ScoreEnd;
    private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
        if (hit.transform.tag == "Coin")
        {
            Coin++;
			coinText.text = "Coin: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(hit.gameObject);
        }
    }

	private void PushRigidBodies(ControllerColliderHit hit)
	{

		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		if (hit.moveDirection.y < -0.3f) return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		body.AddForce(pushDir * strength, ForceMode.Impulse);
	}

    private void Start()
    {
        
    }
    private void Update()
    {
        time -= Time.deltaTime;
        timer.text = time.ToString("f0");
		if(time < 0)
		{
			SceneManager.LoadScene(1);
			ScoreEnd.text = "Score = " + Coin.ToString();
            PlayerPrefs.SetInt("score", Coin);
        }
    }
}