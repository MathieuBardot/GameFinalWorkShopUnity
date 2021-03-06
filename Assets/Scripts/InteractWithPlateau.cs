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

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (perso != null)
        {
            // Apparition de la fenêtre d'info et d'option du perso
            Debug.Log(character.name);
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
