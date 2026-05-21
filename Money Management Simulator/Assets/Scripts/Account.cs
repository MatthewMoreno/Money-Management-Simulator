using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Account {
    protected double balance = 0.0d;
    protected bool mayDeposit;
    protected bool mayWithdraw;
    protected Player owner;


    abstract public void AdvanceMonth();

    public virtual bool Deposit( double amount ) {
        if ( CanDeposit() ) {
            balance += amount;
            return true;
        }
        return false;
    }

    public bool Withdraw( double amount ) {
        if ( CanWithdraw( amount ) ) {
            balance -= amount;
            return true;
        }
        return false;
    }

    public double GetBalance() {
        return balance;
    }

    public bool CanDeposit() {
        return mayDeposit;
    }

    public bool CanWithdraw( double amount ) {
        return mayWithdraw && ( amount < balance );
    }

    public void Close() {
        owner.Remove( this );
    }

}
