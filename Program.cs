using CodingCompetencyAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Endpoint untuk Part 1
app.MapGet("/part1", () =>
{
  var engine = new RuleEngine();
  engine.AddRule(3, "foo");
  engine.AddRule(5, "bar");
  return engine.Generate(15);
});

// Endpoint untuk Part 2
app.MapGet("/part2", () =>
{
  var engine = new RuleEngine();
  engine.AddRule(3, "foo");
  engine.AddRule(5, "bar");
  engine.AddRule(7, "jazz");
  return engine.Generate(35);
});

// Endpoint untuk Part 3
app.MapGet("/part3", () =>
{
  var engine = new RuleEngine();
  engine.AddRule(3, "foo");
  engine.AddRule(4, "baz");
  engine.AddRule(5, "bar");
  engine.AddRule(7, "jazz");
  engine.AddRule(9, "huzz");
  return engine.Generate(35);
});

// Endpoint fleksibel untuk Part 4
app.MapPost("/custom", (int n, Dictionary<int, string> rules) =>
{
  var engine = new RuleEngine();
  foreach (var rule in rules)
  {
    engine.AddRule(rule.Key, rule.Value);
  }
  return engine.Generate(n);
});

app.Run();
