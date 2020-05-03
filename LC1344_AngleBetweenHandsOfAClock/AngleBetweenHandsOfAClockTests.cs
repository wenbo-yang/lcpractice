using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1344_AngleBetweenHandsOfAClock
{
    [TestClass]
    public class AngleBetweenHandsOfAClockTests
    {
        [TestMethod]
        public void GivenTime_GetAngleOfClock_ShouldReturnAngleOfAClock()
        {
            var hour = 12; var minute = 30;
            var result = GetAngleBetweenHands(hour, minute);

            Assert.IsTrue(result == 165.0);
        }

        [TestMethod]
        public void GivenTimeAnother_GetAngleOfClock_ShouldReturnAngleOfAClock()
        {
            var hour = 3; var minute = 30;
            var result = GetAngleBetweenHands(hour, minute);

            Assert.IsTrue(result == 75);
        }

        private double GetAngleBetweenHands(int hour, int minute)
        {
            if (hour == 12) hour = 0;

            var baseHourAngle = 360.0 / 12.0;
            var baseMinuteAngle = 360.0 / 60.0;
            var baseHourAnglePerMinute = baseHourAngle / 60.0;

            var hourAngle = baseHourAngle * Convert.ToDouble(hour) + baseHourAnglePerMinute * Convert.ToDouble(minute);
            var minuteAngle = baseMinuteAngle * Convert.ToDouble(minute);

            var angle = Math.Abs(hourAngle - minuteAngle); 

            return angle > 180.0 ? 360 - angle : angle;
        }
    }
}
