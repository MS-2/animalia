using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MenuPausa : MonoBehaviour {

	//Pantalla Azul Fade In - Fade Out.
	[Header("Animator Fade.")]
	public Animator FadeAnimator; 
	
	//IndexG que controla los arreglos.
	[Header("IndexG de los arreglos.")]
	public int IndexG;
	
	//Scripts, Botones y AudioSource a desactivar cuando se pausa.
	[Header("Componentes a Desactivar.")]
	public MonoBehaviour[] DesactivarScripts;							
	public AudioSource AS_Animales;

//*****************************************************************
//*********************  FUNCIONES  NIVEL  ************************
//***************************************************************** 

	public void CargarSigNivel(){
		FadeAnimator.SetBool("CargarNivelSiguiente", true);
		AS_Animales.Stop();
	}

	public void CargarAntNivel(){
		FadeAnimator.SetBool("CargarNivelAnterior", true);
		AS_Animales.Stop();
	}


//*****************************************************************
//*****************  DESACTIVAR FUNCIONES NIVEL  ******************
//*****************************************************************

	public void DesactivarF(){		
		//Este for recorre todas las posiciones y desactiva los Scripts.
		if(DesactivarScripts.Length > 0){
			for(IndexG = 0; IndexG < DesactivarScripts.Length; IndexG++){			
				DesactivarScripts[IndexG].enabled = false;
			}
		}
	}

	public void ActivarF(){	
		//Este for vuelve a activar todos los Scripts desactivados.
		if(DesactivarScripts.Length > 0){
			for(IndexG = 0; IndexG < DesactivarScripts.Length; IndexG++){	
				DesactivarScripts[IndexG].enabled = true;		
			}
		}
	}

//*****************************************************************
//*********************  LISTA DE BOTONES  ************************
//*****************************************************************
		
	//Activa el Menu Pause y detiene el time.delta de las animaciones.
	public void Pausa(){					
		Time.timeScale = 0f; 
		DesactivarF();						
	}
	
	//Desactiva el menu pause y regresa tiempo.
	public void Resumen(){					
		Time.timeScale = 1f;
		ActivarF();							
	}

	//Retorna la escala de tiempo y detiene los AudioSources antes de cargar el Menu Principal.
	public void CargarMenu(){				
		Time.timeScale = 1f;
		AS_Animales.Stop();
		FadeAnimator.SetBool("CargarNivelMenu", true);
	}
			
//*****************************************************************		

}
