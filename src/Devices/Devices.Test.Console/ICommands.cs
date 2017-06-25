namespace Devices.Test.Console
{
    public enum Execution
    {
        Skip, Done, Empty
    }


    public interface ICommands
    {
        Execution Handle(string[] input);
        void PrintVerbs();
    }
}