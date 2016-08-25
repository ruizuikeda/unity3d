using UnityEngine;
using System.Collections;

public class spawnController : MonoBehaviour {

	// Variaveis
	public GameObject	barreiraPrefab;		//objeto a ser spawmado
	public float		rateSpawn;			//intervalo de tempo a serem spawmados
	public float		currentTime;		//tempo corrido após o objeto ser spawmado

	// Aleatorizando o ponto y do objeto a ser criado
	private	int			posicao;			//cima ou baixo
	private float		y;					//altura a nascer
	public	float		yEmBaixo;			//que vai nascer o objeto quando em baixo
	public	float		yEmCima;			//que vai nascer o objeto quando em cima


	// Use this for initialization
	void Start () {
	
		// Inicializando o tempo
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		// atualizando o tempo
		currentTime += Time.deltaTime;

		// se já ultrapassou o tempo de rateSpawn
		if(currentTime >= rateSpawn) {
			// zera o tempo
			currentTime = 0;

			// randomiza a posição que nascerá o objeto
			posicao = Random.Range(1,100);
			if (posicao > 50) {
				// nasce em baixo 
				y = yEmBaixo;
			} else {
				// nasce em cima
				y = yEmCima;
			}


			// criando o objeto e declarando como uma instancia da barreiraPrefab como um gameobject
			GameObject tempPrefab = Instantiate(barreiraPrefab) as GameObject;

			// garantindo que o objeto seja criado no ponto de spawn
			tempPrefab.transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
	}
}
