using TraditionalAmlEngine;

namespace FuzzyAmlEngine;

public class FuzzyDetector
{
    public double Score(Transaction tx)
    {
        // 1. Fuzzification
        double highAmount = MembershipHighAmount(tx.Amount);
        double highFreq = MembershipHighFrequency(tx.Frequency);

        // 2. Inference (rules)
        var ruleOutputs = new List<double>
        {
            Math.Min(highAmount, highFreq),  // Rule 1: High amount AND high freq → High risk
            highAmount * 0.6,                // Rule 2: High amount alone → Medium risk
            highFreq * 0.5                   // Rule 3: High freq alone → Medium risk
        };

        // 3. Aggregation (MAX)
        double aggregated = ruleOutputs.Max();

        // 4. Defuzzification (scale to 0–100)
        return aggregated * 100;
    }

    public string Label(double score) => score switch
    {
        > 70 => "High Risk",
        > 40 => "Medium Risk",
        _    => "Low Risk"
    };

    private static double MembershipHighAmount(double amount) => amount switch
    {
        <= 5000  => 0,
        >= 20000 => 1,
        _        => (amount - 5000) / (20000 - 5000)
    };

    private static double MembershipHighFrequency(int freq) => freq switch
    {
        <= 2  => 0,
        >= 10 => 1,
        _     => (double)(freq - 2) / (10 - 2)
    };
}
