using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStorePrograms
{
    //information found on following links.
    //https://www.tataaig.com/knowledge-center/car-insurance/how-is-your-car-insurance-premium-calculated
    //https://www.policybazaar.com/motor-insurance/car-insurance-calculator/

    class CarInsurancePremiumCalculator
    {
        internal CarInsurancePremiumCalculator(int showroomRate, int personalAccidentCover, int thirdPartyCover)
        {
            this.ShowroomRate = showroomRate;
            this.PersonalAccidentCover = personalAccidentCover;
            this.ThirdPartyCover = thirdPartyCover;
        }

        private int _depreciationValue = 20;
        private double _ownDamagePremiumValue = 1.970;
        private int _noClaimBonusDiscountValue = 20;
        private int _serviceTaxValue = 14;

        private int ShowroomRate { get; set; }
        private int PersonalAccidentCover { get; set; }
        private int ThirdPartyCover { get; set; }
        //other charges
        private int LegalLiablityPaidToDriver { get; set; }

        private int CalculateInsuranceDeclaredValue()
        {
            int depreciation = ((this.ShowroomRate / 100) * this._depreciationValue);
            return this.ShowroomRate - depreciation;
        }

        private int CalculateOtherCharge()
        {
            return LegalLiablityPaidToDriver;
        }

        private int CalculateTotalOwnDamagePremium()
        {
            //IDV = Showroom price of your car + cost of accessories (if any) – depreciation value as per (IRDAI)
            //Thus, formula to calculate OD premium amount is:
            //Own Damage premium = IDV X [Premium Rate (decided by insurer)] + [Add-Ons (eg. bonus coverage)] – [Discount & benefits (no claim bonus, theft discount, etc.)] 
            int insuranceDeclareValue = CalculateInsuranceDeclaredValue();
            int ownDamagePremiun = (int)((insuranceDeclareValue / 100) * this._ownDamagePremiumValue);
            int noClaimBonusDiscount = ((ownDamagePremiun / 100) * _noClaimBonusDiscountValue);
            int otherCharge = CalculateOtherCharge();
            return (ownDamagePremiun + otherCharge - noClaimBonusDiscount);
        }

        private int CalculateNetPremium()
        {
            //car insurance premium is the sum of the  following 3 covers.
            //1. Third Partry Cover
            //2. Own Damage Cover
            //3. Personal Accident Cover
            int totolOwnDamagePremium = CalculateTotalOwnDamagePremium();
            return (totolOwnDamagePremium + this.PersonalAccidentCover + this.ThirdPartyCover);
        }

        private int CalculateServiceTax()
        {
            int netPremium = CalculateNetPremium();
            return netPremium / 100 * this._serviceTaxValue;
        }

        internal int TotalPremium()
        {
            int netPremium = CalculateNetPremium();
            int serviceTax = CalculateServiceTax();
            int totalPremiun = netPremium + serviceTax;
            return totalPremiun;
        }
    }
}
