using UnityEngine.SceneManagement;
using UnityEngine;

public class CargarNiveles : MonoBehaviour {


	//Carga el nivel siguiente.
	public void CargarNivelSiguiente(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	//Vuelve al nivel anterior.
	public void CargarNivelAnterior(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	
	//Carga el Menu Principal del Juego.
	public void CargarNivelMenu(){
		SceneManager.LoadScene(1);
	}


	//Lista de Niveles en el Juego. Se seleccionar desde le Menu Principal.
	public void CargarNivelHogar(){
		SceneManager.LoadScene(2);
	}

	public void CargarNivelGranja(){
		SceneManager.LoadScene(3);
	}

	public void CargarNivelSelva(){
		SceneManager.LoadScene(4);
	}

	public void CargarNivelOceano(){
		SceneManager.LoadScene(5);
	}

	public void CargarNivelBosque(){
		SceneManager.LoadScene(6);
	}

	public void CargarNivelMontanas(){
		SceneManager.LoadScene(7);
	}

	public void CargarNivelMemoTest(){
		SceneManager.LoadScene(8);
	}

	public void CargarNivelEncastre(){
		SceneManager.LoadScene(9);
	}

	public void CargarNivelIdSonidos(){
		SceneManager.LoadScene(10);
	}


}
