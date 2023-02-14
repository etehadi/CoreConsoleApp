using CommandLine;
using ConsoleUI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    public class SampleCommand
    {
        private readonly ISampleService _sampleServie;

        public SampleCommand(ISampleService sampleServie)
        {
            _sampleServie = sampleServie;
        }

        public async Task ParseCommand(string[] args)
        {
            ParserResult<SampleCommandOption> parserResult;

            do
            {
                parserResult = await Parser.Default
                    .ParseArguments<SampleCommandOption>(args)
                    .WithParsedAsync(async p => await _sampleServie.Run());

                parserResult = await parserResult.WithNotParsedAsync(HandleParseError);


                if (parserResult.Tag != ParserResultType.Parsed)
                    args = Console.ReadLine()?.Split(" ").Select(p => p.Trim()).ToArray() ?? new string[0];
                else
                    break;

            } while (true);
        }


        private async Task HandleParseError(IEnumerable<Error> errs)
        {
            if (errs.IsVersion())
            {
                Console.WriteLine("Version Request");
                await Task.CompletedTask;
            }

            if (errs.IsHelp())
            {
                Console.WriteLine("Help Request");
                await Task.CompletedTask;
            }

            Console.WriteLine("Parser Fail");
        }
    }
}
