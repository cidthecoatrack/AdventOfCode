namespace AdventOfCode.Day8
{
    public interface ICommand
    {
        bool[][] Execute(bool[][] currentDisplay);
    }
}
