namespace DigitalPettyCashSystem.Interfaces;

/// <summary>
/// Interface having a method "GetSummary that will provide all the details of expense ,income - all.
/// </summary>
public interface IReportable
{
    string GetSummary();    //It should be abstract in Transaction class and later on overriden by Income and expense class.
}