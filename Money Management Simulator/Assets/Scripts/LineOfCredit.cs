using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfCredit {

    protected double totalCredit;
    protected double borrowedAmount;
    protected double interestRate;
    protected double balance;
    protected double payment;
    protected Account account;

    public LineOfCredit( double total, double rate ) {
        totalCredit = total;
        interestRate = rate;
    }

    public void AdvanceMonth() {
        if ( account.Withdraw( payment ) ) {
            balance -= payment;
        } else {
            // Handle not enough funds
        }
        balance += balance * interestRate;
        balance += borrowedAmount;
    }

    public void CheckAdvanceMonth() {
        if ( !account.CanWithdraw( payment ) ) {
            // Handle account not paying
        }
        if ( payment < balance && interestRate > .2 ) {
            // Handle accruing interest
        }
        if ( borrowedAmount + balance - payment + ( balance - payment ) * interestRate > totalCredit) {
            // Handle going past max balance
        }
    }

    public double GetBalance() { return balance; }

}
