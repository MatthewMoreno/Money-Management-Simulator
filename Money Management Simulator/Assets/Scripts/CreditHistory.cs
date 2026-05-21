using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHistory {

    private int creditScore;
    private Player player;
    private HashSet<Loan> openLoans = new HashSet<Loan>();
    private HashSet<LineOfCredit> openLinesOfCredit = new HashSet<LineOfCredit>();

    public int LatePayment( double amount ) {
        return creditScore;
    }

}
