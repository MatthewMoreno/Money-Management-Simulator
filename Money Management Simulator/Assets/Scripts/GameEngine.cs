using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour {
    public Player player;
    public int month, year;
    public UIHandler uiHandler;
    public Market market;
    public TipManager tipManager;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void AdvanceMonth() {
        player.AdvanceMonth();
        month++;
        if ( month == 12 ) {
            month = 0;
            year++;
        }
    }

    public bool IsNewYear() {
        return month == 0;
    }

    public void StartGame() {
        SceneManager.LoadScene( "InGame" );
    }

    private void NewGame() {
        DateTime currentDate = DateTime.Now;
        month = currentDate.Month;
        year = currentDate.Year;
        player = new Player( month, year - 18, 5000 );
        ReloadScene();
    }

    private void ReloadScene() {
        uiHandler.DisplayAssets();
        uiHandler.DisplayLiabilities();
        uiHandler.SetAge();
        uiHandler.SetNetWorth();
    }

    public int GetMonth() { return month; }
    public int GetYear() { return year; }
    public double GetInflation() { return market.GetInflation(); }
    public void AddPriorityTip( string tip ) { tipManager.AddPriorityTip( tip ); }
    public void AddTip( string tip ) { tipManager.AddTip( tip ); }

}
