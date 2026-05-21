using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HighYieldSavingsAccount : Account {

    public GameEngine theGame;
    private double interestRate = .04;
    private string startingTip = "There are savings accounts, and there are high-yield savings accounts. " +
        "Many savings accounts at big banks offer little or no interest, but high-yield savings accounts " +
        "can offer anywhere between 3% and 5% yearly interest on the money inside.";

    public HighYieldSavingsAccount( double startingBalance, double rate ) {
        balance = startingBalance;
        interestRate = rate;
        mayDeposit = true;
        mayWithdraw = false;
    }

    public override bool Deposit(double amount) {
        theGame.AddPriorityTip( startingTip );
        return base.Deposit( amount );
    }

    public override void AdvanceMonth() {
        balance += balance * interestRate / 12;
    }

}

