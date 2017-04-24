using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float 	 speed;
	private float	 offset;

	// Use this for initialization
	void Start () {
		// Acessando o componente que esta usando o script.
		currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		// Garanti que tds tenha a mesma jogabilidade, independente do seu dispositivo.
		offset += speed * Time.deltaTime;

		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
