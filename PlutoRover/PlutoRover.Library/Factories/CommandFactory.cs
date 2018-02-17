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
                    return new Forward();
                case 'B':
                    return new Reverse();
                case 'R':
                    return new RotateRight();
                case 'L':
                    return new RotateLeft();
                default:
                    return new NullCommand();
            }
        }
    }
}