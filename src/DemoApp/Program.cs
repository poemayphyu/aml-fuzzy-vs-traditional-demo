using TraditionalAmlEngine;
using FuzzyAmlEngine;

var traditional = new TraditionalDetector();
var fuzzy = new FuzzyDetector();

Transaction[] transactions =
[
    //                                          Traditional sees:           Fuzzy sees:
    new("Alice",  3000,  1),  // Low everything                → Normal    → Low (safe)
    new("Bob",   12000,  8),  // Both above threshold           → Fraud     → Medium (nuanced)
    new("Carol",  9500,  9),  // Just below $10K, high freq     → Normal!   → Medium (catches it)
    new("Dave",  18000,  1),  // High amount, low freq          → Normal!   → Medium (catches it)
    new("Eve",   10001,  6),  // Barely over both thresholds    → Fraud     → Low-Medium (proportional)
    new("Frank", 20000, 10),  // Max everything                 → Fraud     → High (agrees)
];

Console.WriteLine("=== AML Detection: Traditional vs Fuzzy ===\n");
Console.WriteLine($"{"Name",-7} {"Amount",8} {"Freq",4}  {"Traditional",-12} {"Fuzzy",8}  {"Fuzzy Label",-12}");
Console.WriteLine(new string('-', 80));

foreach (var tx in transactions)
{
    bool fraud = traditional.IsFraud(tx);
    double score = fuzzy.Score(tx);
    string label = fuzzy.Label(score);

    Console.WriteLine($"{tx.Name,-7} {tx.Amount,8:N0} {tx.Frequency,4}  {(fraud ? "Fraud" : "Normal"),-12} {score,8:F2}  {label,-12}");
}

Console.WriteLine();
