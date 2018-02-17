# PlutoRover
![Pluto Rover](https://github.com/erossini/PlutoRover/blob/master/Images/PlutoRover.jpg)
After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover to further investigate the surface.

You are responsible for developing an API that will allow the Rover to move around the planet. 
As you won’t get a chance to fix your code once it is on-board, you are expected to use test driven development.

To simplify navigation, the planet has been divided up into a grid. 
The rover's position and  location is represented by a combination of x and y coordinates and a letter representing one of the four cardinal compass points. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North. Assume that the square directly North from (x, y) is (x, y+1).

In order to control a rover, NASA sends a simple string of letters. The only commands you  can give the rover are `F`, `B`, `L` and `R`

- Implement commands that move the rover forward/backward (`F`, `B`). The rover may only move forward/backward by one grid point, and must maintain the same heading.  
- Implement commands that turn the rover left/right (`L`, `R`). These commands make the rover spin 90 degrees left or right respectively, without moving from its current  spot.
- Implement wrapping from one edge of the grid to another. (Pluto is a sphere after all)
- Implement obstacle detection before each move to a new square. If a given sequence of commands encounters an obstacle, the rover moves up to the last  possible point and reports the obstacle.

Here is an example:
Let's say that the rover is located at 0,0 facing North on a 100x100 grid.
Given the command **FFRFF** would put the rover at 2,2 facing East.

### Tips!
- Don't worry about the structure of the rover. Let the structure evolve as you add more  tests.
- Start simple. For instance you might start with a test that if at 0,0,N with command F,  the robots position should now be 0,1,N.
- Don’t worry about bounds checking until step 3 (implementing wrapping).
- Don't start up/use the debugger, use your tests to implement the kata. If you find that  you run into issues, use your tests to assert on the inner workings of the rover (as  opposed to starting the debugger). 

## Implementations
Just a quick view about my implementation of the Pluto Rover. All project is created in `.NET Core 2`. In `PlutoRover.Library` there is the implementation of the logic for the rover. This library implements `PlutoRover.Abstraction`: here I define all **interfaces** for the library. Why?

![Library schema](https://github.com/erossini/PlutoRover/blob/master/Images/LibrarySchema.PNG)

An `interface` is a `contract` between itself and any class that implements it. This contract states that any class that implements the interface will implement the interface's `properties`, `methods` and/or `events`. _An interface contains no implementation, only the signatures of the functionality the interface provides. An interface can contain signatures of methods, properties, indexers & events._

Using interface based design concept provides `loose coupling`, `component-based programming`, `easier maintainability`, makes code base more `scalable` and makes code `reuse` much more `accessible` because implementation is separated from the interface. Interfaces add a plug and play like architecture into an applications. Interfaces help define a contract (agreement or blueprint, however you chose to define it), between your application and other objects. This indicates what sort of methods, properties and events are exposed by an object.

### Abstractions
In the `PlutoRover.Abstractions` I group all `interfaces` and `enums` shared for all projects.

### Tests
I wrote the tests before starting coding in `TDD` prospective.

![Tests results](https://github.com/erossini/PlutoRover/blob/master/Images/TestExample.PNG)

### Library
This library implements `PlutoRover.Abstractions`. You see three:

- **Commands** contains the implementations of all command for the rover.
- **Factories** contains method for _Command_ and _Direction_
- **Position** implements how to drive the rover

In the root folder:

- **Planet** to define what kind of planet is Pluto
- **RobotController** drives the robot and detects collisions
- **RobotQueueCommandRunner** runs all command for the robot

### ConsoleApp
![Pluto Rover ConsoleApp](https://github.com/erossini/PlutoRover/blob/master/Images/Screenshot.PNG)
