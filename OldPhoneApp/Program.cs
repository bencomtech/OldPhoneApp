using OldPhoneApp;

IEnumerable<string> inputs = new List<string>()
{
    "33#", // => output: E
    "227*#", // => output: B
    "4433555 555666#", // => output: HELLO
    "8 88777444666*664#", // => output: ?????
};

IMobilePhone phone = new OldPhone();
string output;

foreach (string input in inputs)
{
    output = phone.Pad(input);

    Console.WriteLine($"input: {input} => output: {output}");
}

Console.WriteLine("End...");
