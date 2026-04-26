namespace TraditionalAmlEngine;

public record Transaction(string Name, double Amount, int Frequency);

public class TraditionalDetector
{
    public bool IsFraud(Transaction tx)
    {
        return tx.Amount > 10000 && tx.Frequency > 5;
    }
}
