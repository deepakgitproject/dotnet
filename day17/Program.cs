// using System;
// using System.Reflection;

// // ===================== SAMPLE CLASS =====================
// class Employee
// {
//     // Field (private)
//     private int _salary;

//     // Property
//     public string Name { get; set; }

//     // Parameterless constructor
//     public Employee()
//     {
//         Name = "Unknown";
//         _salary = 0;
//     }

//     // Parameterized constructor
//     public Employee(string name, int salary)
//     {
//         Name = name;
//         _salary = salary;
//     }

//     // Method with no parameters
//     public void Work()
//     {
//         Console.WriteLine(Name + " is working. Salary = " + _salary);
//     }

//     // Method with parameters
//     public void SetSalary(int salary)
//     {
//         _salary = salary;
//     }
// }

// // ===================== PROGRAM =====================
// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("========= ASSEMBLY =========");

//         // 1. Get current assembly
//         Assembly assembly = Assembly.GetExecutingAssembly();

//         Console.WriteLine("Assembly Name: " + assembly.FullName);

//         Console.WriteLine("\n========= ALL TYPES =========");

//         // 2. Get all types
//         Type[] types = assembly.GetTypes();

//         foreach (Type type in types)
//         {
//             Console.WriteLine("\nClass: " + type.Name);

//             // 3. List all methods
//             foreach (MethodInfo method in type.GetMethods())
//             {
//                 Console.WriteLine("  Method: " + method.Name);

//                 // 4. List parameters of each method
//                 ParameterInfo[] parameters = method.GetParameters();
//                 foreach (ParameterInfo p in parameters)
//                 {
//                     Console.WriteLine("     Parameter: " + p.Name + " : " + p.ParameterType);
//                 }
//             }
//         }

//         Console.WriteLine("\n========= WORKING WITH EMPLOYEE USING REFLECTION =========");

//         // 5. Get Employee type
//         Type empType = typeof(Employee);



//         // 6. Get default constructor
//         // ConstructorInfo defaultCtor = empType.GetConstructor(Type.EmptyTypes);
//         // 3. Invoke it (create object)
//         // object empObj1 = defaultCtor.Invoke(null);



//         // 6. Get constructor with parameters (string, int)

//         ConstructorInfo ctor = empType.GetConstructor(new Type[] { typeof(string), typeof(int) });

//         // 7. Create object dynamically
//         object empObj = ctor.Invoke(new object[] { "Deepak", 50000 });
        

//         // 8. PROPERTYINFO: Set Name
//         // PropertyInfo nameProp = empType.GetProperty("Name");
//         // nameProp.SetValue(empObj, "Deepak Yadav");

//         // 9. FIELDINFO: Access private field _salary
//         // FieldInfo salaryField = empType.GetField("_salary", BindingFlags.NonPublic | BindingFlags.Instance);
//         // salaryField.SetValue(empObj, 70000);

//         // 10. METHODINFO: Call Work()
//         MethodInfo workMethod = empType.GetMethod("Work");
//         workMethod.Invoke(empObj, null);

//         // 11. METHODINFO with parameter: Call SetSalary(90000)
//         MethodInfo setSalaryMethod = empType.GetMethod("SetSalary");
//         setSalaryMethod.Invoke(empObj, new object[] { 90000 });

//         // 12. Call Work() again
//         workMethod.Invoke(empObj, null);

//         Console.WriteLine("\n========= DONE =========");
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraEnterpriseSDLC
{
    // ===================== ENUMS =====================

    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum SDLCStage
    {
        Backlog = 0,
        Requirement = 1,
        Design = 2,
        Development = 3,
        CodeReview = 4,
        Testing = 5,
        UAT = 6,
        Deployment = 7,
        Maintenance = 8
    }

    // ===================== CLASSES =====================

    public sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    public sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    public sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }

        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    public sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }

        public AuditLog(string action)
        {
            Time = DateTime.Now;
            Action = action;
        }
    }

    public sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    // ===================== CORE ENGINE =====================

    public sealed class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;

        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();

            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
            {
                _stageBoard[stage] = new List<WorkItem>();
            }

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();

            _requirementCounter = 0;
            _workItemCounter = 0;
        }

        // ===================== METHODS =====================

        public void AddRequirement(string title, RiskLevel risk)
        {
            var requirement = new Requirement(_requirementCounter, title, risk);
            _requirementCounter++;

            _requirements.Add(requirement);
            _auditLedger.AddLast(new AuditLog($"Requirement added: {title} ({risk})"));
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            var workItem = new WorkItem(_workItemCounter, name, stage);
            _workItemCounter++;

            _workItemRegistry[workItem.Id] = workItem;
            _stageBoard[stage].Add(workItem);

            _auditLedger.AddLast(
                new AuditLog($"WorkItem created: {name} in stage {stage}")
            );

            return workItem;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (!_workItemRegistry.ContainsKey(workItemId) ||
                !_workItemRegistry.ContainsKey(dependsOnId))
            {
                return;
            }

            _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
            _auditLedger.AddLast(
                new AuditLog($"Dependency added: WorkItem {workItemId} depends on {dependsOnId}")
            );
        }

        public void PlanStage(SDLCStage stage)
        {
            var candidates = _stageBoard[stage];

            var eligibleItems = candidates.Where(item =>
                item.DependencyIds.All(depId =>
                    _workItemRegistry.ContainsKey(depId) &&
                    _workItemRegistry[depId].Stage > stage
                )
            );

            foreach (var item in eligibleItems)
            {
                _executionQueue.Enqueue(item);
            }

            _auditLedger.AddLast(
                new AuditLog($"Stage planned: {stage}")
            );
        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            var item = _executionQueue.Dequeue();
            var previousStage = item.Stage;

            item.Stage = item.Stage + 1;

            _stageBoard[previousStage].Remove(item);
            _stageBoard[item.Stage].Add(item);

            _auditLedger.AddLast(
                new AuditLog(
                    $"WorkItem {item.Id} executed: {previousStage} -> {item.Stage}"
                )
            );
        }

        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            _auditLedger.AddLast(
                new AuditLog($"Test suite registered: {suiteId}")
            );
        }

        public void DeployRelease(string version)
        {
            var snapshot = new BuildSnapshot(version);
            _rollbackStack.Push(snapshot);

            _auditLedger.AddLast(
                new AuditLog($"Release deployed: {version}")
            );
        }

        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            var snapshot = _rollbackStack.Pop();

            _auditLedger.AddLast(
                new AuditLog($"Release rolled back: {snapshot.Version}")
            );
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (_releaseScoreboard.ContainsKey(score))
                return;

            var metric = new QualityMetric(metricName, score);
            _releaseScoreboard.Add(score, metric);
        }

        public void PrintAuditLedger()
        {
            foreach (var log in _auditLedger)
            {
                Console.WriteLine($"{log.Time}: {log.Action}");
            }
        }

        public void PrintReleaseScoreboard()
        {
            foreach (var entry in _releaseScoreboard.Reverse())
            {
                Console.WriteLine(
                    $"{entry.Value.Name} - {entry.Key:F2}"
                );
            }
        }
    }

    // ===================== MAIN =====================

    public class Program
    {
        public static void Main()
        {
            var engine = new EnterpriseSDLCEngine();

            engine.AddRequirement("Single Sign-On", RiskLevel.High);
            engine.AddRequirement("Fraud Detection", RiskLevel.Critical);

            var designSSO = engine.CreateWorkItem(
                "Design SSO", SDLCStage.Design
            );

            var devSSO = engine.CreateWorkItem(
                "Develop SSO", SDLCStage.Development
            );

            var testSSO = engine.CreateWorkItem(
                "Test SSO", SDLCStage.Testing
            );

            engine.AddDependency(devSSO.Id, designSSO.Id);
            engine.AddDependency(testSSO.Id, devSSO.Id);

            engine.RegisterTestSuite("SSO-Regression");
            engine.RegisterTestSuite("Security-Smoke");

            engine.PlanStage(SDLCStage.Design);

            engine.ExecuteNext();
            engine.ExecuteNext();

            engine.DeployRelease("v3.4.1");

            engine.RecordQualityMetric("Code Coverage", 91.7);
            engine.RecordQualityMetric("Security Score", 97.3);

            engine.RollbackRelease();

            Console.WriteLine("\nAUDIT LOG");
            engine.PrintAuditLedger();

            Console.WriteLine("\nRELEASE SCOREBOARD");
            engine.PrintReleaseScoreboard();
        }
    }
}