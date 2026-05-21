 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxBrackets {

    public GameEngine theGame;

    private List<double> brackets;
    private List<double> rates;
    private double standardDeduction;

    public TaxBrackets( List<double> startingBrackets, List<double> startingRates, double startingStandardDeduction ) {
        brackets = startingBrackets;
        rates = startingRates;
        standardDeduction = startingStandardDeduction;
    }

    public double EstimateTaxWitholdings(double income, Player player) {
        double deductions = GetDeductions( player );
        double taxableIncome = income - deductions;
        double taxes = 0.0;
        for ( int i = 0; i < brackets.Count; i++ ) {
            if ( taxableIncome < brackets[i] ) {
                taxes += taxableIncome * rates[i];
                return taxes;
            } else {
                taxes += brackets[i] * rates[i];
                taxableIncome -= brackets[i];
            }
        }
        taxes += taxableIncome * rates[rates.Count];
        return taxes;
    }

    public void AdvanceYear() {
        for ( int i = 0; i < brackets.Count; i++ ) {
            brackets[i] = brackets[i] * theGame.GetInflation();
        }
    }

    private double GetDeductions( Player player ) {
        double deductions = player.GetCharitableDonations();
        foreach ( Loan loan in player.GetLoans() ) {
            if ( loan.IsInterestTaxDeductible() ) {
                deductions += loan.GetInterestPaidThisYear();
            }
        }
        return ( deductions > standardDeduction ) ? deductions : standardDeduction;
    }

}
