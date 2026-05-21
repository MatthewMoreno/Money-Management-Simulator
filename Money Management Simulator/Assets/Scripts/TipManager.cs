using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TipManager : MonoBehaviour {

    private List<string> priorityTips = new List<string>();
    private List<string> otherTips = new List<string>();
    private List<string> usedTips = new List<string>();
    private System.Random rand;

    // Start is called before the first frame update
    void Start() {
        rand = new System.Random();
        priorityTips.Add( "Welcome To Money Management Simulator. Try to manage your assets and liabilities well " +
            "enough to live the life you imagine. For starters, you can find out how much you'll need for the coming " +
            "month and put the remaining into your savings account." );
        otherTips.Add( "Because the funds are easily accessible and safe, high-yield savings accounts are great" +
            "place to store an emergency fund. The money will be there if you need it, and it will continue to grow" +
            "when you're not using it." );
        otherTips.Add( "It's prudent to keep an emergency fund available in the case of an unexpected need for " +
            "money. For the amount, some suggest 3 to 6 months of expenses, or the total of all your deductibles " +
            "(home, auto, and health)." );
    }

    // Update is called once per frame
    void Update() {
        
    }

    public string GetTip() {
        string tip;
        if ( priorityTips.Count > 0) {
            tip = priorityTips[0];
            priorityTips.RemoveAt(0);
        } else {
            int randomTip = rand.Next( otherTips.Count );
            tip = otherTips[randomTip];
            otherTips.RemoveAt( randomTip );
        }
        usedTips.Add( tip );
        return tip;
    }

    public void AddPriorityTip( string tip ) {
        if ( !usedTips.Contains( tip ) ) {
            priorityTips.Add( tip );
        }
    }
    public void AddTip( string tip ) {
        if ( !usedTips.Contains( tip ) ) {
            otherTips.Add( tip );
        }
    }

}
