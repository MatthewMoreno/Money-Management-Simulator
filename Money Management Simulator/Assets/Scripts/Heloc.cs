using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heloc : LineOfCredit {

    private Residence property;

    public Heloc( double total, double rate, Residence residence ) : base ( total, rate ) {
        property = residence;
    }

}
