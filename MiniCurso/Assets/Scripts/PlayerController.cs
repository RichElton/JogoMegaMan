using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator 	Anime;
	public Rigidbody2D	playerRigidbody;
	public int			forceJump;


	//verifica o chão.
	public Transform	GroundCheck;
	public bool			grounded;
	public LayerMask	whatsIsGround;

	//Slide.
	public bool			slide;
	public float		slideTemp;
	private float		timeTemp;

	//Colisor.
	public Transform colisor;

	//audio.
	public AudioSource 	audio;
	public AudioClip	soundJump, soundSlide;

	//Pontuação. Static=> faz com que eu acessa a variavel de outros scripts
	public static int pontuacao;

	//Acessando o canvas.
	public UnityEngine.UI.Text txtPontos;


	// Use this for initialization
	void Start () {
		pontuacao = 0;
		//toda vez que inicia ela é zero.
		PlayerPrefs.SetInt("pontuacao", pontuacao);

		PlayerPrefs.SetInt ("recorde", pontuacao);
	}
	
	// Update is called once per frame
	void Update () {

		txtPontos.text = pontuacao.ToString();

		// Se o botão de pulo for pressionado e tiver pisando no chão, faça isso:
		// A função GetButtonDown => É executada apenas uma vez.
		if (Input.GetMouseButtonDown(0) && grounded && !slide) {
			playerRigidbody.AddForce (new Vector2(0, forceJump));

			//Audio Jump.
			audio.PlayOneShot(soundJump);
			audio.volume = 1;

			if (slide) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
		}

		else if (Input.GetMouseButtonDown(1) && grounded && !slide) {
			//Audio Slide.
			audio.PlayOneShot(soundSlide);
			audio.volume = 0.5f; //Baixa o volume para a metade.

			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z); 
			slide = true;
			timeTemp = 0;

		}

		//Verifica se ele esta no chão.
		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatsIsGround);

		//Slide.
		if(slide==true){
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z); 
				slide = false;
			}
		}

		//A string "jump" é a variável no Animation. E o jump a variável criada aqui.
		Anime.SetBool("jump", !grounded);
		Anime.SetBool ("slide", slide);
	}

	//Quando o player entrar no trigger, ele vai executar esse comando.
	void OnTriggerEnter2D(){

		//Gravar recorde do player.
		PlayerPrefs.SetInt("pontuacao", pontuacao);


		//verifica o recorde. E se for maior ele salva.
		if(pontuacao > PlayerPrefs.GetInt("recorde"))
		{
			PlayerPrefs.SetInt ("recorde", pontuacao);
		}

		// Abre a cena de menu quando ele morrer.
		Application.LoadLevel ("gameover");
	}
}
