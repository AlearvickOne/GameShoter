using UnityEngine;

public class CardsAndProtivogasActiveUI : MonoBehaviour
{
    [SerializeField] private GameObject _protivogasUI;
    [SerializeField] private GameObject[] _cardsUI;

    private void Update()
    {
        ProtivogasUIActive();
        OneCardsUIActive(SaveParametersObjects._greenKey, 0);
        OneCardsUIActive(SaveParametersObjects._redKey, 1);
        OneCardsUIActive(SaveParametersObjects._blueKey, 2);
        TwoCardsUIActive(SaveParametersObjects._greenKey, SaveParametersObjects._redKey, 3);
        TwoCardsUIActive(SaveParametersObjects._greenKey, SaveParametersObjects._blueKey, 4);
        TwoCardsUIActive(SaveParametersObjects._redKey, SaveParametersObjects._blueKey, 5);
        ThreeCardsUIActive(SaveParametersObjects._greenKey, SaveParametersObjects._redKey, SaveParametersObjects._blueKey, 6);
    }

    private void ProtivogasUIActive()
    {
        if (SaveParametersObjects._protivogas == true)
            _protivogasUI.SetActive(true);
        else
            _protivogasUI.SetActive(false);
    }

    private void OneCardsUIActive(bool nameCard, int nomberCardInUI)
    {
        if (nameCard == true)
            _cardsUI[nomberCardInUI].SetActive(true);
        else
            _cardsUI[nomberCardInUI].SetActive(false);
    }

    private void TwoCardsUIActive(bool nameCardOne, bool nameCardTwo, int nomberCardInUI)
    {
        if (nameCardOne == true && nameCardTwo == true)
            _cardsUI[nomberCardInUI].SetActive(true);
        else
            _cardsUI[nomberCardInUI].SetActive(false);
    }

    private void ThreeCardsUIActive(bool nameCardOne, bool nameCardTwo, bool nameCardThree, int nomberCardInUI)
    {
        if (nameCardOne == true && nameCardTwo == true && nameCardThree == true)
            _cardsUI[nomberCardInUI].SetActive(true);
        else
            _cardsUI[nomberCardInUI].SetActive(false);
    }
}
