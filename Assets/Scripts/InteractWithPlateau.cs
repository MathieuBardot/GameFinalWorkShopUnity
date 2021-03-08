using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithPlateau : MonoBehaviour
{
    public Color hoverColor = Color.grey;
    public Color selectMove = Color.red;
    public InfoPanelScript infoPanel;

    public GameObject perso;
    private Color startColor;
    private Renderer rend;
    public CharacterData character;
    private Vector3[] positions;
    private Vector3 currentPosition;
    private Vector3 arrivalPosition;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (perso != null)
        {
            // Apparition de la fenêtre d'info et d'option du perso
            Debug.Log(character.name);
            // Utilisation de l'algorithme Astar pour déterminer les chemins possibles du perso
            positions = new Vector3[character.movementCase];
            currentPosition = perso.transform.position;
            
            /*for (int i=0; i< character.movementCase; ++i)
            {
                positions[i] = perso.transform.position + new Vector3(0,0,i+1);
            }*/
            // character doit devenir player dans InfoPanelScript
            infoPanel.player = character;
            StartCoroutine(infoPanel.StartInfoPanel());
        }
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
