using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using PlutoRover.Library.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlutoRover.Library
{
    /// <summary>
    /// Class RobotController.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.IRobotController" />
    public class RobotController : IRobotController
    {
        private IPosition _currentPosition;
        private IPosition _newPosition;
        private ICommand _command;
        private IPlanet _planet;
        private bool _useBitWise = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public RobotController(IPosition position)
        {
            _currentPosition = position;
            _planet = new Planet();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="planet">The planet.</param>
        public RobotController(IPosition position, IPlanet planet)
        {
            _currentPosition = position;
            _planet = planet;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:PlutoRover.Abstractions.IRobotController" /> is collision.
        /// </summary>
        /// <value><c>true</c> if collision; otherwise, <c>false</c>.</value>
        public bool Collision
        {
            get {
                return _collision;
            }
        }
        private bool _collision = false;

        /// <summary>
        /// Moves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>IPosition.</returns>
        public IPosition Move(ICommand command)
        {
            _command = command;

            Drive();

            _currentPosition = _newPosition;

            DetectCollisions();
            return _currentPosition;
        }

        /// <summary>
        /// Detects the collisions.
        /// </summary>
        private void DetectCollisions()
        {
            if (_planet != null && _planet.ObjectsOnMap != null)
            {
                IEnumerable<IPosition> collisions = _planet.ObjectsOnMap.Select(o => o).Where(o => o.ToString().Equals(_currentPosition.ToString()));
                _collision = collisions.Any();
            }
        }

        /// <summary>
        /// Drives this instance.
        /// </summary>
        private void Drive()
        {
            switch (_currentPosition.Direction)
            {
                case CompassDirection.North:
                    SetNewPositionForFacingNorthOrSouth();
                    break;
                case CompassDirection.South:
                    _useBitWise = true;
                    SetNewPositionForFacingNorthOrSouth();
                    break;
                case CompassDirection.East:
                    SetNewPositionForFacingEastOrWest();
                    break;
                case CompassDirection.West:
                    _useBitWise = true;
                    SetNewPositionForFacingEastOrWest();
                    break;
                default:
                    _newPosition = _currentPosition;
                    break;
            }
        }

        /// <summary>
        /// Sets the new position for facing north or south.
        /// </summary>
        private void SetNewPositionForFacingNorthOrSouth()
        {
            _newPosition = new Position(_currentPosition.Xcoordinate, DriveCalculation(_currentPosition.Ycoordinate, _planet.Ysize), _currentPosition.Direction);
        }

        /// <summary>
        /// Sets the new position for facing east or west.
        /// </summary>
        private void SetNewPositionForFacingEastOrWest()
        {
            _newPosition = new Position(DriveCalculation(_currentPosition.Xcoordinate, _planet.Xsize), _currentPosition.Ycoordinate, _currentPosition.Direction);
        }

        /// <summary>
        /// Drives the calculation.
        /// </summary>
        /// <param name="valueToChange">The value to change.</param>
        /// <param name="circumference">The circumference.</param>
        /// <returns>System.Int32.</returns>
        private int DriveCalculation(int valueToChange, int circumference)
        {
            int commandValue = _command.CommandValue;
            valueToChange += _useBitWise ? ~commandValue + 1 : commandValue;

            if (valueToChange < 0)
            {
                valueToChange = circumference - 1;
            }
            else if (valueToChange > circumference - 1)
            {
                valueToChange = 0;
            }

            _useBitWise = false;
            return valueToChange;
        }

        /// <summary>
        /// Moves the specified rotate command.
        /// </summary>
        /// <param name="_rotateCommand">The rotate command.</param>
        /// <returns>IPosition.</returns>
        public IPosition Move(IRotate _rotateCommand)
        {
            _command = (ICommand)_rotateCommand;

            RotateRobot();

            _currentPosition = _newPosition;

            DetectCollisions();
            return _currentPosition;
        }

        /// <summary>
        /// Rotates the robot.
        /// </summary>
        private void RotateRobot()
        {
            if (_currentPosition.Direction.HasValue)
            {
                int newDirectionValue = (int)_currentPosition.Direction.Value + _command.CommandValue;

                newDirectionValue = RotateRobotWithNewDirectionValue(newDirectionValue);
            }
        }

        /// <summary>
        /// Rotates the robot with new direction value.
        /// </summary>
        /// <param name="newDirectionValue">The new direction value.</param>
        /// <returns>System.Int32.</returns>
        private int RotateRobotWithNewDirectionValue(int newDirectionValue)
        {
            newDirectionValue = newDirectionValue < 0 ? 3 : newDirectionValue > 3 ? 0 : newDirectionValue;

            CompassDirection newDirection = (CompassDirection)newDirectionValue;
            _newPosition = new Position(_currentPosition.Xcoordinate, _currentPosition.Ycoordinate, newDirection);
            return newDirectionValue;
        }
    }
}