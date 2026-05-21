using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CheckingAccount : Account {

    public GameEngine theGame;

    public CheckingAccount( double startingBalance ) {
        balance = startingBalance;
        mayDeposit = true;
        mayWithdraw = true;
    }

    public override void AdvanceMonth() {

    }
    
}

