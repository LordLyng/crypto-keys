using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Security.Cryptography;

namespace CryptoKeys
{
    class Program
    {
        static int Main(string[] args)
        {
            var command = new RootCommand
            {
                new Option(new[] {"--only-iv", "-iv"}) {Argument = new Argument<bool>(() => false), Description = "Only prints an Initialization vector", IsRequired = false},
                new Option(new[] {"--only-key", "-key"}) {Argument = new Argument<bool>(() => false), Description = "Only prints a Key", IsRequired = false},
            };

            command.Description = "Generates Initialization vectors and cryptograpic keys using AES";
            command.Handler = CommandHandler.Create<bool, bool>(Handle);

            return command.InvokeAsync(args).Result;
        }

        static int Handle(bool onlyIV, bool onlyKey)
        {
            if (onlyIV && onlyKey)
                throw new ArgumentException("Unable to exclusively print both");

            using (var provider = new AesCryptoServiceProvider())
            {
                provider.GenerateKey();
                provider.GenerateIV();

                if (!onlyKey)
                    Console.WriteLine($"IV: \"{Convert.ToBase64String(provider.IV)}\"");

                if (!onlyIV)
                    Console.WriteLine($"Key: \"{Convert.ToBase64String(provider.Key)}\"");
            }

            return 0;
        }
    }
}
