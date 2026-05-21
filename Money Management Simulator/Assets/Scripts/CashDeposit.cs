using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CashDeposit : Account {

    private double interestRate;
    private int termLeft;
    private CheckingAccount originAccount;

    public CashDeposit(double startingBalance, double rate, int term, CheckingAccount account) {
        balance = startingBalance;
        interestRate = rate;
        termLeft = term;
        originAccount = account;
        mayWithdraw = false;
        mayDeposit = false;
    }

    public override void AdvanceMonth() {
        balance += balance * interestRate / 12;
        termLeft--;
        if ( termLeft == 0 ) {
            ReturnBalance();
        }
    }

    private void ReturnBalance() {
        originAccount.Deposit( balance );
        Close();
    }
}

