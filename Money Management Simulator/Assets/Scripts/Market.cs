using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Market : MonoBehaviour {

    private double inflation;
    private double marketGrowth;
    private double federalFundsRate;
    private double tenYearTreasuryNoteYield;
    private double cpi = 10.0d;
    private double idealCpi = 10.0d;
    private readonly double meanInflationRate = .038;
    private readonly double inflationDeviation = .025;
    System.Random rand = new System.Random();

    public void AdvanceYear() {
        idealCpi = idealCpi * meanInflationRate;
        DetermineInflationRate();
        cpi = cpi * inflation;
    }

    public void AdvanceMonth() {
        SetFederalFundsRateOnInflation();
    }

    public double SetFederalFundsRateOnInflation() {
        int variance = rand.Next( 1, 4 );
        if ( inflation > .04 ) {
            switch( variance ) {
                case 1:
                    break;
                case 2:
                    federalFundsRate += .01;
                    break;
                case 3:
                    federalFundsRate += .02;
                    break;
            } 
        } else if ( inflation < .03 ) {
            switch( variance ) {
                case 1:
                    federalFundsRate -= .02;
                    break;
                case 2:
                    federalFundsRate -= .01;
                    break;
                case 3:
                    break;
            }
        } else {
            switch ( variance ) {
                case 1:
                    federalFundsRate -= .01;
                    break;
                case 2:
                    break;
                case 3:
                    federalFundsRate += .01;
                    break;
            }
        }
        if ( federalFundsRate > .2 ) { federalFundsRate = .2; }
        if ( federalFundsRate < .01 ) { federalFundsRate = .01; }
        return federalFundsRate;
    }

    public double DetermineInflationRate() {
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt( -2.0 * Math.Log( u1 ) ) * Math.Sin( 2.0 * Math.PI * u2 );
        double suggestedInflation = meanInflationRate + inflationDeviation * randStdNormal;
        suggestedInflation = suggestedInflation * ( 1 - federalFundsRate );
        double suggestedCpi = cpi * suggestedInflation;
        double cpiRatio = suggestedCpi / idealCpi;
        suggestedInflation += ( 1 - cpiRatio ) / 3.0d;
        inflation = suggestedInflation;
        return inflation;
    }

    public double GetInflation() { return inflation; }
    public void SetInflation( double rate ) { inflation = rate; }

    public double GetMarketGrowth() { return marketGrowth; }
    public void SetMarketGrowth( double rate ) { marketGrowth = rate; }

    public double GetFederalFundsRate() { return federalFundsRate; }
    public void SetFedRates( double rates ) { federalFundsRate = rates; }

    public double GetTenYearTreasuryNoteYield() { return tenYearTreasuryNoteYield; }
    public void SetTenYearTreasuryNoteYield( double yield ) { tenYearTreasuryNoteYield = yield; }

}
