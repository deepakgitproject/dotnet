namespace IHCMS
{
class Appointment
    {
        public static void Schedule(Patient p, Doctor d)
        {
            Console.WriteLine($"Appointment scheduled for {p.Name} with Dr. {d.Name}");
        }

        public static void Schedule(Patient p, Doctor d, DateTime date, string mode = "Offline")
        {
            Console.WriteLine(
                $"Appointment scheduled for {p.Name} with Dr. {d.Name} on {date.ToShortDateString()} ({mode})"
            );
        }
    }
}