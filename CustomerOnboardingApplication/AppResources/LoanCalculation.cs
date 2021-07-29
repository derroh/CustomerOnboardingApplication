using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaccoBook.AppResources
{
    class LoanCalculation
    {
        //standard Loan Calculation Formulas
        public static string CalculateLoanRepayment(            
            string InterestCalculationMethod,
            double InterestRate = 18,
            double LoanAmount = 5000,
            int NumberOfInstallments = 12
            )
        {
            double LoanPrincipleRepayment = 0;
            double LoanInterest = 0;
            double InstallmentAmount = 0;
            double InstallmentRepaymentAmount = 0;
            double AmortisedInterest = 0;

            if (InterestCalculationMethod == "Amortised")
            {
                InstallmentAmount = Math.Round((InterestRate / 12 / 100) / (1 - Math.Pow((1 + (InterestRate / 12 / 100)), - NumberOfInstallments)) * LoanAmount, 2, MidpointRounding.ToEven);
                LoanInterest = Math.Round(LoanAmount / 100 / 12 * InterestRate, 2, MidpointRounding.ToEven);

                LoanPrincipleRepayment = InstallmentAmount - LoanInterest;
                InstallmentRepaymentAmount = InstallmentAmount;

                //Console.WriteLine("Loan Principle Repayment: " + LoanPrincipleRepayment);
                //Console.WriteLine("Loan Interest Repayment: " + LoanInterest);
                //Console.WriteLine("Repayment: " + InstallmentRepaymentAmount);
            }
            else if (InterestCalculationMethod == "Straight Line")
            {
                LoanPrincipleRepayment = Math.Round(LoanAmount / NumberOfInstallments, 0, MidpointRounding.ToEven);
                LoanInterest = Math.Round((InterestRate / 12 / 100) * LoanAmount, 0, MidpointRounding.ToEven);

                InstallmentRepaymentAmount = LoanPrincipleRepayment + LoanInterest;

                //Console.WriteLine("Loan Principle Repayment: " + LoanPrincipleRepayment);
                //Console.WriteLine("Loan Interest Repayment: " + LoanInterest);
                //Console.WriteLine("Repayment: " + InstallmentRepaymentAmount);
            }
            else if (InterestCalculationMethod == "Reducing Balance")
            {
                LoanPrincipleRepayment = LoanAmount / NumberOfInstallments;
                LoanInterest = (InterestRate / 12 / 100) * LoanAmount;

                InstallmentRepaymentAmount = LoanPrincipleRepayment;

                //Console.WriteLine("Loan Principle Repayment: " + LoanPrincipleRepayment);
                //Console.WriteLine("Loan Interest Repayment: " + LoanInterest);
                //Console.WriteLine("Repayment: " + InstallmentRepaymentAmount);
            }
            else if (InterestCalculationMethod == "Reducing Flat")
            {
                InstallmentAmount = Math.Round((InterestRate / 12 / 100) / (1 - Math.Pow((1 + (InterestRate / 12 / 100)), - NumberOfInstallments)) * LoanAmount, 1, MidpointRounding.ToEven);
                LoanPrincipleRepayment = LoanAmount / NumberOfInstallments;
                AmortisedInterest = (InstallmentAmount * NumberOfInstallments) - LoanAmount;

                LoanInterest = AmortisedInterest / NumberOfInstallments;
                InstallmentRepaymentAmount = LoanPrincipleRepayment + LoanInterest;


                //Console.WriteLine("Loan Principle Repayment: " + LoanPrincipleRepayment);
                //Console.WriteLine("Loan Interest Repayment: " + LoanInterest);
                //Console.WriteLine("Repayment: " + InstallmentRepaymentAmount);

            }




            var RepaymentCalculation = new
            {
                LoanInterest,
                InstallmentAmount,
                InstallmentRepaymentAmount,
                LoanPrincipleRepayment
            };

            return JsonConvert.SerializeObject(RepaymentCalculation);
        }

        public static string CalculateRepayment(string LoanType, double LoanAmount, double LoanBalance, double InterestRate, double NumberOfInstallments)
        {
            double LoanInterest = 0;
            double InstallmentAmount = 0;
            double InstallRepaymentAmount = 0;

            if (LoanType == "One Off")
            {
                //Advance loan - 10% interest calculated on loan balance and paid alongside first installment
               
                //Get amount payable for each installment

                InstallmentAmount = LoanAmount / NumberOfInstallments;

                InstallmentAmount = Math.Round(InstallmentAmount, 2, MidpointRounding.ToEven); // format to 2dp

                if (LoanBalance == LoanAmount)
                {
                    LoanInterest = Math.Round(((LoanBalance * InterestRate)/100), 2, MidpointRounding.ToEven);  // format to 2dp

                    InstallRepaymentAmount = InstallmentAmount + LoanInterest;

                    InstallRepaymentAmount = Math.Round(InstallRepaymentAmount, 2, MidpointRounding.ToEven);  // format to 2dp
                }
                else if (LoanBalance < LoanAmount)
                {
                    //if loan balance is less than the loan amount, means a repayment is in progress

                    if (LoanBalance > InstallmentAmount)
                    {
                        //What will be the loan balance after this repayment?

                        double NextLoanBalance = LoanBalance - InstallmentAmount;

                        NextLoanBalance = Math.Round(NextLoanBalance, 2, MidpointRounding.ToEven);  // format to 2dp

                        if (NextLoanBalance > InstallmentAmount)
                        {
                            InstallRepaymentAmount = InstallmentAmount;
                        }
                        else if (NextLoanBalance < InstallmentAmount)
                        {
                            //if next loan balance is less than the installment amount, add the next loan balance to current installment, hence loan is cleared

                            InstallRepaymentAmount = InstallmentAmount + NextLoanBalance;
                            InstallRepaymentAmount = Math.Round(InstallRepaymentAmount, 2, MidpointRounding.ToEven);  // format to 2dp
                        }
                    }
                    else
                    {
                        //InstallmentAmount = Math.Round(LoanBalance, 2, MidpointRounding.ToEven);

                        InstallRepaymentAmount = Math.Round(LoanBalance, 2, MidpointRounding.ToEven);
                    }
                }
            }
            else
            {
                //Reducing Balance    

                InstallmentAmount = LoanAmount / NumberOfInstallments;

                //if its the first installement repayment 

                if (LoanBalance == LoanAmount)
                {
                    LoanInterest = Math.Round((LoanBalance * InterestRate / 100), 2, MidpointRounding.ToEven);

                    InstallRepaymentAmount = (InstallmentAmount + LoanInterest);
                }
                else
                {
                    //if loan balance is less than the loan amount, means a repayment is in progress

                    if (LoanBalance > InstallmentAmount)
                    {
                        //What will be the loan balance after this repayment?

                        double NextLoanBalance = LoanBalance - InstallmentAmount;

                        double NewLoanBalance = 0;
                       
                        if (NextLoanBalance > InstallmentAmount)
                        {
                            LoanInterest = Math.Round((LoanBalance * InterestRate / 100), 2, MidpointRounding.ToEven);
                            
                            NewLoanBalance = LoanBalance;

                            InstallRepaymentAmount = (InstallmentAmount + LoanInterest);
                        }
                        else if (NextLoanBalance < InstallmentAmount)
                        {
                            //if next loan balance is less than the installment amount, add the next loan balance to current installment, hence loan is cleared

                            LoanInterest = Math.Round((LoanBalance * InterestRate / 100), 2, MidpointRounding.ToEven);

                            NewLoanBalance = InstallmentAmount + NextLoanBalance;

                            InstallRepaymentAmount = (NewLoanBalance + LoanInterest);
                        }

                    }
                    else if (LoanBalance == InstallmentAmount)
                    {
                        LoanInterest = Math.Round((LoanBalance * InterestRate / 100), 2, MidpointRounding.ToEven);

                        InstallRepaymentAmount = (InstallmentAmount + LoanInterest);
                    }
                }
            }

            var RepaymentCalculation = new
            {
                LoanInterest,
                InstallmentAmount,
                InstallRepaymentAmount
            };

            return JsonConvert.SerializeObject(RepaymentCalculation);
        }
    }
}
