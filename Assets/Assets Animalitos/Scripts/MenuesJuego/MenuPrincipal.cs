using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour  { 

	
	[Header("Animator Fade.")]
	public Animator FadeAnim;
	
	//Carga el primer nivel al pulsar jugar 
	public void ComenzarJuego(){				 
		FadeAnim.SetBool("CargarNivelSiguiente", true);    	  
	}

	public void CargarNivelHogar(){
		FadeAnim.SetBool("CargarNivelHogar", true);  
	}

	public void CargarNivelGranja(){
		FadeAnim.SetBool("CargarNivelGranja", true);  
	}

	public void CargarNivelSelva(){
		FadeAnim.SetBool("CargarNivelSelva", true);  
	}

	public void CargarNivelOceano(){
		FadeAnim.SetBool("CargarNivelOceano", true);  
	}

	public void CargarNivelBosque(){
		FadeAnim.SetBool("CargarNivelBosque", true);  
	}

	public void CargarNivelMontanas(){
		FadeAnim.SetBool("CargarNivelMontanas", true);  
	}

	public void CargarNivelMemoTest(){
		FadeAnim.SetBool("CargarNivelMemoTest", true);  
	}

	public void CargarNivelEncastre(){
		FadeAnim.SetBool("CargarNivelEncastre", true);  
	}

	public void CargarNivelIdSonidos(){
		FadeAnim.SetBool("CargarNivelIdSonidos", true);  
	}	

	//Sale de la aplicacion.   
	public void SalirJuego(){  					               
		Application.Quit();					
	}

}
