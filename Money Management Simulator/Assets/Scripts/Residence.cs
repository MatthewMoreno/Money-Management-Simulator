using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence {

    public GameEngine theGame;

    private bool isPrimary;
    private double value;
    private Mortgage mortgage;

    public Residence( double price, Mortgage loan, bool primary ) {
        value = price;
        mortgage = loan;
        isPrimary = primary;
    }

    public Heloc GetHeloc() {
        double equity = value - mortgage.GetBalance();
        double rate = .1; // Fill this in with correct calculation
        if ( equity < 0 ) {
            return new Heloc( equity * .8, rate, this );
        }
        return null;
    }
    
    public double GetValue() {
        return value;
    }

    public bool IsPrimaryResidence() {
        return isPrimary;
    }

    public void SetPrimaryResidence( bool isPrimaryResidence ) {
        isPrimary = isPrimaryResidence;
    }

    public Mortgage GetMortgage() {
        return mortgage;
    }
}
