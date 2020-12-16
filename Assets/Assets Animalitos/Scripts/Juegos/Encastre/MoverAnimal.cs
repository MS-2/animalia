using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoverAnimal : MonoBehaviour, IDragHandler, IEndDragHandler{

    //Script Principales del Encastre;
    [Header("Scripts Principales FE y PAE.")]
    public FuncionesEncastre FE_Script;
    public PosAnimalesEncastre PAE_Script;
    public int IndexG;
    
    [Header("Componentes UI del Animal a Mover.")]
    public Vector3 PosicionOriRecT;
    public Vector3 PosicionDesRecT;
	public RectTransform ActualRectT;
     
//*****************************************************************
//*******************  EVENTOS DE MOVIMIENTO  *********************	
//*****************************************************************
    
    //Se ejecuta cuando empezamos a arrastar un animal.
    public void OnDrag(PointerEventData eventData){
        Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        ActualRectT.position = Camera.main.ScreenToWorldPoint(MousePosition);
        transform.SetSiblingIndex(12);
    }

    //Se ejecuta cuando terminamos de arrastar un animal.
    public void OnEndDrag(PointerEventData eventData){
        if(FE_Script.AnimalesEncastrados[IndexG] == true){
            ActualRectT.localPosition = PosicionDesRecT;
            FE_Script.DetectarAnimalesEncastrados(IndexG);
        }else{
            ActualRectT.localPosition = PosicionOriRecT;            
            FE_Script.DetectarAnimalesEncastrados(IndexG);
        }    
    }

//*****************************************************************

    //Se llama desde PAE_Script para asignar las posiciones originales y destino de los animales.
    public void AsigPosAnimales(){
        PosicionOriRecT = PAE_Script.RecTAnimalesColor[IndexG].localPosition;
        PosicionDesRecT = PAE_Script.RecTAnimalesBlancos[IndexG].localPosition;
    }
}
