//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// © Reflection | Haydar DEMİR
// 
// Members of a class in C#
//      Constructor     ->      ConstructorInfo
//      Event           ->      EventInfo
//      Field           ->      FieldInfo
//      Method          ->      MethodInfo
//      NestedType      ->      MemberInfo
//      Property        ->      PropertyInfo
//
//  
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // var assemblyInfo = Assembly.GetAssembly(typeof(Program));
            // var assemblyInfo2 = Assembly.GetCallingAssembly();
            // var assemblyInfo3 = Assembly.GetExecutingAssembly();
            // var assemblyInfo4 = Assembly.LoadFile("c:\\temp\\myassembly.dll");

            // Type programType = typeof(Program);
            // var assemblyInfo5 = programType.Assembly;

            // var instance = assemblyInfo5.CreateInstance("ReflectionExample.Program", true) as Program;
            // var instance2 = Activator.CreateInstance(typeof(Program)) as Program;
            // var instance3 = Activator.CreateInstance<Program>();

            // var instanceHandle = Activator.CreateInstance("myassembly.dll", "ReflectionExample.Program");
            // var instance4 = instanceHandle.Unwrap() as Program;

            // ************************* ************************* ************************* *************************

            //var carType = typeof(Car);
            //var members = carType.GetMembers(); // BindingFlags.Public | BindingFlags.Static

            //foreach (var memberInfo in members)
            //{
            //    //if (memberInfo.MemberType == MemberTypes.Property)
            //    //{
            //    //    //
            //    //}

            //    Console.WriteLine($"Member {memberInfo.Name} is of type {memberInfo.MemberType}");
            //}

            // ************************* ************************* ************************* *************************

            //var personType = typeof(Person);
            //var methodInfos = personType.GetMethods();
            //var methodInfo = personType.GetMethods().FirstOrDefault();
            //if (methodInfo?.ReturnType == typeof(void))
            //{
            //    //
            //}

            //if (methodInfo?.IsPublic == true)
            //{
            //    //
            //}

            //var instance = Activator.CreateInstance(typeof(Person));
            //methodInfo?.Invoke(instance, new[] { "Hello World" });

            // ************************* ************************* ************************* *************************

            //var personelType = typeof(Personel);
            //var fieldInfos = personelType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            //foreach (var fieldInfo in fieldInfos)
            //{
            //    var isPrivate = fieldInfo.IsPrivate ? "Yes" : "No";
            //    var isPublic = fieldInfo.IsPublic ? "Yes" : "No";
            //    var isStatic = fieldInfo.IsStatic ? "Yes" : "No";

            //    Console.WriteLine($"Field {fieldInfo.Name} \nPrivate? {isPrivate} \nPublic? {isPublic} \nStatic? {isStatic}");
            //}

            //var props = personelType.GetProperties();
            //foreach (var propertyInfo in props)
            //{
            //    Console.WriteLine($"Property {propertyInfo.Name}\nCan Read? {propertyInfo.CanRead} \nCan Write? {propertyInfo.CanWrite}");
            //}

            //// var personel = new Personel(10);
            //var personel = Activator.CreateInstance(typeof(Personel), 10) as Personel;
            //Console.WriteLine($"Salary is {personel.Salary}");

            //var salaryProp = personelType.GetProperty("Salary");
            //salaryProp?.SetValue(personel, 100);
            //Console.WriteLine($"Salary is {personel.Salary}");

            //var salary = salaryProp?.GetMethod.Invoke(personel, null);

            // ************************* ************************* ************************* *************************

            var personelType = typeof(Personel);
            var allAttribs = personelType.GetCustomAttributes(true);
            var roleAttrib = personelType.GetCustomAttribute(typeof(PersonelRoleAttribute)) as PersonelRoleAttribute;

            Console.WriteLine($"The personel is a manager? {roleAttrib?.IsManager}");

            var nameProp = personelType.GetProperty("Name");
            var requiredAttr = nameProp.GetCustomAttribute<RequiredAttribute>();

            if (requiredAttr != null)
            {
                Console.WriteLine($"{requiredAttr.ErrorMessage}");
            }

            // ************************* ************************* ************************* *************************
            
            Console.ReadLine();
        }
    }

    public class Car
    {
        public double EngineSize { get; set; }

        public void Start()
        {

        }
    }

    public class Person
    {
        public void Say(string message)
        {
            Console.WriteLine(message);
        }
    }

    [PersonelRole(IsManager = false)]
    public class Personel
    {
        public int Salary { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        private readonly int PersonelId;

        private Personel()
        {
            
        }

        public Personel(int personelId)
        {
            PersonelId = personelId;
        }
    }

    public class PersonelRoleAttribute : Attribute
    {
        public bool IsManager { get; set; } 
    }
}
