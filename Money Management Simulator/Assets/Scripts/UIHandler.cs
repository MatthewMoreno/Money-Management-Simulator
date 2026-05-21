using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour {

    public GameEngine theGame;
    public Player player;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI netWorthText;
    public TextMeshProUGUI tipText;
    public TextMeshProUGUI checkingText;
    public TextMeshProUGUI savingsText;

    void Start () {
        theGame = GameObject.Find( "TheGame" ).GetComponent<GameEngine>();
        SetAge();
        SetNetWorth();
    }

    public void DisplayAssets() {
        HashSet<Account> assets = player.GetAccounts();
        HashSet<Residence> residences = player.GetResidences();
    }

    public void DisplayLiabilities() {

    }

    public void SetAge() {
        int ageInMonths = player.GetAge( theGame.GetMonth(), theGame.GetYear() );
        ageText.text = ageInMonths / 12 + " Years and " + ageInMonths % 12 + " Months";
    }

    public void SetNetWorth() {
        netWorthText.text = player.GetNetWorth().ToString();
    }

}
