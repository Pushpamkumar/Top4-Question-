using System;

/// <summary>
/// Custom exception used to handle robot safety validation errors.
/// </summary>
public class RobotSafetyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the RobotSafetyException class
    /// with a specific error message.
    /// </summary>
    /// <param name="message">Description of the safety violation</param>
    public RobotSafetyException(string message) : base(message)
    {
    }
}

/// <summary>
/// Performs hazard risk analysis for a robotic system
/// based on precision, worker density, and machinery condition.
/// </summary>
public class RobotHazardAuditor
{
    /// <summary>
    /// Calculates the hazard risk score of a robot working environment.
    /// </summary>
    /// <param name="armPrecision">
    /// Precision of the robot arm (range: 0.0 to 1.0).
    /// Lower precision increases risk.
    /// </param>
    /// <param name="workerDensity">
    /// Number of workers near the robot (range: 1 to 20).
    /// Higher density increases risk.
    /// </param>
    /// <param name="machineryState">
    /// Condition of the machinery.
    /// Allowed values: "Worn", "Faulty", "Critical".
    /// </param>
    /// <returns>
    /// A double value representing the calculated hazard risk score.
    /// </returns>
    /// <exception cref="RobotSafetyException">
    /// Thrown when input values are invalid or machinery state is unsupported.
    /// </exception>
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        double machineRiskFactor;

        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
        return hazardRisk;
    }
}

/// <summary>
/// Entry point of the application.
/// Handles user input and displays the calculated hazard risk score.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method that starts program execution.
    /// </summary>
    /// <param name="args">Command-line arguments</param>
    public static void Main(string[] args)
    {
        try
        {
            RobotHazardAuditor auditor = new RobotHazardAuditor();

            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            double risk = auditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        catch (RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
