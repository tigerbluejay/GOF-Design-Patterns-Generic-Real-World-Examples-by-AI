/* 
 * Suppose we have a company organizational structure consisting of employees and departments. 
 * Each department can contain both individual employees and sub-departments.
 */

using System;
using System.Collections.Generic;

// Component interface
interface IOrganizationComponent
{
	void Display();
}

// Leaf class representing an employee
class Employee : IOrganizationComponent
{
	private string name;

	public Employee(string name)
	{
		this.name = name;
	}

	public void Display()
	{
		Console.WriteLine($"Employee: {name}");
	}
}

// Composite class representing a department
class Department : IOrganizationComponent
{
	private string name;
	private List<IOrganizationComponent> members = new List<IOrganizationComponent>();

	public Department(string name)
	{
		this.name = name;
	}

	public void AddMember(IOrganizationComponent member)
	{
		members.Add(member);
	}

	public void RemoveMember(IOrganizationComponent member)
	{
		members.Remove(member);
	}

	public void Display()
	{
		Console.WriteLine($"Department: {name}");
		foreach (IOrganizationComponent member in members)
		{
			member.Display();
		}
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Creating employee objects
		Employee emp1 = new Employee("John Doe");
		Employee emp2 = new Employee("Jane Smith");
		Employee emp3 = new Employee("Mark Johnson");

		// Creating department objects
		Department salesDepartment = new Department("Sales Department");
		Department hrDepartment = new Department("HR Department");
		Department developmentDepartment = new Department("Development Department");

		// Adding employees to the sales department
		salesDepartment.AddMember(emp1);
		salesDepartment.AddMember(emp2);

		// Adding an employee to the HR department
		hrDepartment.AddMember(emp3);

		// Adding departments to the development department
		developmentDepartment.AddMember(salesDepartment);
		developmentDepartment.AddMember(hrDepartment);

		// Displaying the organizational structure
		developmentDepartment.Display();

		Console.ReadKey();
	}
}

/* In this example, we have two types of objects: Employee and Department.
 * Employee represents individual employees, while Department represents departments in the 
 * organization. Both classes implement the IOrganizationComponent interface, which defines the 
 * Display method.
 * 
 * The Main method demonstrates the usage of the Composite pattern. We create instances of employee 
 * objects (emp1, emp2, emp3) and department objects (salesDepartment, hrDepartment, 
 * developmentDepartment). We add employees to the sales department and the HR department, 
 * and then we add these departments to the development department, forming a hierarchical structure.

By calling the Display method on the development department, the department's name is displayed, 
and then the method is recursively called on each member (employees or sub-departments). 
This results in the organizational structure being displayed in a hierarchical manner.

This demonstrates that the composite object (developmentDepartment) displays its name, and then 
delegates the display operation to its child components (salesDepartment and hrDepartment), 
which further delegate it to their child components (emp1, emp2, emp3). The result is the 
organizational structure being displayed in a hierarchical manner.
*/