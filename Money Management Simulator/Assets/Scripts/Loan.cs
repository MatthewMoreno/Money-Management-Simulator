using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Loan {

    public GameEngine theGame;

    protected double interestRate;
    protected double balance;
    protected int term;
    protected double monthlyPayment;
    protected bool isInterestTaxDeductible;
    protected Player owner;
    protected Account account;
    protected double interestPaidThisYear;

    public Loan( double rate, double startingBalance, int length, Player theOwner, Account paymentAccount ) {
        interestRate = rate;
        balance = startingBalance;
        term = length;
        monthlyPayment = GetMonthlyPayment();
        isInterestTaxDeductible = false;
        owner = theOwner;
        account = paymentAccount;
    }

    public void AdvanceMonth() {
        if ( theGame.IsNewYear() ) {
            interestPaidThisYear = 0.0;
        }
        if ( account.Withdraw( monthlyPayment ) ) {
            interestPaidThisYear += balance * interestRate;
            balance -= monthlyPayment;
            balance += balance * interestRate / 12.0;
            term--;
        } else {
            // Handle not enough funds
        }
    }

    protected double GetMonthlyPayment() {
        double monthlyInterestRate = interestRate / 12.0;
        double denominator = Math.Pow( 1 + monthlyInterestRate, term );
        double monthlyPayment = ( balance + monthlyInterestRate * Math.Pow( 1 + monthlyInterestRate, term ) ) / denominator;
        return monthlyPayment;
    }

    public double GetBalance() {
        return balance;
    }

    public void Close() {
        owner.Remove( this );
    }

    public double GetInterestPaidThisYear() {
        return interestPaidThisYear;
    }

    public bool IsInterestTaxDeductible() {
        return isInterestTaxDeductible;
    }

}
