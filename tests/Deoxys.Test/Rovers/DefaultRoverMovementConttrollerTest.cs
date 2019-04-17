using System;
using System.Collections.Generic;
using Xunit;
using Deoxys.Rovers;

namespace Deoxys.Test.Rovers
{
    public class DefaultRoverMovementConttrollerTest
    {
        private readonly IMovementController _moveController;
        public DefaultRoverMovementConttrollerTest()
        {
            _moveController = new DefaultRoverMovementConttroller();
        }

        [Theory]
        [MemberData(nameof(GetSuccesForwardMoveData))]
        public void ForwardMove_True(DirectionType currentDirection, Point currentLocation, Point expectedLocation)
        {
            Point newLocation = _moveController.ForwardMove(currentDirection, currentLocation);

            Assert.Equal(expectedLocation.X, newLocation.X);
            Assert.Equal(expectedLocation.Y, newLocation.Y);
        }


        [Theory]
        [MemberData(nameof(GetSuccesLeftMoveData))]
        public void LeftMove_True(DirectionType currentDirection, DirectionType expectedDirection)
        {
            DirectionType newDirection = _moveController.LeftMove(currentDirection);
            Assert.Equal(expectedDirection, newDirection);
        }


        [Theory]
        [MemberData(nameof(GetSuccesRigthMoveData))]
        public void RigthMove_True(DirectionType currentDirection, DirectionType expectedDirection)
        {
            DirectionType newDirection = _moveController.RigthMove(currentDirection);
            Assert.Equal(expectedDirection, newDirection);
        }


        public static List<object[]> GetSuccesForwardMoveData()
        {
            return new List<object[]>(){
                new object[3]{
                    DirectionType.East, new Point(0, 0), new Point(1, 0)
                },new object[3]{
                    DirectionType.North, new Point(0, 0), new Point(0, 1)
                },new object[3]{
                    DirectionType.South, new Point(0, 0), new Point(0, -1)
                },new object[3]{
                    DirectionType.West, new Point(0, 0), new Point(-1, 0)
                }};
        }

        public static List<object[]> GetSuccesLeftMoveData()
        {
            return new List<object[]>(){
                new object[2]{
                    DirectionType.East,DirectionType.North
                },new object[2]{
                    DirectionType.North, DirectionType.West
                },new object[2]{
                    DirectionType.South,DirectionType.East
                },new object[2]{
                    DirectionType.West, DirectionType.South
                }};
        }
        public static List<object[]> GetSuccesRigthMoveData()
        {
            return new List<object[]>(){
                new object[2]{
                    DirectionType.East,DirectionType.South
                },new object[2]{
                    DirectionType.North, DirectionType.East
                },new object[2]{
                    DirectionType.South,DirectionType.West
                },new object[2]{
                    DirectionType.West, DirectionType.North
                }};
        }


    }
}
