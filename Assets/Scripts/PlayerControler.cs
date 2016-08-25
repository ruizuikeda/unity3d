using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {
	//youtube
	//https://www.youtube.com/watch?v=QSGILStP1lg&list=PLOFacakspTDJD5OuedwEhh2FXPdchpIC1

	// variaveis
	public Rigidbody2D		Player;
	public Animator 		Animar;
	public int 				ForceJump;

	// pulo e slide
	public bool 			jump;
	public bool 			slide;

	// Interações com o Chão
	public Transform 		GroundCheck;
	public bool 			grounded;
	public LayerMask 		whatIsGround;
	public float 			radiusOverlapCircle;

	// Interações do Slide
	public float 			timeSlide;
	public float 			timeTemp;

	// Colisor
	public Transform		colisor;
	public float			colisorConstante;

	// Parede




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// SE O BOTÃO DE PULO FOR PRESSIONADO E ESTIVER PISANDO NO CHÃO, FAÇA:
		if(Input.GetButtonDown("Jump") && grounded) {
			Debug.Log("> botão de pulo pressionado.");

			// APLICAMOS A FORÇA VERTICAL PARA CAUSAR O SALTO
			Player.AddForce (new Vector2(0,ForceJump));

			// ALTERAMOS O STATUS PARA PULANDO
			jump = true;

			// FORÇANDO PARA SLIDE 
			if(slide){
				// RECALCULANDO O COLISOR
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + colisorConstante, colisor.position.z);

				// PARAR O SLIDE
				slide = false;
			}

		}

		// SE O BOTÃO DE SLIDE FOR PRESSIONADO, FAÇA:
		if(Input.GetButtonDown("Slide") && grounded) {
			Debug.Log ("> botão de slide pressionado.");

			if (!slide) {
				// RECALCULANDO O COLISOR
				colisor.position = new Vector3(colisor.position.x, colisor.position.y - colisorConstante, colisor.position.z);
			}

			// ALTERAMOS O STATUS PARA SLIDE
			slide = true;

			// ZERAMOS O TEMPO QUE ELE ESTÁ EM MODO DE SLIDE
			timeTemp = 0;


		}

		// verifica se está em contato com o chão
		grounded = Physics2D.OverlapCircle (GroundCheck.position, radiusOverlapCircle, whatIsGround);

		// verifica se está em slide
		if(slide){
			timeTemp += Time.deltaTime;
			if (timeTemp >= timeSlide) {
				// RECALCULANDO O COLISOR
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + colisorConstante, colisor.position.z);

				// PARAR O SLIDE
				slide = false;
			}
		}



		Animar.SetBool ("jump", !grounded);
		Animar.SetBool ("slide", slide);

	} // fim Update

	void OnTriggerEnter2D(){
		Debug.Log ("> Colidiu.");
		SceneManager.LoadScene ("index");
	}

}
