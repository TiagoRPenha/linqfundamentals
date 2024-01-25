using LINQSample;

Console.WriteLine("Hello, World!");

SamplesViewModel vw = new();

var result = vw.OrderByDescendingQuery();

vw.Display(result);
