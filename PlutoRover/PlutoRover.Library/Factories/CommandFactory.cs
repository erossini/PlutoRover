using PlutoRover.Abstractions;
using PlutoRover.Library.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Factories
{
    /// <summary>
    /// Class CommandFactory.
    /// </summary>
    public class CommandFactory
    {
        public ICommand Get(char command)
        {
            switch (command)
            {
                case 'F':
                case 'f':
                    return new Forward();
                case 'B':
                case 'b':
                    return new Reverse();
                case 'R':
                case 'r':
                    return new RotateRight();
                case 'L':
                case 'l':
                    return new RotateLeft();
                default:
                    return new NullCommand();
            }
        }
    }
}