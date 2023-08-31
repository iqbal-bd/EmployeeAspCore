namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        //Add db Context
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        //Add Employee objects
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        //Delete for Employee
        public Employee Delete(int id)
        {
           Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }


        //Get All Employees
        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        //Singe Employee Details
        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        //Singel Employee Update
        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
