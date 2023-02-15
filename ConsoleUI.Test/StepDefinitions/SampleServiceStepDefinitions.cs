using ConsoleUI.Services;
using ConsoleUI.Test.Drivers;

namespace ConsoleUI.Test.StepDefinitions
{
    [Binding]
    public sealed class SampleServiceStepDefinitions
    {
        int _input;
        int _output;
        private readonly TestHostDriver _testHostDriver;

        public SampleServiceStepDefinitions(TestHostDriver testHostDriver)
        {
            _testHostDriver = testHostDriver;
            var sampleServiceConfig= _testHostDriver.GetOptions<SampleServiceConfig>();
        }



        [Given(@"the input value is (.*)")]
        public void GivenTheInputValueIs(int input)
        {
            _input = input;
        }

        [When(@"run an istance of ISampleService")]
        public void WhenRunAnIstanceOfISampleService()
        {
            _output = _testHostDriver.GetRequiredService<ISampleService>().Run(_input).Result;
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedOutput)
        {
            _output.Should().Be(expectedOutput);
        }

    }
}