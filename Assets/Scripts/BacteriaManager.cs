using UnityEngine;
using System.Collections;

public class BacteriaManager : MonoBehaviour {
	public GameObject[] enemies;
	public Vector3 spawnerValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	public int spawnCount;
	public int nowCount;
	public Transform player;
	public GameObject lightning;
	public int delay;
	public int repeatTime;
	private int timer = 0;
	private int randEnemy;
	public int bacteriaCount;
	void Start () {
		InvokeRepeating("Spawn",delay,repeatTime);
	}

	void Spawn(){
		StartCoroutine (spawner());
	}

	IEnumerator spawner(){
		if (bacteriaCount > 0) {
			randEnemy = Random.Range (0, enemies.Length);
			Vector3 spawnPosition = new Vector3 (Random.Range (player.position.x - 30, player.position.x + 30), Random.Range (player.position.y + 5, player.position.y + 20),spawnerValues.z);
		
			GameObject thunder = Instantiate (lightning, spawnPosition + transform.TransformPoint (0, 0, 0), gameObject.transform.rotation);
			//GameObject newBacteria1 = Instantiate (enemies [randEnemy], spawnPosition + transform. TransformPoint(0, 0, 0), gameObject.transform.rotation);
			for (int i = 0; i < bacteriaCount; i++) {
				randEnemy = Random.Range (0, enemies.Length);
				spawnPosition = new Vector3 (Random.Range (player.position.x - 30, player.position.x + 30), Random.Range (player.position.y + 5, player.position.y + 20),spawnerValues.z);
				GameObject white = Instantiate (enemies [randEnemy], spawnPosition + transform.TransformPoint (0, 0, 0), gameObject.transform.rotation);
				Debug.Log ("Bacteria at z = "+spawnPosition.z);
				white.transform.parent = gameObject.transform;
			}

			//newBacteria1.transform.parent = gameObject.transform;
			//newBacteria2.transform.parent = gameObject.transform;
			//newBacteria3.transform.parent = gameObject.transform;

			//Debug.Log ("Bacteria spawned at " + spawnPosition.x + " " + spawnPosition.y + " "+ spawnPosition.z);
			yield return new WaitForSeconds (spawnWait);//this is fine
			Destroy (thunder);
		}
	}
}