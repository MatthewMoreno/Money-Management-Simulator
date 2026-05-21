using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annuity : Account {

    public GameEngine theGame;

    protected double interestRate;
    protected bool periodic;
    protected bool immediate;
    protected bool fixedPayout;
    protected bool survivorshipBenefit;
    protected Account paymentAccount;

    public Annuity( double rate, double startingBalance, Account account ) {
        interestRate = rate;
        balance = startingBalance;
        paymentAccount = account;
    }

    public override void AdvanceMonth() {

    }

}
