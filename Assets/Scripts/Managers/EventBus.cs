namespace DefaultNamespace
{
    public class EventBus
    {
        public delegate void OnDistanceChanged(float distanceTraveled);
        public static event OnDistanceChanged onDistanceChanged;
    
        public delegate void OnMaxDistanceChanged(float maxDistanceTraveled);
        public static event OnMaxDistanceChanged onMaxDistanceChanged;

        public static void DistanceChanged(float distanceTraveled)
        {
            onDistanceChanged?.Invoke(distanceTraveled);
        }
    }
}