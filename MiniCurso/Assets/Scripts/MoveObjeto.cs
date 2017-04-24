using UnityEngine;
using System.Collections;

public class MoveObjeto : MonoBehaviour {

	public float speed;
	// o mesmo x do transform.
	private float x; 

	public GameObject Player;
	private bool puntuado;

	// Use this for initialization
	void Start () {
		//procura o player e pega como game object.
		Player = GameObject.Find ("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		//Define o tempo por cada frame. Diferênça de tempo de um frame e outro(A velocidade agora está sendo definida pelo tempo, e não pelo computador).
		x += speed * Time.deltaTime;

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		//Destrói o objeto.
		if (x <= -3) {
			Destroy (transform.gameObject);
		}

		if (x < Player.transform.position.x && puntuado == false) {
			//para pontua apenas uma vez.
			puntuado = true;
			PlayerController.pontuacao += 1;
		}

	}
}