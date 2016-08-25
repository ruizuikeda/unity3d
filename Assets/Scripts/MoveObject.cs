using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	// Variáveis
	public	float		velocidadeX;
	private	float 		x;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// recebe o valor da posição X do objeto
		x = transform.position.x;

		// adiciona a velocidade na posição
		x += velocidadeX * Time.deltaTime;

		// faz a atualização da tela
		transform.position = new Vector3(x, transform.position.y, transform.position.z);

		// destruindo o objeto depois que ele deixa a tela
		if(x <= -2) {
			Destroy (transform.gameObject);
		}
	}
}
