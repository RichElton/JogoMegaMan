using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject	barreiraPrefab;  // Objeto a ser spawnado.
	public float 		rateSpawn;		 // Intervalo de spawn.
	private float		currentTime; 	 // Armazena o tempo entre um respawn e outro.
	private int			posicao;
	private float 		y;
	public float 		posA;
	public float 		posB;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= rateSpawn) {
			//para garantir q só chame um.
			currentTime = 0;

			posicao = Random.Range (1, 100);

			if (posicao > 50) {
				y = posA;
			} else {
				y = posB;
			}

			//Instancio o objeto que foi colocado na minha variável e a maneira.
			GameObject tempPrefab = Instantiate(barreiraPrefab) as GameObject;
			tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);
		}
	}
}