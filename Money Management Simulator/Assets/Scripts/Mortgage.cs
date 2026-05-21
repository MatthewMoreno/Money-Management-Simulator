using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortgage : Loan {

    private Residence property;

    public Mortgage( double rate, double startingAmount, int length, Player theOwner, Account paymentAccount, Residence residence )
        : base ( rate, startingAmount, length, theOwner, paymentAccount ) {
        property = residence;
    }

}
