public class BreachDetector
{
    public enum BreachType 
    { 
        NORMAL, 
        TOO_LOW, 
        TOO_HIGH 
    }
    public enum CoolingType 
    { 
        PASSIVE_COOLING,
        MED_ACTIVE_COOLING,
        HI_ACTIVE_COOLING
    }

    public static BreachType inferBreach(double value, double lowerLimit, double upperLimit)
    {
        if (value < lowerLimit) return BreachType.TOO_LOW;
        if (value > upperLimit) return BreachType.TOO_HIGH;
        return BreachType.NORMAL;
    }

    public static int getUpperLimit(CoolingType coolingType)
    {
        int upperLimit = 0;
        switch (coolingType)
        {
            case CoolingType.PASSIVE_COOLING: upperLimit = 35; break;
            case CoolingType.MED_ACTIVE_COOLING: upperLimit = 40; break;
            case CoolingType.HI_ACTIVE_COOLING: upperLimit = 45; break;
        }
        return upperLimit;
    }

    public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
    {
        int lowerLimit = 0, upperLimit = 0;
        upperLimit = getUpperLimit(coolingType);
        return inferBreach(temperatureInC, lowerLimit, upperLimit);
    }
}
