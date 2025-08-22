using System;
using System.Collections.Generic;

namespace CodingCompetencyAPI
{
  public sealed class RuleEngine
  {
    private readonly SortedDictionary<int, string> _rules = new();

    public void AddRule(int divisor, string word)
    {
      if (divisor < 2)
        throw new ArgumentOutOfRangeException(nameof(divisor), "Divisor must be >= 2.");
      if (string.IsNullOrWhiteSpace(word))
        throw new ArgumentException("Output word must be non-empty.", nameof(word));

      _rules[divisor] = word;
    }

    public string Map(int x)
    {
      if (_rules.Count == 0) return x.ToString();

      var pieces = new List<string>();
      foreach (var kvp in _rules)
      {
        if (x % kvp.Key == 0)
        {
          pieces.Add(kvp.Value);
        }
      }
      return pieces.Count > 0 ? string.Concat(pieces) : x.ToString();
    }

    public IEnumerable<string> Generate(int n)
    {
      if (n < 1) yield break;
      for (int i = 1; i <= n; i++)
      {
        yield return Map(i);
      }
    }
  }
}
