using PartimeSalaryWithTdd.Utility;
using System;

namespace PartimeSalaryWithTdd
{
    public class SalaryCard
    {
        public SalaryCard()
        {
        }

        public int HourlySalary { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double CalculateSalary()
        {
            var workingHour = this.GetWorkingHour();
            return workingHour * this.HourlySalary;
        }

        private double GetWorkingHour()
        {
            var moringEnd = new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 12, 0, 0);
            var afternoonStart = new DateTime(this.StartTime.Year, this.StartTime.Month, this.StartTime.Day, 13, 0, 0);

            var morninghour = DateTimeHelper.TotalHours(this.StartTime, moringEnd);
            var afternoonhour = DateTimeHelper.TotalHours(afternoonStart, this.EndTime);

            var workingHour = morninghour + afternoonhour;

            return workingHour;
        }
    }
}