using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelV1 : MonoBehaviour
{
    public CharacterData player;
    public RevealText revealText;

    public RevealText hpText;
    public RevealText strenghtText;
    public RevealText defenseText;
    public RevealText intelligenceText;
    public RevealText moveText;

    public Animator panelAnimator;
    public FightScriptV1 fightScript;
    public GameObject buttonFight;
    public GameObject buttonMove;
    public GameObject buttonCapacity;

    public enum CrawlerState
    {
        BEGIN,
        CURRENT_PERSO,
        BATTLE,
        END
    }

    private CrawlerState state;

    public IEnumerator Start()
    {
        state = CrawlerState.BEGIN;
        buttonFight.SetActive(false);
        buttonMove.SetActive(false);
        buttonCapacity.SetActive(false);

        player = Instantiate(player);
        fightScript.onFightEnd.AddListener(OnFightEnd);
        fightScript.player = player;

        yield return StartCoroutine(hpText.ChangeText($" HP : {player.HP}"));
        yield return StartCoroutine(strenghtText.ChangeText($" Strength : {player.strength}"));
        yield return StartCoroutine(defenseText.ChangeText($" Defense : {player.defense}"));
        yield return StartCoroutine(intelligenceText.ChangeText($" Intelligence : {player.intelligence}"));
        yield return StartCoroutine(moveText.ChangeText($" Move : {player.movementCase}"));

        yield return StartCoroutine(ChangeText("Info player"));
        //yield return StartCoroutine(ChangeText($"{player.Description}"));
        //yield return StartCoroutine(ChangeText(currentRoom.description));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(SelectPerso());
        //buttons.SetActive(true);
    }

    IEnumerator SelectPerso()
    {
        state = CrawlerState.CURRENT_PERSO;
        buttonFight.SetActive(true);
        buttonMove.SetActive(true);
        buttonCapacity.SetActive(true);
        if (player.HP == 0)
        {

        }
        else
        {
            yield return StartCoroutine(ChangeText("Que voulez-vous faire ?"));
        }

        // Condition de victoire
        // perso mort

        /*if (currentRoom.roomLeft == null && currentRoom.roomRight == null)
        {
            EndGame();
        }
        else
        {
             yield return StartCoroutine(ChangeText("Que voulez-vous faire ?"));
        }*/
    }

    public void OnButtonStartFightPressed()
    {
        if (state == CrawlerState.CURRENT_PERSO)
        {
            StartCoroutine(FightSelect(true));
        }
    }

    public void OnButtonMovePressed()
    {
        if (state == CrawlerState.CURRENT_PERSO)
        {
            StartCoroutine(MoveCharacter(true));
        }
    }

    public void OnButtonCapacityPressed()
    {
        if (state == CrawlerState.CURRENT_PERSO)
        {
            StartCoroutine(Capacity(true));
        }
    }

    IEnumerator FightSelect(bool left)
    {
        buttonFight.SetActive(false);
        buttonMove.SetActive(false);
        buttonCapacity.SetActive(false);
        yield return StartCoroutine(ChangeText("Begin Battle !"));
        //panelAnimator.SetBool("IsTextInfo", true);
        yield return new WaitForSeconds(1.0f);

        panelAnimator.SetBool("InfoPanelActive", true);

        yield return StartCoroutine(fightScript.StartFight());
        // passer au script de combat
    }

    IEnumerator MoveCharacter(bool left)
    {
        buttonFight.SetActive(false);
        buttonMove.SetActive(false);
        buttonCapacity.SetActive(false);
        yield return StartCoroutine(ChangeText("Perso Move !"));
        // Pouvoir sélectionner la case où le perso doit avancer
    }

    IEnumerator Capacity(bool left)
    {
        buttonFight.SetActive(false);
        buttonMove.SetActive(false);
        buttonCapacity.SetActive(false);
        yield return StartCoroutine(ChangeText("Capacity Perso !"));
        // Effet de la capacité sur les stats activé
    }

    /*IEnumerator SelectRoom(bool left)
    {
        buttons.SetActive(false);
        currentRoom = left ? currentRoom.roomLeft : currentRoom.roomRight;
        string door = left ? "gauche" : "droite";
        buttonLeft.SetActive(currentRoom.roomLeft != null);
        buttonRight.SetActive(currentRoom.roomRight != null);

        yield return StartCoroutine(ChangeText($" {player.name} ouvre la porte de {door}"));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(ChangeText(currentRoom.description));
        yield return new WaitForSeconds(1.0f);

        ScriptableObject occupant = currentRoom.occupant;
        if (occupant is CharacterData)
        {
            panelAnimator.SetBool("IsTextInfo", true);
            fightScript.ennemy = (CharacterData)occupant;
            yield return StartCoroutine(fightScript.StartFight());
        }
        else
        {
            // Découverte Objet
            ItemData item = (ItemData)occupant;
            yield return StartCoroutine(ChangeText($"{player.name} trouve {item.name}"));
            yield return new WaitForSeconds(1.0f);
            if (item.incrementDefense > 0)
            {
                player.defense += item.incrementDefense;
                yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementDefense} de défense"));
                yield return new WaitForSeconds(1.0f);
            }
            if (item.incrementStrenght > 0)
            {
                player.strength += item.incrementStrenght;
                yield return StartCoroutine(ChangeText($"{player.name} récupère {item.incrementStrenght} de force"));
                yield return new WaitForSeconds(1.0f);
            }
            if (item.incrementIntelligence > 0)
            {
                player.intelligence += item.incrementIntelligence;
                yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementIntelligence} d'intelligence"));
                yield return new WaitForSeconds(1.0f);
            }
            if (item.incrementHP > 0)
            {
                player.Heal(item.incrementHP);
                yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementHP} de vie"));
                yield return new WaitForSeconds(1.0f);
            }
            yield return StartCoroutine(ChooseDoor());
        }
    }*/

    void EndGame()
    {
        if (state == CrawlerState.END)
        {
            StartCoroutine(ChangeText("Vous avez gangé cette bataille ! BRAVO !!"));
        }
    }

    void OnFightEnd(bool won)
    {
        panelAnimator.SetBool("InfoPanelActive", false);
        if (won)
        {
            StartCoroutine(SelectPerso());
            StartCoroutine(hpText.ChangeText($" HP : {player.HP}"));
        }
        else
        {
            StartCoroutine(ChangeText($"Votre {player.name} est mort !"));
        }
    }

    IEnumerator ChangeText(string text)
    {
        yield return StartCoroutine(revealText.ChangeText(text));
    }
}
